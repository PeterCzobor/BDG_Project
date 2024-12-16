using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using Antlr4.Runtime.Misc;
using Language;
using Newtonsoft.Json.Linq;
using OmniSharp.Extensions.LanguageServer.Protocol.Models;

namespace parser
{
    class Function
    {
        public string caller;
        public string name;
        public object localVar = null;
        public string thisID = null;

        public Function(string c, string n)
        {
            caller = c;
            name = n;
        }
    }

    public class SyntaxVisitor : Combined1BaseVisitor<object>
    {
        public Dictionary<string, object> Variables { get; set; } = new Dictionary<string, object>();

        Dictionary<Function, Combined1Parser.FunctionBlockContext> Functions { get; set; } = new Dictionary<Function, Combined1Parser.FunctionBlockContext>();

        Function currentFunc;

        Random rand = new Random();

        public ImmutableArray<Diagnostic>.Builder diagnostics;
        public ImmutableDictionary<string, BdgValue>.Builder values;
        public ImmutableDictionary<string, BdgFunctionCall>.Builder functionCalls;
        public ImmutableDictionary<string, BdgColor>.Builder colors;
        public ImmutableArray<BdgSection>.Builder sections;

        public SyntaxVisitor() { }

        #region SIMPLE STRUCTURES
        public override object VisitLogStatement([NotNull] Combined1Parser.LogStatementContext context)
        {
            var value = Visit(context.expression());
            functionCalls.Add(functionCalls.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                new BdgFunctionCall("#", ((context.Start.Line - 1, context.Start.Column), (context.Start.Line - 1, context.Start.Column + 2))));
            return base.VisitLogStatement(context);
        }

