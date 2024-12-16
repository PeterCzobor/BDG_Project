using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Assets.Language;
using Language;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

namespace Language
{

    class Function
    {
        public string caller;
        public string name;
        public Dictionary<string, object> LocVariables { get; } = new Dictionary<string, object>();
        public object localVar = null;
        public string thisID = null;

        public Function(string c, string n)
        {
            caller = c;
            name = n;
        }
    }

    public class Visitor : Combined1BaseVisitor<object>
    {
        public Dictionary<string, object> Variables { get; set; } = new Dictionary<string, object>();

        Dictionary<Function, Combined1Parser.FunctionBlockContext> Functions { get; set; } = new Dictionary<Function, Combined1Parser.FunctionBlockContext>();

        List<Function> funcRow = new List<Function>();
        int currentFunc = 0;

        System.Random rand = new System.Random();

        public bool circX = false;
        public bool circY = false;

        public bool hasDraw = false;

        public Visitor()
        {
            for (int i = 0; i < 100; i++)
                funcRow.Add(null);
        }

        List<Combined1Parser.BlockContext> phases = new List<Combined1Parser.BlockContext>();

        #region SIMPLE STRUCTURES
        public override object VisitLogStatement([NotNull] Combined1Parser.LogStatementContext context)
        {
            GameManager.DisplayLog(Visit(context.expression()).ToString(), false, context.Start.Line);
            return null;
        }

        public override object VisitPhase([NotNull] Combined1Parser.PhaseContext context)
        {
            if (context.block() != null)
            {
                phases.Add(context.block());
                if (context.INTEGER().GetText() == "1")
                    Visit(context.block());
            }
            else
            {
                Functions.Clear();

                Visit(phases[int.Parse(context.INTEGER().GetText()) - 1]);
            }
            return null;
        }

        public override object VisitIfBlock([NotNull] Combined1Parser.IfBlockContext context)
        {
            if ((bool)Visit(context.expression()))
                Visit(context.block());
            else if (context.elseifBlock() != null)
                Visit(context.elseifBlock());
            return null;
        }

        bool stop = false;
        public override object VisitRepeatUntil([NotNull] Combined1Parser.RepeatUntilContext context)
        {
            do
            {
                Visit(context.block());
            }
            while ((bool)Visit(context.expression()) && !stop);
            stop = false;
            return null;
        }
        #endregion

        #region STATEMENTS
        public override object VisitDeclaration([NotNull] Combined1Parser.DeclarationContext context)
        {
            var varName = context.ID().GetText();
            var value = new object();

            switch (context.type().GetText())
            {
                case "Player":
                    value = context.parameterList() != null ? new Player(Visit(context.parameterList())) : new Player();
                    break;
                case "Piece":
                    value = context.parameterList() != null ? new Piece(Visit(context.parameterList())) : new Piece();
                    if (context.pieceType() != null)
                    {
                        if (Variables.ContainsKey(context.pieceType().ID().GetText()) && Variables[context.pieceType().ID().GetText()] is List<Piece> l)
                            l.Add((Piece)value);
                        else
                        {
                            List<Piece> temp = new List<Piece>() { (Piece)value };
                            Variables[context.pieceType().ID().GetText()] = temp;
                        }
                    }
                    break;
                case "Tile":
                    value = context.parameterList() != null ? new Tile(Visit(context.parameterList())) : new Tile();
                    break;
                case "Dice":
                    value = context.parameterList() != null ? new Dice(Visit(context.parameterList())) : new Dice();
                    break;
                case "List":
                    value = new List<object>();
                    break;
            }

            if (funcRow[currentFunc] != null && context.type() != null)
            {
                Variables[varName + rand.Next().ToString()] = value;
            }
            if (funcRow[currentFunc] != null && !Variables.ContainsKey(varName))
                funcRow[currentFunc].LocVariables[varName] = value;
            else
                Variables[varName] = value;

            return null;
        }

