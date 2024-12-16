using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Language;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Unity.Properties;
using UnityEngine;

public class Preprocessor : MonoBehaviour
{
    string inputPath = "input.txt";
    string outputPath = "output.txt";

    string text = "";

    PreprocessorVisitor visitor = new PreprocessorVisitor();

    // Start is called before the first frame update
    void Start()
    {
        /*using (StreamReader sr = new StreamReader(inputPath))
        {
            text = sr.ReadToEnd();
        }

        text = Process(text);

        using (StreamWriter sw = new StreamWriter(outputPath))
        {
            sw.Write(text);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string Process(string script)
    {
        var lexer = new Combined1Lexer(new AntlrInputStream(script));
        var tokens = new CommonTokenStream(lexer);
        var parser = new Combined1Parser(tokens);
        var tree = parser.program();
        visitor.text = script;
        visitor.Visit(tree);
        foreach (var item in visitor.replace)
        {
            text = text.Replace(item.Key, item.Value);
        }
        return text;
    }
}

public class PreprocessorVisitor : Combined1BaseVisitor<object>
{
    public string text = "";
    public Dictionary<string, string> replace = new Dictionary<string, string>();

    public override object VisitVariable([NotNull] Combined1Parser.VariableContext context)
    {
        for(int i=0; i<context.member().Length; i++)
        {
            if (context.member(i).field() != null && context.member(i).field().parameterList() != null)
            {
                string original = "";
                string tile = "";
                string neighbor = "";
                string end = "";
                string correct = "";
                if(context.parent.parent is ParserRuleContext prc)
                {
                    Debug.Log(text.Substring(prc.Start.StartIndex, prc.Stop.StopIndex - prc.Start.StartIndex + 1));
                    original = text.Substring(prc.Start.StartIndex, prc.Stop.StopIndex - prc.Start.StartIndex + 1);
                    Debug.Log(text.Substring(context.Start.StartIndex, context.member(i).field().Start.StartIndex - context.Start.StartIndex));
                    tile = text.Substring(context.Start.StartIndex, context.member(i).field().Start.StartIndex - context.Start.StartIndex);
                    Debug.Log(text.Substring(context.member(i).field().Start.StartIndex+2, context.member(i).field().Stop.StopIndex - context.member(i).field().Start.StartIndex - 2));
                    neighbor = text.Substring(context.member(i).field().Start.StartIndex + 2, context.member(i).field().Stop.StopIndex - context.member(i).field().Start.StartIndex - 2);
                    Debug.Log(text.Substring(context.member(i).field().Stop.StopIndex+1, prc.Stop.StopIndex - context.member(i).field().Stop.StopIndex));
                    end = text.Substring(context.member(i).field().Stop.StopIndex+1, prc.Stop.StopIndex - context.member(i).field().Stop.StopIndex);

                    correct = Regex.Replace(neighbor, @"\bN\b", $"({tile}.posX,{tile}.posY+1){end}");
                    correct = Regex.Replace(correct, @"\bE\b", $"({tile}.posX+1,{tile}.posY){end}");
                    correct = Regex.Replace(correct, @"\bS\b", $"({tile}.posX,{tile}.posY-1){end}");
                    correct = Regex.Replace(correct, @"\bW\b", $"({tile}.posX-1,{tile}.posY){end}");
                    Debug.Log(correct);
                    replace[original] = correct;
                }

            }
        }
        foreach (var item in context.member())
        {
            if(item.field()!=null && item.field().parameterList()!=null)
            {
                //text = text.Remove(item.attribute().Start.StartIndex, item.attribute().Stop.StopIndex-item.attribute().Start.StartIndex);
            }
        }
        return base.VisitVariable(context);
    }
}
