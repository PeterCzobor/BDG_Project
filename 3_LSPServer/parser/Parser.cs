using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Language;
using OmniSharp.Extensions.LanguageServer.Protocol;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Range = OmniSharp.Extensions.LanguageServer.Protocol.Models.Range;
using FuzzySharp;
using System.Numerics;
using System.Collections;
using OmniSharp.Extensions.JsonRpc.Server.Messages;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace parser
{
    public class BdgDocument
    {
        private string _content;
        private bool _isParsed;
        private ImmutableArray<Diagnostic> _diagnostics;
        private int _version = 1;
        private readonly DocumentUri documentUri;
        string iniJsonPath;
        public Dictionary<string, object> Variables { get; set; } = new Dictionary<string, object>();
        private ImmutableDictionary<string, BdgValue> _values = ImmutableDictionary<string, BdgValue>.Empty;
        private ImmutableDictionary<string, BdgFunctionCall> _functionCalls = ImmutableDictionary<string, BdgFunctionCall>.Empty;
        private ImmutableDictionary<string, BdgColor> _colors = ImmutableDictionary<string, BdgColor>.Empty;
        private ImmutableArray<BdgSection> _sections = ImmutableArray<BdgSection>.Empty;

        public Keywords keywords = new Keywords();

        public SyntaxVisitor visitor = new SyntaxVisitor();

        public BdgDocument(DocumentUri documentUri)
        {
            this.documentUri = documentUri;
        }

        public void Load(string content)
        {
            _content = content;
            _isParsed = false;
            _version++;
        }

        public void CheckFile(string path)
        {
            if (File.Exists(path))
            {
                _content = File.ReadAllText(path);
                if (path.Contains("bdg"))
                    IniJsonPath = path.Replace("bdg", "json");
                _isParsed = false;
            }
        }

        public int Version => _version;
        public DocumentUri DocumentUri => documentUri;
        public string IniJsonPath { get => iniJsonPath; set => iniJsonPath = value; }

        public ImmutableArray<Diagnostic> GetDiagnostics()
        {
            EnsureParsed();
            return _diagnostics;
        }

        public string GetText() => _content;

        public void Update(TextDocumentContentChangeEvent[] changes)
        {
            StringBuilder updatedContent = new StringBuilder(_content);

            foreach (var change in changes)
            {
                int startIndex = GetIndexAtPosition(change.Range.Start);
                int endIndex = GetIndexAtPosition(change.Range.End);

                string newText = change.Text;

                if (newText.Contains("\n"))
                {
                    newText = newText.Replace("\r\n", "\n");
                }

                if (startIndex >= 0 && endIndex >= startIndex && endIndex <= _content.Length)
                {
                    updatedContent.Remove(startIndex, endIndex - startIndex);
                    updatedContent.Insert(startIndex, newText);
                }
            }

            _content = updatedContent.ToString();
            Load(_content);
        }


        private int GetIndexAtPosition(Position position)
        {
            int line = 0;
            int index = 0;

            while (index < _content.Length)
            {
                if (line == position.Line)
                {
                    int lineStartPosition = index;
                    while (index < _content.Length && _content[index] != '\n' && _content[index] != '\r')
                    {
                        index++;
                    }
                    return lineStartPosition + position.Character;
                }

                if (_content[index] == '\n')
                {
                    line++;
                }

                index++;
            }

            if (line == position.Line && position.Character == 0)
            {
                return _content.Length;
            }

            return -1;
        }

        public Position GetPositionAtIndex(int index)
        {
            var line = 0;
            var character = 0;

            if (index < 0 || index > _content.Length)
                return (-1, -1);

            for (var i = 0; i < index; i++)
            {
                if (_content[i] == '\n')
                {
                    line++;
                    character = 0;
                }
                else
                {
                    character++;
                }
            }
            return (line, character);
        }

        public object GetItemAtPosition(Position position)
        {
            object result;
            result = _values.Values.FirstOrDefault(z => z.Location.Start.Line == position.Line && z.Location.Start.Character <= position.Character && z.Location.End.Character >= position.Character);
            if(result == null)
                result = _functionCalls.Values.FirstOrDefault(z => z.Location.Start.Line == position.Line && z.Location.Start.Character <= position.Character && z.Location.End.Character >= position.Character);
            if (result == null)
                result = _colors.Values.FirstOrDefault(z => z.Location.Start.Line == position.Line && z.Location.Start.Character <= position.Character && z.Location.End.Character >= position.Character);
            return result;
        }
        public object GetVarAtPosition(Position position)
        {
            var value = _values.Values.FirstOrDefault(z => z.Location.Start.Line == position.Line && z.Location.Start.Character <= position.Character && z.Location.End.Character >= position.Character);
            return value;
        }

        public char GetCharAtPosition(Position position)
        {
            int index = GetIndexAtPosition(position);
            if (index >= 0 && index < _content.Length)
                return _content[index-1];
            else
                return '\0';
        }
        public IEnumerable<BdgSection> GetSections()
        {
            EnsureParsed();
            return _sections;
        }

        ImmutableArray<Diagnostic>.Builder diagnostics;
        ImmutableDictionary<string, BdgValue>.Builder values;
        ImmutableDictionary<string, BdgFunctionCall>.Builder functionCalls;
        ImmutableDictionary<string, BdgColor>.Builder colors;
        ImmutableArray<BdgSection>.Builder sections;
        private void EnsureParsed()
        {
            if (_isParsed) return;

            diagnostics = ImmutableArray<Diagnostic>.Empty.ToBuilder();
            values = ImmutableDictionary<string, BdgValue>.Empty.ToBuilder();
            colors = ImmutableDictionary<string, BdgColor>.Empty.ToBuilder();
            sections = ImmutableArray<BdgSection>.Empty.ToBuilder();
            functionCalls = ImmutableDictionary<string, BdgFunctionCall>.Empty.ToBuilder();

            var lexer = new Combined1Lexer(new AntlrInputStream(_content));
            var tokens = new CommonTokenStream(lexer);
            var parser = new Combined1Parser(tokens);
            MyErrorListener myErrorListener = new MyErrorListener();
            myErrorListener.diagnostics = diagnostics;
            myErrorListener.tokenList = (List<IToken>)tokens.GetTokens();
            parser.RemoveErrorListeners();
            parser.AddErrorListener(myErrorListener);
            var tree = parser.program();

            visitor.Variables.Clear();
            if (File.Exists(iniJsonPath))
            {
                string fileContent = File.ReadAllText(iniJsonPath);
                visitor.Variables = JsonConvert.DeserializeObject<Dictionary<string, object>>(fileContent, new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                foreach (var kvp in visitor.Variables)
                {
                    if (kvp.Value.ToString() == "Button")
                        visitor.Variables[kvp.Key] = new ButtonVar();
                    if (kvp.Value.ToString() == "Label")
                        visitor.Variables[kvp.Key] = new LabelVar();
                }
            }
            visitor.Variables["FUNC"] = new object();
            visitor.Variables["CurrentPlayer"] = new Player();
            visitor.Variables["players"] = new List<Player>() { new Player(), new Player() };
            visitor.diagnostics = diagnostics;
            visitor.colors = colors;
            visitor.sections = sections;
            visitor.values = values;
            visitor.functionCalls = functionCalls;
            visitor.Visit(tree);

            _values = values.ToImmutable();
            _functionCalls = functionCalls.ToImmutable();
            _colors = colors.ToImmutable();
            _sections = sections.ToImmutable();
            _diagnostics = diagnostics.ToImmutable();
            _isParsed = true;
        }

        public List<string> getErrors()
        {
            List<string> errors = new List<string>();
            foreach (var item in GetDiagnostics())
                errors.Add(item.Message);
            return errors;
        }

        public static string CheckSimilarity(string word)
        {
            double similarity = 0;
            string similar = "";
            foreach (string s in Keywords.keywords)
            {
                double temp = Fuzz.Ratio(s, word);
                if (temp > similarity)
                {
                    similarity = temp;
                    similar = s;
                }
            }
            return similar;
        }
        public static List<string> GetSimilars(string word)
        {
            List<string> similars = new List<string>();
            foreach (string s in Keywords.keywords)
            {
                if (Fuzz.Ratio(s, word)>70)
                {
                    similars.Add(s);
                }
            }
            return similars;
        }
        public CompletionList<Data> GetKeywords(string keyword)
        {
            if (visitor.Variables.ContainsKey(keyword))
                return keywords.KeywordsByValue(visitor.Variables[keyword]);
            List<CompletionItem<Data>> newListItems = new List<CompletionItem<Data>>();
            foreach (string s in visitor.Variables.Keys)
            {
                newListItems.Add(
                    new CompletionItem<Data>()
                    {
                        Label = s,
                        Kind = CompletionItemKind.Variable
                    });
            }
            keywords.variableKeywords = new CompletionList<Data>(newListItems);
            return keywords.KeywordsByString(keyword);
        }
    }
    public record BdgValue(string Key, object Value, Range Location);
    public record BdgFunctionCall(string Key, Range Location);
    public record BdgColor(string Color, Range Location);
    public record BdgSection(string Name, SymbolKind type, bool inSection, Range Location);

    public class MyErrorListener : IAntlrErrorListener<IToken>
    {
        public ImmutableArray<Diagnostic>.Builder diagnostics;
        public List<IToken> tokenList;

        public void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            var prevToken = tokenList[offendingSymbol.TokenIndex-1];
            if (msg.Contains("missing"))
            {
                diagnostics.Add(new Diagnostic()
                {
                    Code = "BDGMIS",
                    Message = msg,
                    Severity = DiagnosticSeverity.Error,
                    Range = ((prevToken.Line - 1, prevToken.Column+prevToken.Text.Length), (prevToken.Line - 1, prevToken.Column + prevToken.Text.Length)),
                    Data = msg.Remove(0, ("missing '").Length).Substring(0, msg.Remove(0, ("missing '").Length).IndexOf('\'')),
                });
            }
            else
            {
                IToken actToken = offendingSymbol;
                if (e is NoViableAltException asd)
                {
                    actToken = asd.StartToken;
                    foreach (string s in Keywords.keywords)
                    {
                        double similarity = Fuzz.Ratio(s, actToken.Text);
                        if (similarity >70)
                        {
                            diagnostics.Add(new Diagnostic()
                            {
                                Code = "BDGTYP",
                                Message = "no viable alternative at input '"+actToken.Text+ "'. Did you mean '" + BdgDocument.CheckSimilarity(actToken.Text) + "'?",
                                Severity = DiagnosticSeverity.Error,
                                Range = ((actToken.Line - 1, actToken.Column), (actToken.Line - 1, actToken.Column)),
                                Data = actToken.Text,
                            });
                            return;
                        }
                    }
                }
                diagnostics.Add(new Diagnostic()
                {
                    Code = "BDGUNE",
                    Message = msg,
                    Severity = DiagnosticSeverity.Error,
                    Range = ((actToken.Line - 1, actToken.Column), (actToken.Line - 1, actToken.Column)),
                });
            }
        }
    }
}