        public override object VisitAssignment([NotNull] Combined1Parser.AssignmentContext context)
        {
            if (context.variable().ID() != null && context.variable().ChildCount == 1)
            {
                if (funcRow[currentFunc] != null && !Variables.ContainsKey(context.variable().ID().GetText()))
                    funcRow[currentFunc].LocVariables[context.variable().ID().GetText()] = Visit(context.expression());
                else
                    Variables[context.variable().ID().GetText()] = Visit(context.expression());
            }

            object left = Visit(context.variable());
            object right = Visit(context.expression());

            if (left is ComplexList list)
            {
                switch (list.collection)
                {
                    case Collection.ALL:
                        for (int i = 0; i < list.list.Count; i++)
                        {
                            if (list.list[i] is Variable vr)
                            {
                                vr.Setter(right);
                            }
                            else
                            {
                                list.list[i] = right;
                            }
                        }
                        break;
                }
            }
            else
            {
                if (left is Variable vl)
                {
                    vl.Setter(right);
                }
                else
                {
                    left = right;
                }
            }
            return null;
        }
        
        public override object VisitCancel([NotNull] Combined1Parser.CancelContext context)
        {
            if (Variables["CurrentPlayer"] is Player p)
                p.CancelStep();
            return null;
        }

        public override object VisitStop([NotNull] Combined1Parser.StopContext context)
        {
            stop = true;
            return null;
        }
        #endregion