        bool inphase = false;
        public override object VisitPhase([NotNull] Combined1Parser.PhaseContext context)
        {
            if (context.block() != null)
            {
                sections.Add(new BdgSection("Phase " + context.INTEGER().GetText(), SymbolKind.Namespace, false, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column))));
                inphase = true;
                Visit(context.block());
                inphase = false;
            }
            return null;
        }

        public override object VisitIfBlock([NotNull] Combined1Parser.IfBlockContext context)
        {
            object subject;
            if (context.expression() != null)
                subject = Visit(context.expression());
            else
                return null;

            if (subject is null)
                return null;
            if (!(subject is bool || subject.GetType() == typeof(object)))
            {
                diagnostics.Add(new Diagnostic()
                {
                    Code = "BDGIFE",
                    Message = "Expression is not Boolean",
                    Severity = DiagnosticSeverity.Error,
                    Range = ((context.Start.Line - 1, context.Start.Column), (context.expression().Stop.Line - 1, context.expression().Stop.Column + 2))
                });
                return null;
            }
            if (context.block() != null)
                Visit(context.block());
            if (context.elseifBlock() != null)
                Visit(context.elseifBlock());
            return null;
        }

        bool inRepeat = false;
        public override object VisitRepeatUntil([NotNull] Combined1Parser.RepeatUntilContext context)
        {
            if(context.block() != null)
            {
                inRepeat = true;
                Visit(context.block());
                inRepeat = false;
            }
            else
                return null;

            object subject;
            if (context.expression() != null)
                subject = Visit(context.expression());
            else
                return null;

            if (subject is null)
                return null;
            if (!(subject is bool || subject.GetType() == typeof(object)))
            {
                diagnostics.Add(new Diagnostic()
                {
                    Code = "BDGIFE",
                    Message = "Expression is not Boolean",
                    Severity = DiagnosticSeverity.Error,
                    Range = ((context.Start.Line - 1, context.Start.Column), (context.expression().Stop.Line - 1, context.expression().Stop.Column + 2))
                });
                return null;
            }
            return null;
        }
        #endregion

        #region STATEMENTS
        public override object VisitDeclaration([NotNull] Combined1Parser.DeclarationContext context)
        {
            string varName;
            if (context.ID() != null)
                varName = context.ID().GetText();
            else
                return null;
            var value = new object();

            switch (context.type().GetText())
            {
                case "Player":
                    if (context.parameterList() != null)
                    {
                        if (Visit(context.parameterList()) is object[] o && o.Length > 0 && o[0] is not string)
                        {
                            diagnostics.Add(new Diagnostic()
                            {
                                Code = "BDGIVD",
                                Message = "Invalid Declaration",
                                Severity = DiagnosticSeverity.Error,
                                Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column)),
                            });
                            return null;
                        }
                    }
                    functionCalls.Add(functionCalls.ContainsKey(context.type().GetText() + (context.type().Start.Line - 1).ToString() + context.type().Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.type().GetText() + (context.type().Start.Line - 1).ToString() + context.type().Start.Column.ToString(),
                        new BdgFunctionCall(context.type().GetText() + "()", ((context.type().Start.Line - 1, context.type().Start.Column), (context.ID().Symbol.Line - 1, context.ID().Symbol.Column + context.ID().GetText().Length))));
                    value = new Player();
                    break;
                case "Piece":
                    if (context.parameterList() != null)
                    {
                        if (Visit(context.parameterList()) is object[] o && o.Length > 2 && !(o[0] is Player && o[1] is int && o[2] is int))
                        {
                            diagnostics.Add(new Diagnostic()
                            {
                                Code = "BDGIVD",
                                Message = "Invalid Declaration",
                                Severity = DiagnosticSeverity.Error,
                                Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column)),
                            });
                            return null;
                        }
                    }
                    if (context.pieceType() != null)
                    {
                        if (Variables.ContainsKey(context.pieceType().ID().GetText()) && Variables[context.pieceType().ID().GetText()] is List<string> l)
                            l.Add(varName);
                        else
                            Variables[context.pieceType().ID().GetText()] = new List<string>() { varName };
                        functionCalls.Add(functionCalls.ContainsKey(context.type().GetText() + (context.type().Start.Line - 1).ToString() + context.type().Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.type().GetText() + (context.type().Start.Line - 1).ToString() + context.type().Start.Column.ToString(),
                            new BdgFunctionCall(context.type().GetText() + "(PieceType)", ((context.type().Start.Line - 1, context.type().Start.Column), (context.ID().Symbol.Line - 1, context.ID().Symbol.Column + context.ID().GetText().Length))));
                    }
                    else
                        functionCalls.Add(functionCalls.ContainsKey(context.type().GetText() + (context.type().Start.Line - 1).ToString() + context.type().Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.type().GetText() + (context.type().Start.Line - 1).ToString() + context.type().Start.Column.ToString(),
                            new BdgFunctionCall(context.type().GetText() + "()", ((context.type().Start.Line - 1, context.type().Start.Column), (context.ID().Symbol.Line - 1, context.ID().Symbol.Column + context.ID().GetText().Length))));
                    value = new Piece();
                    break;
                case "Tile":
                    value = new Tile();
                    break;
                case "Dice":
                    if (context.parameterList() != null)
                    {
                        if (Visit(context.parameterList()) is object[] o)
                            foreach (var item in o)
                                if (!(item is int))
                                {
                                    diagnostics.Add(new Diagnostic()
                                    {
                                        Code = "BDGIVD",
                                        Message = "Invalid Declaration",
                                        Severity = DiagnosticSeverity.Error,
                                        Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column)),
                                    });
                                    return null;
                                }
                        functionCalls.Add(functionCalls.ContainsKey(context.type().GetText() + (context.type().Start.Line - 1).ToString() + context.type().Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.type().GetText() + (context.type().Start.Line - 1).ToString() + context.type().Start.Column.ToString(),
                            new BdgFunctionCall(context.type().GetText() + "()", ((context.type().Start.Line - 1, context.type().Start.Column), (context.ID().Symbol.Line - 1, context.ID().Symbol.Column + context.ID().GetText().Length))));
                    }
                    value = new Dice();
                    break;
                case "List":
                    value = new List<object>() { new(), new() };
                    break;
            }

            if (currentFunc == null)
                sections.Add(new BdgSection(context.ID().GetText(), SymbolKind.Field, true, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + 1))));

            Variables[varName] = value;

            return null;
        }

        public override object VisitAssignment([NotNull] Combined1Parser.AssignmentContext context)
        {
            if (context.variable().ID() != null && context.variable().ChildCount == 1)
            {
                if (!Variables.ContainsKey(context.variable().ID().GetText()))
                    Variables[context.variable().ID().GetText()] = new object();
            }

            object left = Visit(context.variable());
            object right = Visit(context.expression());

            if (left is ComplexList list)
            {
                switch (list.collection)
                {
                    case Collection.ANY:
                        diagnostics.Add(new Diagnostic()
                        {
                            Code = "BDGLAS",
                            Message = "List.any cannot be used in assignment",
                            Severity = DiagnosticSeverity.Error,
                            Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + 1)),
                            Data = context.GetText()
                        });
                        break;
                    case Collection.NONE:
                        diagnostics.Add(new Diagnostic()
                        {
                            Code = "BDGLAS",
                            Message = "List.none cannot be used in assignment",
                            Severity = DiagnosticSeverity.Error,
                            Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + 1)),
                            Data = context.GetText()
                        });
                        break;
                }
            }
            return null;
        }

        public override object VisitCancel([NotNull] Combined1Parser.CancelContext context)
        {
            functionCalls.Add(functionCalls.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                new BdgFunctionCall(context.GetText(), ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
            return null;
        }

        public override object VisitStop([NotNull] Combined1Parser.StopContext context)
        {
            if (!inRepeat)
            {
                diagnostics.Add(new Diagnostic()
                {
                    Code = "BDGSTP",
                    Message = "stop must be in repeat-until block",
                    Severity = DiagnosticSeverity.Error,
                    Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.Stop.Text.Length)),
                });
            }
            functionCalls.Add(functionCalls.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                new BdgFunctionCall(context.GetText(), ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
            return null;
        }
        #endregion

        #region VARIABLES
        public object parentObject;

        public override object VisitVariable([NotNull] Combined1Parser.VariableContext context)
        {
            if (context.ID() != null && Variables.ContainsKey(context.ID().GetText()))
            {
                values.Add(values.ContainsKey(context.ID().GetText() + (context.ID().Symbol.Line - 1).ToString() + context.ID().Symbol.Column.ToString()) ? Guid.NewGuid().ToString() : context.ID().GetText() + (context.ID().Symbol.Line - 1).ToString() + context.ID().Symbol.Column.ToString(),
                    new BdgValue(context.ID().GetText(), Variables[context.ID().GetText()], ((context.ID().Symbol.Line - 1, context.ID().Symbol.Column), (context.ID().Symbol.Line - 1, context.ID().Symbol.Column + context.ID().GetText().Length))));
            }

            parentObject = null;
            if (currentFunc != null)
            {
                if (currentFunc.thisID != null)
                    parentObject = currentFunc.thisID == "player" ? new Player() : new Piece();
                if (context.ID() != null && Variables.ContainsKey(context.ID().GetText()))
                    parentObject = Variables[context.ID().GetText()];
            }
            else
            {
                if (context.ID() != null && Variables.ContainsKey(context.ID().GetText()))
                    parentObject = Variables[context.ID().GetText()];
            }

            if (parentObject == null && context.ID() != null)
            {
                diagnostics.Add(new Diagnostic()
                {
                    Code = "BDGIND",
                    Message = context.ID() + " is not declared",
                    Severity = DiagnosticSeverity.Error,
                    Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column)),
                });
                return null;
            }


            if (context.tile() != null)
            {
                parentObject = Visit(context.tile());
            }

            if (context.member().Length == 0)
                return parentObject;

            for (int i = 0; i < context.member().Length; i++)
            {
                if (parentObject is ComplexList list && context.member(i).field() != null)
                {
                    List<object> temp = new List<object>();
                    {
                        parentObject = list.list[0];
                        temp.Add(Visit(context.member(i)));
                    }

                    parentObject = new ComplexList(temp, list.collection);
                }
                else
                    parentObject = Visit(context.member(i));
            }

            if (parentObject is ComplexList list_)
            {
                List<object> temp = new List<object>();
                for (int i = 0; i < list_.list.Count; i++)
                {
                    if (list_.list[i] is IList list)
                    {
                        foreach (object item in list)
                            temp.Add(item);
                    }
                    else
                        temp.Add(list_.list[i]);
                }
                parentObject = new ComplexList(temp, list_.collection);
            }

            return parentObject;
        }

        public override object VisitParameterList([NotNull] Combined1Parser.ParameterListContext context)
        {
            var args = context.expression().Select(Visit).ToArray();

            return args;
        }

        public override object VisitField([NotNull] Combined1Parser.FieldContext context)
        {
            switch (context.GetText())
            {
                case "posX":
                    if (parentObject is Piece || parentObject is Tile || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), 10, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return 10;
                    }
                    break;
                case "posY":
                    if (parentObject is Piece || parentObject is Tile || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), 10, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return 10;
                    }
                    break;
                case "pieces":
                    if (parentObject is Player || parentObject is Tile || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), new List<Piece>() { new Piece() }, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return new List<Piece>() { new(), new() };
                    }
                    break;
                case "tiles":
                    values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                        new BdgValue(context.GetText(), new List<Tile>() { new Tile() }, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                    return new List<Piece>() { new(), new() };
                case "empty":
                    if (parentObject is Tile || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), true, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return true;
                    }
                    break;
                case "player":
                    if (parentObject is Piece || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), new Player(), ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return new Player();
                    }
                    break;
                case "players":
                    return new List<Player>() { new(), new() };
                case "color":
                    if (parentObject is Piece || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), new Color(), ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return Color.Empty;
                    }
                    break;
                case "route":
                    if (parentObject is Piece || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), new List<Tile>() { new Tile() }, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return new List<Tile>() { new(), new() };
                    }
                    break;
                case "routePosition":
                    if (parentObject is Piece || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), 10, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return 10;
                    }
                    break;
                case "texture":
                    if (parentObject is Piece || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), "String", ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return "String";
                    }
                    break;
                case "type":
                    if (parentObject is Piece || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), "String", ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return "String";
                    }
                    break;
                case "value":
                    if (parentObject is Dice || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), 10, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return 10;
                    }
                    break;
                case "name":
                    if (parentObject is Player || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), "String", ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return "String";
                    }
                    break;
                case "active":
                    if (parentObject is ButtonVar || parentObject is LabelVar || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), true, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return true;
                    }
                    break;
                case "text":
                    if (parentObject is ButtonVar || parentObject is LabelVar || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), "String", ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return "String";
                    }
                    break;
                case "textColor":
                    if (parentObject is ButtonVar || parentObject is LabelVar || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), new Color(), ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return Color.Empty;
                    }
                    break;
                case "fontSize":
                    if (parentObject is ButtonVar || parentObject is LabelVar || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), 10, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return 10;
                    }
                    break;
                case "onClick":
                    if (parentObject is ButtonVar || (parentObject != null && parentObject.GetType() == typeof(object)))
                    {
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.GetValueString(parentObject) + "." + context.GetText(), "String", ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return "String";
                    }
                    break;
            }
            if (context.parameterList() != null)
            {
                if (parentObject is Tile || (parentObject != null && parentObject.GetType() == typeof(object)))
                {
                    functionCalls.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                        new BdgFunctionCall("@", ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Start.Column + 1))));
                    Visit(context.parameterList());
                    return new Tile();
                }
            }
            if (parentObject is null)
                return null;

            diagnostics.Add(new Diagnostic()
            {
                Code = "BDGHNM",
                Message = VisitorHelper.GetSimpleValueString(parentObject) + " Has no member '" + context.GetText() + "'",
                Severity = DiagnosticSeverity.Error,
                Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column)),
                Data = VisitorHelper.GetSimpleValueString(parentObject)
            });
            return null;
        }

        public override object VisitTile([NotNull] Combined1Parser.TileContext context)
        {
            context.expression().Select(Visit).ToArray();
            return new Tile();
        }
        #endregion

        #region LISTS
        public override object VisitListExpression([NotNull] Combined1Parser.ListExpressionContext context)
        {
            List<object> temp = new List<object>();

            for (int i = 0; i < context.list().expression().Length; i++)
                temp.Add(Visit(context.list().expression(i)));
            return temp;
        }

        public override object VisitCollection([NotNull] Combined1Parser.CollectionContext context)
        {
            if (!(parentObject is IList || parentObject is ComplexList || (parentObject != null && parentObject.GetType() == typeof(object))))
            {
                diagnostics.Add(new Diagnostic()
                {
                    Code = "BDGHNM",
                    Message = VisitorHelper.GetSimpleValueString(parentObject) + " Has no member '" + context.GetText() + "'",
                    Severity = DiagnosticSeverity.Error,
                    Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column)),
                    Data = VisitorHelper.GetSimpleValueString(parentObject)
                });
                return null;
            }
            if (context.GetText() == "count")
            {
            }
            else
                functionCalls.Add(functionCalls.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                    new BdgFunctionCall(context.GetText(), ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));

            if (parentObject is IList list && list.Count > 0)
            {
                switch (context.GetText())
                {
                    case "all":
                        return new ComplexList(list, Collection.ALL);
                    case "any":
                        return new ComplexList(list, Collection.ANY);
                    case "none":
                        return new ComplexList(list, Collection.NONE);
                    case "count":
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.classColor("List") + ".count", 10, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return 10;
                }
            }
            if (parentObject is ComplexList clist && clist.list.Count > 0)
            {
                switch (context.GetText())
                {
                    case "all":
                        return new ComplexList(clist.list, Collection.ALL);
                    case "any":
                        return new ComplexList(clist.list, Collection.ANY);
                    case "none":
                        return new ComplexList(clist.list, Collection.NONE);
                    case "count":
                        values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                            new BdgValue(VisitorHelper.classColor("List") + ".count", 10, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
                        return 10;
                }
            }
            return parentObject;
        }

        public override object VisitElement([NotNull] Combined1Parser.ElementContext context)
        {
            if (parentObject is ComplexList clist)
                parentObject = clist.list;
            if (parentObject is IList elist)
            {
                if (elist[0] is IList list)
                    elist = list;
                string key = "";
                for (int i = 0; i < context.parent.parent.ChildCount; i++)
                {
                    if (context.parent.parent.GetChild(i).SourceInterval.a == context.SourceInterval.a &&
                        context.parent.parent.GetChild(i).SourceInterval.b == context.SourceInterval.b)
                        key = context.parent.parent.GetChild(i - 1).GetText().Replace(".", "") + context.GetText();
                }
                values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                    new BdgValue(key, elist[0], ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column))));

                return elist[0];
            }
            if ((parentObject != null && parentObject.GetType() == typeof(object)))
                return parentObject;
            diagnostics.Add(new Diagnostic()
            {
                Code = "BDGNAL",
                Message = "The given variable is not a list",
                Severity = DiagnosticSeverity.Error,
                Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column)),
            });
            return null;
        }

        #endregion

        #region FUNCTIONS
        public override object VisitFunctionBlock([NotNull] Combined1Parser.FunctionBlockContext context)
        {
            if (context.declaration() != null)
            {
                Visit(context.declaration());
                if(context.declaration().ID() != null)
                    currentFunc.localVar = Variables[context.declaration().ID().GetText()];
            }
            if (context.block() != null)
                Visit(context.block());

            return null;
        }
        public override object VisitFunctionCall([NotNull] Combined1Parser.FunctionCallContext context)
        {
            if (context.functionName().ID() == null)
                functionCalls.Add(functionCalls.ContainsKey(context.functionName().GetText() + (context.functionName().Start.Line - 1).ToString() + context.functionName().Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.functionName().GetText() + (context.functionName().Start.Line - 1).ToString() + context.functionName().Start.Column.ToString(),
                    new BdgFunctionCall(context.functionName().GetText(), ((context.functionName().Start.Line - 1, context.functionName().Start.Column), (context.functionName().Stop.Line - 1, context.functionName().Stop.Column + context.functionName().GetText().Length))));
            Visit(context.parameterList());
            return true;
        }

        bool decSections = true;
        public override object VisitFunctionBody([NotNull] Combined1Parser.FunctionBodyContext context)
        {
            Function func = null;
            Combined1Parser.FunctionBlockContext value = null;

            if (Visit(context.variable()) is Player pl)
            {
                value = context.functionBlock();
                func = new Function("player", context.functionName().GetText());
            }
            else if (Visit(context.variable()) is ComplexList pls)
            {
                value = context.functionBlock();
                if (pls.list[0] is Player)
                    func = new Function("player", context.functionName().GetText());
                else
                    func = new Function("piece", context.functionName().GetText());
            }
            else if (Visit(context.variable()) is IList list)
            {
                value = context.functionBlock();
                if (list[0] is Player)
                    func = new Function("player", context.functionName().GetText());
                else
                    func = new Function("piece", context.functionName().GetText());
            }
            else if (Visit(context.variable()) is Piece pi)
            {
                value = context.functionBlock();

                func = new Function("piece", context.functionName().GetText());
            }
            else if (context.functionName().GetText() == "DrawCondition")
            {
                value = context.functionBlock();

                func = new Function(null, context.functionName().GetText());
            }
            else
            {
                value = context.functionBlock();

                func = new Function(null, context.functionName().GetText());

            }

            Functions[func] = value;
            currentFunc = func;
            currentFunc.thisID = func.caller;
            Visit(context.functionBlock());
            if (currentFunc != null)
            {
                currentFunc.thisID = null;
                currentFunc.localVar = null;
                currentFunc = null;
            }

            if (decSections)
            {
                sections.Add(new BdgSection("Declarations", SymbolKind.Namespace, false, ((0, 0), (context.Start.Line - 1, context.Start.Column))));
                decSections = false;
            }
            sections.Add(new BdgSection(context.variable().GetText() + "." + context.functionName().GetText(), SymbolKind.Function, inphase, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column))));

            return null;
        }
        #endregion

        #region EXPRESSIONS
        public override object VisitVarExpression([NotNull] Combined1Parser.VarExpressionContext context)
        {
            object variable = Visit(context.variable());
                return variable;
        }

        public override object VisitConstant([NotNull] Combined1Parser.ConstantContext context)
        {
            if (context.INTEGER() != null)
                return int.Parse(context.GetText());

            if (context.FLOAT() != null)
                return double.Parse(context.GetText(), CultureInfo.InvariantCulture);

            if (context.BOOL() != null)
                return context.GetText() == "true";

            if (context.STRING() != null)
                return context.GetText().Replace("\"", "");

            if (context.NULL() != null)
                return null;

            if(context.color() != null)
            {
                string color = "";
                if (context.color().STRING() != null)
                    color = context.color().STRING().GetText().Replace("\"", "");
                if (context.color().STRING() != null && !context.color().STRING().GetText().Contains("#") && Color.FromName(color).IsKnownColor)
                    color = $"#{Color.FromName(color).R:X2}{Color.FromName(color).G:X2}{Color.FromName(color).B:X2}";
                if(!(color.Contains("#") && color.Length == 7))
                {
                    diagnostics.Add(new Diagnostic()
                    {
                        Code = "BDGICO",
                        Message = "Invalid Color",
                        Severity = DiagnosticSeverity.Error,
                        Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column)),
                    });
                    return null;
                }
                colors.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                    new BdgColor(color, ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column))));
                return context.color().STRING().GetText().Replace("\"", "");
            }

            return null;
        }

        public override object VisitMultExpression([NotNull] Combined1Parser.MultExpressionContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));

            return (context.multOp().GetText()) switch
            {
                "*" => VisitorHelper.Mul(left, right),
                "/" => VisitorHelper.Div(left, right),
                "%" => VisitorHelper.Mod(left, right),
                _ => null
            };
        }

        public override object VisitAddExpression([NotNull] Combined1Parser.AddExpressionContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));

            var x = (context.addOp().GetText()) switch
            {
                "+" => VisitorHelper.Add(left, right),
                "-" => VisitorHelper.Sub(left, right),
                _ => null
            };
            if (left is null || right is null)
                return x;

            if(x == null && !(left.GetType() == typeof(object) || right.GetType() == typeof(object)))
            {
                diagnostics.Add(new Diagnostic()
                {
                    Code = "BDGADD",
                    Message = "Invalid operation",
                    Severity = DiagnosticSeverity.Error,
                    Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.Stop.Text.Length)),
                });
                return null;
            }
            return x;
        }

        public override object VisitCompExpression([NotNull] Combined1Parser.CompExpressionContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));

            if (left is ComplexList clistL)
                left = clistL.list[0];
            if (right is ComplexList clistR)
                right = clistR.list[0];
            if (left != null && right != null && !(left.GetType() == typeof(object) || right.GetType()==typeof(object))
                && left.GetType() != right.GetType())
            {
                diagnostics.Add(new Diagnostic()
                {
                    Code = "BDGCOM",
                    Message = "Invalid comparison, type mismatch",
                    Severity = DiagnosticSeverity.Error,
                    Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column+context.Stop.Text.Length)),
                });
            }

            return true;
        }

        public override object VisitBoolExpression([NotNull] Combined1Parser.BoolExpressionContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));

            if (left is ComplexList clistL)
                left = clistL.list[0];
            if (left is null)
                return null;
            if (!(left is bool || left is Tile || left.GetType() == typeof(object)))
            {
                diagnostics.Add(new Diagnostic()
                {
                    Code = "BDGBOL",
                    Message = "Invalid "+context.boolOp().GetText()+" operation, left expression is not Boolean",
                    Severity = DiagnosticSeverity.Error,
                    Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.Stop.Text.Length)),
                });
                return null;
            }
            if (right is ComplexList clistR)
                right = clistR.list[0];
            if (right is null)
                return null;
            if (!(right is bool || right is Tile || right.GetType() == typeof(object)))
            {
                diagnostics.Add(new Diagnostic()
                {
                    Code = "BDGBOL",
                    Message = "Invalid " + context.boolOp().GetText() + " operation, right expression is not Boolean",
                    Severity = DiagnosticSeverity.Error,
                    Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.Stop.Text.Length)),
                });
                return null;
            }
            return true;
        }

        public override object VisitParentExpression([NotNull] Combined1Parser.ParentExpressionContext context)
        {
            return Visit(context.expression());
        }

        public override object VisitAbsExpression([NotNull] Combined1Parser.AbsExpressionContext context)
        {
            object subject = Visit(context.expression());
            if (subject is int i)
                return Math.Abs(i);
            else if (subject is double f)
                return Math.Abs(f);
            return base.VisitAbsExpression(context);
        }

        public override object VisitInputExpression([NotNull] Combined1Parser.InputExpressionContext context)
        {
            switch(context.input().inputTypes().GetText())
            {
                case "Click":
                    if(context.input().expression() != null)
                        return new List<object>() { context.input().inputTypes().GetText(), Visit(context.input().expression()) };
                    break;
                case "Press":
                    if(context.input().expression() != null && Visit(context.input().expression()) is string s)
                    {
                        if((s.Length == 1 && (char.IsUpper(s[0]) || char.IsDigit(s[0]))) || VisitorHelper.specialKeys.Contains(s))
                        {
                            return new List<object>() { context.input().inputTypes().GetText(), Visit(context.input().expression()) };
                        }
                    }
                    break;
            }
            diagnostics.Add(new Diagnostic()
            {
                Code = "BDGIIE",
                Message = "Invalid input expression",
                Severity = DiagnosticSeverity.Error,
                Range = ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.Stop.Text.Length)),
            });
            return null;
        }

        public override object VisitTurnStagesExp([NotNull] Combined1Parser.TurnStagesExpContext context)
        {
            if (context.turnStages().functionCall() != null && context.turnStages().functionCall().functionName() != null)
            {
                Variables["piece"] = new Piece();
                Variables["tile"] = new Tile();
                Visit(context.turnStages().functionCall());
                Variables.Remove("piece");
                Variables.Remove("tile");
                functionCalls.Add(functionCalls.ContainsKey(context.turnStages().functionCall().GetText() + (context.turnStages().functionCall().Start.Line - 1).ToString() + context.turnStages().functionCall().Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.turnStages().functionCall().GetText() + (context.turnStages().functionCall().Start.Line - 1).ToString() + context.turnStages().functionCall().Start.Column.ToString(),
                    new BdgFunctionCall("FUNC." + context.turnStages().functionCall().functionName().GetText(), ((context.turnStages().functionCall().functionName().Start.Line - 1, context.turnStages().functionCall().functionName().Start.Column), (context.turnStages().functionCall().functionName().Stop.Line - 1, context.turnStages().functionCall().functionName().Stop.Column + context.turnStages().functionCall().functionName().GetText().Length))));
            }
            else
                functionCalls.Add(functionCalls.ContainsKey(context.turnStages().GetText() + (context.turnStages().Start.Line - 1).ToString() + context.turnStages().Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.turnStages().GetText() + (context.turnStages().Start.Line - 1).ToString() + context.turnStages().Start.Column.ToString(),
                    new BdgFunctionCall(context.turnStages().GetText(), ((context.turnStages().Start.Line - 1, context.turnStages().Start.Column), (context.turnStages().Stop.Line - 1, context.turnStages().Stop.Column))));
            return null;
        }

        public override object VisitNeighborsExp([NotNull] Combined1Parser.NeighborsExpContext context)
        {
            values.Add(values.ContainsKey(context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString()) ? Guid.NewGuid().ToString() : context.GetText() + (context.Start.Line - 1).ToString() + context.Start.Column.ToString(),
                new BdgValue(VisitorHelper.classColor("Tile") + VisitorHelper.propColor("@")+"(" + VisitorHelper.keyColor(context.GetText())+")", new Tile(), ((context.Start.Line - 1, context.Start.Column), (context.Stop.Line - 1, context.Stop.Column + context.GetText().Length))));
            return new Tile();
        }
        #endregion
    }

    public class VisitorHelper
    {
        public static object Add(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li + ri;
            if (left is double lf && right is double rf)
                return lf + rf;
            if (left is int lif && right is double rif)
                return lif + rif;
            if (left is double lfi && right is int rfi)
                return lfi + rfi;
            if (left is string || right is string)
                return $"{left}{right}";
            return null;
        }
        public static object Sub(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li - ri;
            if (left is double lf && right is double rf)
                return lf - rf;
            if (left is int lif && right is double rif)
                return lif - rif;
            if (left is double lfi && right is int rfi)
                return lfi - rfi;
            return null;
        }
        public static object Mul(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li * ri;
            if (left is double lf && right is double rf)
                return lf * rf;
            if (left is int lif && right is double rif)
                return lif * rif;
            if (left is double lfi && right is int rfi)
                return lfi * rfi;
            return null;
        }
        public static object Div(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li / ri;
            if (left is double lf && right is double rf)
                return lf / rf;
            if (left is int lif && right is double rif)
                return lif / rif;
            if (left is double lfi && right is int rfi)
                return lfi / rfi;
            return null;
        }
        public static object Mod(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li % ri;
            if (left is double lf && right is double rf)
                return lf % rf;
            if (left is int lif && right is double rif)
                return lif % rif;
            if (left is double lfi && right is int rfi)
                return lfi % rfi;
            return null;
        }
        public static bool Great(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li > ri;
            if (left is double lf && right is double rf)
                return lf > rf;
            if (left is int lif && right is double rif)
                return lif > rif;
            if (left is double lfi && right is int rfi)
                return lfi > rfi;
            return false;
        }
        public static bool GreatEqu(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li >= ri;
            if (left is double lf && right is double rf)
                return lf >= rf;
            if (left is int lif && right is double rif)
                return lif >= rif;
            if (left is double lfi && right is int rfi)
                return lfi >= rfi;
            return false;
        }
        public static bool Small(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li < ri;
            if (left is double lf && right is double rf)
                return lf < rf;
            if (left is int lif && right is double rif)
                return lif < rif;
            if (left is double lfi && right is int rfi)
                return lfi < rfi;
            return false;
        }
        public static bool SmallEqu(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li <= ri;
            if (left is double lf && right is double rf)
                return lf <= rf;
            if (left is int lif && right is double rif)
                return lif <= rif;
            if (left is double lfi && right is int rfi)
                return lfi <= rfi;
            return false;
        }

        public static List<string> specialKeys = new List<string>() { "Space", "Enter", "Shift", "Ctrl", "Tab", "CapsLock",
        "Alt", "Backspace", "Plus", "Minus", "Multiply", "Divide"};

        public static string GetSimpleValueString(object o)
        {
            if (o is int || o is float || o is double)
                return "Number";
            if (o is Color)
                return "Color";
            if (o is bool)
                return "Bool";
            if (o is string)
                return "String";
            if (o is IList list)
                return "List (" + GetSimpleValueString(list.Count > 1 ? list[1] : list[0]) + ") ";
            if (o == null)
                return "NULL";
            if (o.GetType() == typeof(object))
                return "Variable";
            return o.ToString();
        }

        public static string GetValueString(object o)
        {
            if (o is int || o is float || o is double)
                return $"{varColor("Number")}";
            if (o is Color)
                return $"{varColor("Color")}";
            if (o is bool)
                return $"{varColor("Bool")}";
            if (o is string)
                return $"{varColor("String")}";
            if (o is IList list)
                return $"{classColor("List")} (" + GetValueString(list.Count > 1 ? list[1] : list[0]) + ") ";
            if (o == null)
                return "NULL";
            if (o.GetType() == typeof(object))
                return $"{varColor("Variable")}";
            return classColor(o.ToString());
        }
        public static string GetValueDetails(string v)
        {
            return (v) switch
            {
                "RESULT" => "Output of the function",
                "<span style=\"color:#4EC9B0;\">Piece</span>.posX" => $"X coordinate of the {classColor("Tile")} on which the {classColor("Piece")} currently located",
                "<span style=\"color:#4EC9B0;\">Piece</span>.posY" => $"Y coordinate of the {classColor("Tile")} on which the {classColor("Piece")} currently located",
                "<span style=\"color:#4EC9B0;\">Tile</span>.posX" => $"X coordinate of the {classColor("Tile")}",
                "<span style=\"color:#4EC9B0;\">Tile</span>.posY" => $"Y coordinate of the {classColor("Tile")}",
                "<span style=\"color:#4EC9B0;\">Tile</span>.empty" => $"{keyColor("true")} if there is no {classColor("Piece")} located on the {classColor("Tile")}; otherwise {keyColor("false")}",
                "<span style=\"color:#4EC9B0;\">Player</span>.pieces" => $"List of {classColor("Piece")}s, assigned to the {classColor("Player")}",
                "<span style=\"color:#4EC9B0;\">Tile</span>.pieces" => $"List of {classColor("Piece")}s, located on the {classColor("Tile")}",
                "tiles" => $"List of all {classColor("Tile")}s on the Board",
                "<span style=\"color:#4EC9B0;\">Piece</span>.player" => $"The {classColor("Player")} to which the {classColor("Piece")} assigned",
                "<span style=\"color:#4EC9B0;\">Piece</span>.color" => $"Color of the {classColor("Piece")}",
                "<span style=\"color:#4EC9B0;\">Piece</span>.route" => $"List of {classColor("Tile")}s on which the {classColor("Piece")} can step",
                "<span style=\"color:#4EC9B0;\">Piece</span>.routePosition" => $"Index of the {classColor("Tile")} in the {classColor("Piece")}'s Route on which it is currently located",
                "<span style=\"color:#4EC9B0;\">Piece</span>.texture" => $"Variable representing the path of the texture file assigned to the {classColor("Piece")}",
                "<span style=\"color:#4EC9B0;\">Piece</span>.type" => $"Name of the Type assigned to the {classColor("Piece")}",
                "<span style=\"color:#4EC9B0;\">Dice</span>.value" => $"Current value of the {classColor("Dice")} generated randomly by it's {funcColor("Roll")} function",
                "<span style=\"color:#4EC9B0;\">Button</span>.active" => $"Defines whether the {classColor("Button")} is visible and interractable",
                "<span style=\"color:#4EC9B0;\">Label</span>.active" => $"Defines whether the {classColor("Label")} is visible and interractable",
                "<span style=\"color:#4EC9B0;\">Button</span>.text" => $"Text of the {classColor("Button")}",
                "<span style=\"color:#4EC9B0;\">Label</span>.text" => $"Text of the {classColor("Label")}",
                "<span style=\"color:#4EC9B0;\">List</span>.count" => $"Number of elements in the {classColor("List")}",
                "<span style=\"color:#4EC9B0;\">Tile</span><span style=\"color:#9CDCFE;\">@</span>(<span style=\"color:#C586C0;\">N</span>)" => $"Neighbor of the given {classColor("Tile")}\n\n* ({classColor("Tile")}.posX, {classColor("Tile")}.posY+1)",
                "<span style=\"color:#4EC9B0;\">Tile</span><span style=\"color:#9CDCFE;\">@</span>(<span style=\"color:#C586C0;\">E</span>)" => $"Neighbor of the given {classColor("Tile")}\n\n* ({classColor("Tile")}.posX+1, {classColor("Tile")}.posY)",
                "<span style=\"color:#4EC9B0;\">Tile</span><span style=\"color:#9CDCFE;\">@</span>(<span style=\"color:#C586C0;\">S</span>)" => $"Neighbor of the given {classColor("Tile")}\n\n* ({classColor("Tile")}.posX, {classColor("Tile")}.posY-1)",
                "<span style=\"color:#4EC9B0;\">Tile</span><span style=\"color:#9CDCFE;\">@</span>(<span style=\"color:#C586C0;\">W</span>)" => $"Neighbor of the given {classColor("Tile")}\n\n* ({classColor("Tile")}.posX-1, {classColor("Tile")}.posY)",
                "<span style=\"color:#4EC9B0;\">Tile</span><span style=\"color:#9CDCFE;\">@</span>(<span style=\"color:#C586C0;\">NE</span>)" => $"Neighbor of the given {classColor("Tile")}\n\n* ({classColor("Tile")}.posX+1, {classColor("Tile")}.posY+1)",
                "<span style=\"color:#4EC9B0;\">Tile</span><span style=\"color:#9CDCFE;\">@</span>(<span style=\"color:#C586C0;\">NW</span>)" => $"Neighbor of the given {classColor("Tile")}\n\n* ({classColor("Tile")}.posX-1, {classColor("Tile")}.posY+1)",
                "<span style=\"color:#4EC9B0;\">Tile</span><span style=\"color:#9CDCFE;\">@</span>(<span style=\"color:#C586C0;\">SE</span>)" => $"Neighbor of the given {classColor("Tile")}\n\n* ({classColor("Tile")}.posX+1, {classColor("Tile")}.posY-1)",
                "<span style=\"color:#4EC9B0;\">Tile</span><span style=\"color:#9CDCFE;\">@</span>(<span style=\"color:#C586C0;\">SW</span>)" => $"Neighbor of the given {classColor("Tile")}\n\n* ({classColor("Tile")}.posX-1, {classColor("Tile")}.posY-1)",
                _ => ""
            };
        }

        public static string GetFuncString(string f)
        {
            return (f) switch
            {
                "EndTurn" => $"{classColor("Player")}.{funcColor("EndTurn")}()",
                "Turn" => $"{classColor("Player")}.{funcColor("Turn")}({enumColor("Turnstage1")}, {enumColor("Turnstage2")}, ...)",
                "MoveTo" => $"{classColor("Piece")}.{propColor("route")}.{funcColor("MoveTo")}({classColor("Tile")} destination, {enumColor("MovementType")})",
                "Remove" => $"{funcColor("Remove")}({varColor("Variable")})",
                "Add" => $"{classColor("List")}.{funcColor("Add")}({varColor("Variable")})",
                "Move" => $"{classColor("List")}.{funcColor("Move")}({varColor("Variable")})",
                "Find" => $"{classColor("List")}.{funcColor("Find")}({varColor("Variable")})",
                "Roll" => $"{classColor("Dice")}.{funcColor("Roll")}()",
                "TryTurn" => $"{classColor("Player")}.{funcColor("TryTurn")}({enumColor("Turnstage1")}, {enumColor("Turnstage2")}, ...)",
                "Player()" => $"{classColor("Player")} player ({varColor("String")} name)",
                "Piece()" => $"{classColor("Piece")} piece ({classColor("Player")} player, PositionX, PositionY)",
                "Piece(PieceType)" => $"{classColor("Piece")}(PieceType) piece ({classColor("Player")} player, PositionX, PositionY)",
                "Dice()" => $"{classColor("Dice")} dice (Value1, Value2, ...)",
                string a when a.Contains("SelectPiece") => $"{enumColor("SelectPiece")}({classColor("Piece")} SelectedPiece)",
                string a when a.Contains("SelectTile") => $"{enumColor("SelectTile")}({classColor("Tile")} SelectedTile)",
                "CheckRule" => $"{enumColor("CheckRule")}",
                "all" => $"{classColor("List")}.all",
                "any" => $"{classColor("List")}.any",
                "none" => $"{classColor("List")}.none",
                "cancel" => $"{keyColor("cancel")}",
                "stop" => $"{keyColor("stop")}",
                string a when a.Contains("FUNC") => $"{funcColor(a.Replace("FUNC.", ""))}()",
                "@" => $"{classColor("Tile")}{propColor("@")}( )",
                "#" => "#" + $"{varColor("String")}",
                _ => ""
            };
        }
        public static string GetFuncDetails(string f)
        {
            return (f) switch
            {
                "EndTurn" => "Ends the turn of the given Player",
                "Turn" => $"Set the stages of the given player\n\n* Turnstage: {enumColor("SelectPiece")}, {enumColor("SelectTile")}, {enumColor("CheckRule")}, {funcColor("function call")}, {funcColor("input")}",
                "MoveTo" => $"Moves the given Piece to the given tile in it's Route with the given MovementType\n\n* MovementType: {enumColor("Step")}, {enumColor("Slide")}, {enumColor("Jump")}",
                "Remove" => "Delete the given variable",
                "Add" => "Add the given variable to the List",
                "Move" => "Move the given variable to the List",
                "Find" => $"Search for the given variable in the List\n\n* RESULT: {keyColor("true")} if the variable is present in the List; otherwise {keyColor("false")}",
                "Roll" => $"Randomly sets the {propColor("value")} of the given Dice to one of the values given at declaration",
                "TryTurn" => $"Simulate turn(s) of the given Player\n\n* Turnstage: {enumColor("SelectPiece")}, {enumColor("SelectTile")}, {enumColor("CheckRule")}, {funcColor("function call")}\n\n* RESULT: {keyColor("true")} if the turn(s) are succesfull; otherwise, {keyColor("false")}",
                "Player()" => "Creates Player object with the given name",
                "Piece()" => "Creates Piece object, assigns it to the given player and places at the given coordinates",
                "Piece(PieceType)" => "Creates Piece object of the given type, assigns it to the given player and places at the given coordinates",
                "Dice()" => "Creates a Dice object that can have the given values",
                string a when a.Contains("SelectPiece") => "Waits for a piece of the given player to be clicked, then stores it in the given Piece",
                string a when a.Contains("SelectTile") => "Waits for a tile to be clicked, then stores it in the given Tile",
                "CheckRule" => $"Calls the {funcColor("Rule")} function of the given player",
                "all" => $"Gets all the elements in the {classColor("List")}",
                "cancel" => $"Restarts the current Turnstage",
                "stop" => $"Exits the current {keyColor("repeat-until")} block",
                string a when a.Contains("FUNC") => $"Calls the function {funcColor(a.Replace("FUNC.", ""))}",
                "@" => $"Neighbor of the given {classColor("Tile")}\n\n* Options: {keyColor("N")} | {keyColor("E")} | {keyColor("S")} | {keyColor("W")} | {keyColor("NE")} | {keyColor("NW")} | {keyColor("SE")} | {keyColor("SW")}",
                "#" => "Displays the given message in Debug mode",
                _ => ""
            };
        }

        public static string enumColor(string s) => "<span style=\"color:#4FC1FF;\">" + s + "</span>";
        public static string classColor(string s) => "<span style=\"color:#4EC9B0;\">" + s + "</span>";
        public static string funcColor(string s) => "<span style=\"color:#DCDCAA;\">" + s + "</span>";
        public static string keyColor(string s) => "<span style=\"color:#C586C0;\">" + s + "</span>";
        public static string propColor(string s) => "<span style=\"color:#9CDCFE;\">" + s + "</span>";
        public static string varColor(string s) => "<span style=\"color:#569CD6;\">" + s + "</span>";
    }

    public enum Collection
    {
        ALL,
        ANY,
        NONE
    }


    public class ComplexList
    {
        public IList list = new List<object>();
        public Collection collection;

        public ComplexList(IList list, Collection collection)
        {
            this.list = list;
            this.collection = collection;
        }
    }

}