        #region VARIABLES
        public object parentObject;
        public override object VisitVariable([NotNull] Combined1Parser.VariableContext context)
        {
            parentObject = null;
            if (funcRow[currentFunc] != null)
            {
                if (funcRow[currentFunc].thisID != null)
                    parentObject = Variables[funcRow[currentFunc].thisID];
                if (context.ID() != null && funcRow[currentFunc].LocVariables.ContainsKey(context.ID().GetText()))
                    parentObject = funcRow[currentFunc].LocVariables[context.ID().GetText()];
                if (context.ID() != null && Variables.ContainsKey(context.ID().GetText()))
                    parentObject = Variables[context.ID().GetText()];
            }
            else
            {
                if (context.ID() != null && Variables.ContainsKey(context.ID().GetText()))
                    parentObject = Variables[context.ID().GetText()];
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
                    for (int j = 0; j < list.list.Count; j++)
                    {
                        parentObject = list.list[j];
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
            if (parentObject is Variable var)
                parentObject = var.Getter();
            switch (context.GetText())
            {
                case "posX":
                    return new Variable(parentObject, "posX");
                case "posY":
                    return new Variable(parentObject, "posY");
                case "pieces":
                    if (parentObject is Tile t_Pieces)
                    {
                        List<Piece> tempPieces = new List<Piece>();
                        foreach (var item in Variables)
                            if (item.Value is Piece p && p.posX == t_Pieces.posX && p.posY == t_Pieces.posY)
                                tempPieces.Add(p);
                        return tempPieces;
                    }
                    if (parentObject is Player p_Pieces)
                        return p_Pieces.pieces;
                    break;
                case "tiles":
                    List<object> temp = new List<object>();
                    foreach (var item in Variables)
                        if (item.Value is Tile t)
                            temp.Add(t);
                    return temp;
                case "empty":
                    if(parentObject is Tile t_empty)
                    {
                        List<Piece> tempPieces = new List<Piece>();
                        foreach (var item in Variables)
                            if (item.Value is Piece p && p.posX == t_empty.posX && p.posY == t_empty.posY)
                                tempPieces.Add(p);
                        return tempPieces.Count == 0;
                    }
                    break;
                case "player":
                    if (parentObject is Piece p_Player)
                        return p_Player.player;
                    break;
                case "players":
                    List<object> tempP = new List<object>();
                    foreach (var item in Variables)
                        if (item.Value is Player p && item.Key != "CurrentPlayer")
                            tempP.Add(p);
                    return tempP;
                case "color":
                    return new Variable(parentObject, "color");
                case "route":
                    return new Variable(parentObject, "route");
                case "routePosition":
                    return new Variable(parentObject, "routePosition");
                case "texture":
                    return new Variable(parentObject, "texture");
                case "type":
                    if (parentObject is Piece p_Type)
                        foreach (var item in Variables)
                            if (item.Value is List<Piece> lp && lp.Contains(p_Type))
                                return item.Key;
                    break;
                case "value":
                    return new Variable(parentObject, "value");
                case "active":
                    return new Variable(parentObject, "active");
                case "text":
                    return new Variable(parentObject, "text");
            }
            return null;
        }

        public override object VisitTile([NotNull] Combined1Parser.TileContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));

            foreach (var item in Variables)
            {
                if (item.Value is Tile t)
                {
                    if (Convert.ToInt32(left) < GameManager.GetMinX())
                        if (circX)
                            left = GameManager.GetMaxX() - (Convert.ToInt32(left) - GameManager.GetMinX() + 1);
                        else
                            return null;
                    if (Convert.ToInt32(left) > GameManager.GetMaxX())
                        if (circX)
                            left = GameManager.GetMinX() + (Convert.ToInt32(left) - GameManager.GetMaxX() - 1);
                        else
                            return null;
                    if (Convert.ToInt32(right) < GameManager.GetMinY())
                        if (circY)
                            left = GameManager.GetMaxY() - (Convert.ToInt32(right) - GameManager.GetMinY() + 1);
                        else
                            return null;
                    if (Convert.ToInt32(right) > GameManager.GetMaxY())
                        if (circY)
                            left = GameManager.GetMinY() + (Convert.ToInt32(right) - GameManager.GetMaxY() - 1);
                        else
                            return null;
                    if (t.posX == Convert.ToInt32(left) && t.posY == Convert.ToInt32(right))
                        return t;
                }
            }
            return null;
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
            if (parentObject is Variable var)
                parentObject = var.Getter();

            if (parentObject is IList list)
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
                        return list.Count;
                }
            }
            if (parentObject is ComplexList clist)
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
                        return clist.list.Count;
                }
            }
            return null;
        }

        public override object VisitElement([NotNull] Combined1Parser.ElementContext context)
        {
            if (parentObject is IList elist)
            {
                if (elist.Count == 0)
                    return null;
                return elist[Math.Min(Convert.ToInt32(Visit(context.expression())), elist.Count - 1)];
            }
            if (parentObject is Variable var)
            {
                return new Variable(var.nonNumeric, var.numeric + (Convert.ToInt32(Visit(context.expression()))).ToString());
            }
            return null;
        }

        #endregion

        #region FUNCTIONS
        public override object VisitFunctionBlock([NotNull] Combined1Parser.FunctionBlockContext context)
        {
            if (context.declaration() != null)
            {
                funcRow[currentFunc].LocVariables[context.declaration().ID().GetText()] = funcRow[currentFunc].localVar;
            }
            Visit(context.block());

            return null;
        }

        public override object VisitFunctionCall([NotNull] Combined1Parser.FunctionCallContext context)
        {
            if (context.variable() != null)
            {
                switch (context.functionName().GetText())
                {
                    case "Turn":
                        if (Visit(context.variable()) is Player p_Turn)
                        {
                            TryTurn = false;
                            p_Turn.Turn(context.parameterList().expression().Select(Visit).ToArray());
                        }
                        return null;
                    case "EndTurn":
                        if (Visit(context.variable()) is Player p_EndTurn)
                            p_EndTurn.EndTurn();
                        return null;
                    case "MoveTo":
                        if (Visit(context.variable()) is Piece p_Step)
                            p_Step.Step(context.parameterList().expression().Select(Visit).ToArray());
                        return null;
                    case "TryTurn":
                        if (Visit(context.variable()) is Player p_TryTurn)
                        {
                            TryTurn = true;
                            return p_TryTurn.TryTurn(context.variable().ID().GetText(), context.parameterList().expression().Select(Visit).ToArray());
                        }
                        return null;
                }
            }
            if (context.functionName().GetText() == "Remove")
            {
                object subject = Visit(context.parameterList().expression(0));
                if (subject == null)
                    return null;
                List<string> Keys = new List<string>();
                foreach (var pair in Variables)
                {
                    if (Equals(pair.Value, subject))
                    {
                        Keys.Add(pair.Key);
                    }
                }

                if (subject is List<object> list)
                {
                    foreach (var item in list)
                    {
                        if (item is Piece pi)
                        {
                            pi.player.pieces.Remove(pi);
                            Variables[Variables.FirstOrDefault(x => x.Value == pi).Key] = null; ;
                        }
                    }
                    foreach (var elements in Variables)
                    {
                        if (elements.Value is List<object> lst && lst.Contains(list))
                            lst.Remove(list);
                    }
                    list.Clear();
                }

                foreach (string s in Keys)
                {
                    if (subject is Piece p)
                    {
                        p.player.pieces.Remove(p);
                    }
                    Variables[s] = null;
                }
                return null;
            }
            if (context.functionName().GetText() == "Add")
            {

                if (Visit(context.variable()) is List<object> list)
                {
                    if (Visit(context.parameterList().expression(0)) is ComplexList llist)
                    {
                        list.AddRange(llist.list);
                    }
                    else
                        list.Add(Visit(context.parameterList().expression(0)));
                }

                return null;
            }
            if (context.functionName().GetText() == "Move")
            {
                if (Visit(context.variable()) is List<object> list)
                {
                    if (Visit(context.parameterList().expression(0)) is ComplexList llist)
                    {
                        list.AddRange(llist.list);

                        foreach (var elements in Variables)
                        {
                            if (elements.Value is List<object> lst && lst.Contains(llist))
                            {
                                lst.Remove(llist);
                                llist.list.Clear();
                            }
                        }
                    }
                    else
                        list.Add(Visit(context.parameterList().expression(0)));
                }

                return null;
            }
            if (context.functionName().GetText() == "Find")
            {
                if (Visit(context.variable()) is List<object> list && list.Contains(Visit(context.parameterList().expression(0))))
                    return true;
                return false;
            }
            if (context.functionName().GetText() == "MoveTo")
            {
                if (funcRow[currentFunc] != null && Variables[funcRow[currentFunc].thisID] is Piece p)
                    p.Step(context.parameterList().expression().Select(Visit).ToArray());
                return null;
            }

            if (context.variable() != null)
            {
                object caller = Visit(context.variable());
                if (caller is ComplexList lo)
                {
                    switch (lo.collection)
                    {
                        case Collection.ALL:
                            currentFunc++;
                            for (int i_all = 0; i_all < lo.list.Count; i_all++)
                            {
                                foreach (KeyValuePair<Function, Combined1Parser.FunctionBlockContext> item in Functions)
                                {
                                    if (item.Key.caller != null && Variables.ContainsKey(item.Key.caller) && Variables[item.Key.caller] == lo.list[i_all] && item.Key.name == context.functionName().GetText())
                                    {
                                        object locVar = null;
                                        if (context.parameterList().expression(0) != null)
                                            locVar = Visit(context.parameterList().expression(0));
                                        funcRow[currentFunc] = item.Key;
                                        funcRow[currentFunc].localVar = locVar;
                                        funcRow[currentFunc].thisID = item.Key.caller;
                                        funcRow[currentFunc].LocVariables["RESULT"] = false;

                                        Visit(item.Value);

                                        Variables["return"] = funcRow[currentFunc].LocVariables["RESULT"];

                                        funcRow[currentFunc].LocVariables.Clear();
                                        funcRow[currentFunc].thisID = null;
                                        funcRow[currentFunc].localVar = null;
                                        funcRow[currentFunc] = null;
                                        break;
                                    }
                                }
                            }
                            currentFunc--;
                            return null;
                    }
                }
                else
                {
                    currentFunc++;
                    foreach (KeyValuePair<Function, Combined1Parser.FunctionBlockContext> item in Functions)
                    {
                        if (item.Key.caller != null && Variables.ContainsKey(item.Key.caller) && Variables[item.Key.caller] == caller && item.Key.name == context.functionName().GetText())
                        {
                            object locVar = null;
                            if (context.parameterList().expression(0) != null)
                                locVar = Visit(context.parameterList().expression(0));
                            funcRow[currentFunc] = item.Key;
                            funcRow[currentFunc].localVar = locVar;
                            funcRow[currentFunc].thisID = item.Key.caller;
                            funcRow[currentFunc].LocVariables["RESULT"] = false;

                            Visit(item.Value);

                            Variables["return"] = funcRow[currentFunc].LocVariables["RESULT"];

                            funcRow[currentFunc].LocVariables.Clear();
                            funcRow[currentFunc].thisID = null;
                            funcRow[currentFunc].localVar = null;
                            funcRow[currentFunc] = null;

                            break;
                        }
                    }
                    currentFunc--;
                    return null;
                }
            }

            currentFunc++;
            foreach (KeyValuePair<Function, Combined1Parser.FunctionBlockContext> item in Functions)
            {
                if (item.Key.name == context.functionName().GetText())
                {
                    object locVar = null;
                    if (context.parameterList().expression(0) != null)
                        locVar = Visit(context.parameterList().expression(0));
                    funcRow[currentFunc] = item.Key;
                    funcRow[currentFunc].localVar = locVar;
                    funcRow[currentFunc].LocVariables["RESULT"] = false;

                    Visit(item.Value);

                    Variables["return"] = funcRow[currentFunc].LocVariables["RESULT"];

                    funcRow[currentFunc].LocVariables.Clear();
                    funcRow[currentFunc].thisID = null;
                    funcRow[currentFunc].localVar = null;
                    funcRow[currentFunc] = null;
                    break;
                }
            }
            currentFunc--;
            return null;
        }

        public override object VisitFunctionBody([NotNull] Combined1Parser.FunctionBodyContext context)
        {
            if (Visit(context.variable()) is Player pl)
            {
                var value = context.functionBlock();

                Functions[new Function(Variables.FirstOrDefault(x => x.Value == pl).Key, context.functionName().GetText())] = value;

                return null;
            }
            else if (Visit(context.variable()) is ComplexList list)
            {
                var value = context.functionBlock();
                foreach (var item in list.list)
                    Functions[new Function(Variables.FirstOrDefault(x => x.Value == item).Key, context.functionName().GetText())] = value;

                return null;
            }
            else if (Visit(context.variable()) is IList pls)
            {
                var value = context.functionBlock();
                foreach (var item in pls)
                    Functions[new Function(Variables.FirstOrDefault(x => x.Value == item).Key, context.functionName().GetText())] = value;

                return null;
            }
            else if (Visit(context.variable()) is Piece pi)
            {
                var value = context.functionBlock();

                Functions[new Function(Variables.FirstOrDefault(x => x.Value == pi).Key, context.functionName().GetText())] = value;

                return null;
            }
            else if (context.functionName().GetText() == "DrawCondition")
            {
                hasDraw = true;

                var value = context.functionBlock();

                Functions[new Function(null, context.functionName().GetText())] = value;

                return null;
            }
            else
            {
                var value = context.functionBlock();

                Functions[new Function(null, context.functionName().GetText())] = value;

                return null;
            }
        }
        #endregion

        #region EXPRESSIONS
        public override object VisitVarExpression([NotNull] Combined1Parser.VarExpressionContext context)
        {
            object variable = Visit(context.variable());
            if (variable is Variable v)
                return v.Getter();
            else
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

            if (context.color() != null)
                return context.color().STRING().GetText().Replace("\"", "");

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

            return (context.addOp().GetText()) switch
            {
                "+" => VisitorHelper.Add(left, right),
                "-" => VisitorHelper.Sub(left, right),
                _  => null
            };
        }

        public override object VisitCompExpression([NotNull] Combined1Parser.CompExpressionContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));

            if (left is ComplexList llist)
            {
                switch (llist.collection)
                {
                    case Collection.ALL:
                        for (int i = 0; i < llist.list.Count; i++)
                            if (!Compare(llist.list[i], right, context.compareOp()))
                                return false;
                        return true;
                    case Collection.ANY:
                        for (int i = 0; i < llist.list.Count; i++)
                            if (Compare(llist.list[i], right, context.compareOp()))
                                return true;
                        return false;
                    case Collection.NONE:
                        for (int i = 0; i < llist.list.Count; i++)
                            if (Compare(llist.list[i], right, context.compareOp()))
                                return false;
                        return true;
                }
            }
            return Compare(left, right, context.compareOp());
        }

        bool Compare(object left, object right, Combined1Parser.CompareOpContext context)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            return (context.GetText()) switch
            {
                "==" => Equals(left, right),
                "!=" => !Equals(left, right),
                ">" => VisitorHelper.Great(left, right),
                "<" => VisitorHelper.Small(left, right),
                ">=" => VisitorHelper.GreatEqu(left, right),
                "<=" => VisitorHelper.SmallEqu(left, right),
                _ => false
            };
        }

        public override object VisitBoolExpression([NotNull] Combined1Parser.BoolExpressionContext context)
        {
            switch (context.boolOp().GetText())
            {
                case "AND":
                    bool left = (bool)Visit(context.expression(0));
                    if (left == false)
                        return false;
                    return left && (bool)Visit(context.expression(1));
                case "OR":
                    return (bool)Visit(context.expression(0)) || (bool)Visit(context.expression(1));
            }
            return null;
        }
        
        public override object VisitNegExpression([NotNull] Combined1Parser.NegExpressionContext context)
        {
            object subject = Visit(context.expression());
            if (subject is int i)
                return -1 * i;
            else if (subject is double f)
                return -1 * f;
            return null;
        }

        public override object VisitNotExpression([NotNull] Combined1Parser.NotExpressionContext context)
        {
            if (Visit(context.expression()) is bool b)
                return !b;
            return null;
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
            return null;
        }

        public override object VisitInputExpression([NotNull] Combined1Parser.InputExpressionContext context)
        {
            List<object> list = new List<object>() { context.input().inputTypes().GetText(), Visit(context.input().expression()) };
            return list;
        }

        bool TryTurn = false;
        public override object VisitTurnStagesExp([NotNull] Combined1Parser.TurnStagesExpContext context)
        {
            switch (context.GetText())
            {
                case string a when a.Contains("SelectPiece"):
                    return "SelectPiece";
                case string a when a.Contains("SelectTile"):
                    return "SelectTile";
                case string a when a.Contains("Rule"):
                    if(!TryTurn)
                        return "Rule";
                    List<object> list = new List<object>();
                    if (context.turnStages().functionCall().variable() != null)
                        list.Add(Visit(context.turnStages().functionCall().variable()));
                    list.Add("Rule");
                    if (context.turnStages().functionCall().parameterList().expression() != null)
                        foreach (Combined1Parser.ExpressionContext item in context.turnStages().functionCall().parameterList().expression())
                            list.Add(Visit(item));
                    return list;
            }
            if (context.turnStages().functionCall() != null)
            {
                List<object> list = new List<object>();
                if (context.turnStages().functionCall().variable() != null)
                    return Visit(context.turnStages().functionCall().variable());
                list.Add(context.turnStages().functionCall().functionName().GetText());
                foreach (Combined1Parser.ExpressionContext item in context.turnStages().functionCall().parameterList().expression())
                    list.Add(Visit(item));
                return list;
            }
            return null;
        }

        public override object VisitPieceMoveTypes([NotNull] Combined1Parser.PieceMoveTypesContext context)
        {
            return context.GetText();
        }
        #endregion
    }
}
