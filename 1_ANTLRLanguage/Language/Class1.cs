using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Language;

namespace Language
{

    /*class Function
    {
        public object caller;
        public string name;

        public Function(object c, string n)
        {
            caller = c;
            name = n;
        }
    }*/

    public class Visitorr : Combined1BaseVisitor<object>
    {
        public Dictionary<string, object> Variables { get; set; } = new Dictionary<string, object>();

        public Dictionary<string, object> LocVariables { get; } = new Dictionary<string, object>();

        Dictionary<Function, Combined1Parser.FunctionBlockContext> Functions { get; } = new Dictionary<Function, Combined1Parser.FunctionBlockContext>();

        object localVar = null;

        string thisID = null;

        bool inFunc = false;

        List<object> Outs = new List<object>();
        List<object> Locals = new List<object>();
        List<string> IDs = new List<string>();

        List<Combined1Parser.BlockContext> phases = new List<Combined1Parser.BlockContext>();

        public override object VisitDeclaration([NotNull] Combined1Parser.DeclarationContext context)
        {
            var varName = context.ID().GetText();
            var value = new object();

            if (context.type() != null)
            {
                switch (context.type().GetText())
                {
                    case "Player":
                        value = context.constructor() != null ? new Player(Visit(context.constructor())) : new Player();
                        break;
                    case "Piece":
                        value = context.constructor() != null ? new Piece(Visit(context.constructor())) : new Piece();
                        if (context.pieceType() != null)
                        {
                            if (Variables.ContainsKey(context.pieceType().ID().GetText()) && Variables[context.pieceType().ID().GetText()] is List<Piece> l)
                                l.Add((Piece)value);
                            else
                            {
                                List<Piece> temp = new List<Piece>();
                                temp.Add((Piece)value);
                                Variables[context.pieceType().ID().GetText()] = temp;
                            }
                        }
                        break;
                    case "Tile":
                        value = context.constructor() != null ? new Tile(Visit(context.constructor())) : new Tile();
                        break;
                    case "Dice":
                        value = context.constructor() != null ? new Dice(Visit(context.constructor())) : new Dice();
                        break;
                }
            }
            else
                value = Visit(context.expression());


            if (inFunc && !Variables.ContainsKey(varName))
                LocVariables[varName] = value;
            Variables[varName] = value;

            return null;
        }

        public override object VisitAssignment([NotNull] Combined1Parser.AssignmentContext context)
        {
            var varName = thisID;
            if (context.variable().ID() != null)
                varName = context.variable().ID().GetText();

            if (varName == "FUNC")
            {
                SetBoardType(context, 0);
            }

            if (context.variable().ID() == null && context.variable().child(0).functionCall() != null)
            {
                Visit(context.variable().child(0).functionCall());
                return null;
            }

            if (context.variable().child(0) != null)
            {
                if (Variables[varName] is Piece pi)
                {
                    SetPieceType(context, 0, pi);
                }
                if (Variables[varName] is Player pl)
                {
                    SetPlayerType(context, 0, pl);
                }
                if (Variables[varName] is Tile ti)
                {
                    SetTileType(context, 0, ti);
                }
                if (Variables[varName] is List<Piece> lp)
                {
                    foreach (Piece p in lp)
                        SetPieceType(context, 0, p);
                }
            }
            else
                Variables[varName] = Visit(context.expression());

            return null;
        }

        void SetBoardType([NotNull] Combined1Parser.AssignmentContext context, int index)
        {
            /*if (context.variable().child(index).functionBody() != null)
			{
				var value = context.variable().child(index).functionBody().functionBlock();

				Functions[new Function(null, context.variable().child(index).functionBody().functionName().GetText())] = value;

				return;
			}*/
            if (context.variable().child(index).functionCall() != null)
            {
                if (inFunc)
                {
                    Outs.Add(Variables["OUT"]);
                    Locals.Add(localVar);
                    IDs.Add(thisID);
                }

                Variables["OUT"] = false;

                if (context.variable().child(index).functionCall().constructor().expression().Length != 0)
                    localVar = Visit(context.variable().child(index).functionCall().constructor().expression(0));
                thisID = null;
                foreach (KeyValuePair<Function, Combined1Parser.FunctionBlockContext> item in Functions)
                {
                    if (item.Key.name == context.variable().child(index).functionCall().functionName().GetText())
                    {
                        Visit(item.Value);

                        if (Outs.Count != 0)
                        {
                            Variables["OUT"] = Outs[Outs.Count - 1];
                            localVar = Locals[Locals.Count - 1];
                            thisID = IDs[IDs.Count - 1];
                            Variables["t"] = localVar;
                        }

                        break;
                    }
                }

                return;
            }
        }

        void SetPieceType([NotNull] Combined1Parser.AssignmentContext context, int index, Piece pi)
        {
            /*if (context.variable().child(index).functionBody() != null)
			{
				var value = context.variable().child(index).functionBody().functionBlock();

				Functions[new Function(pi, context.variable().child(index).functionBody().functionName().GetText())] = value;

				return;
			}*/
            if (context.variable().child(index).functionCall() != null)
            {

                if (context.variable().child(index).functionCall().functionName().GetText() == "Remove")
                {
                    object subject = Visit(context.variable().child(index).functionCall().constructor().expression(0));
                    string Key = Variables.FirstOrDefault(x => x.Value == subject).Key;
                    if (subject is Piece p)
                        p.player.pieces.Remove(p);
                    //Variables.Remove(Key);

                    return;
                }
                if (context.variable().child(index).functionCall().functionName().GetText() == "Step")
                {
                    {
                        pi.Step((int)Visit(context.variable().child(index).functionCall().constructor().expression(0)));
                        return;
                    }
                }

                if (inFunc)
                {
                    Outs.Add(Variables["OUT"]);
                    Locals.Add(localVar);
                    IDs.Add(thisID);
                }

                Variables["OUT"] = false;

                if (context.variable().child(index).functionCall().constructor().expression().Length != 0)
                    localVar = Visit(context.variable().child(index).functionCall().constructor().expression(0));
                thisID = Variables.FirstOrDefault(x => x.Value == pi).Key;
                foreach (KeyValuePair<Function, Combined1Parser.FunctionBlockContext> item in Functions)
                {
                    if (item.Key.caller == pi && item.Key.name == context.variable().child(index).functionCall().functionName().GetText())
                    {
                        Visit(item.Value);

                        if (Outs.Count != 0)
                        {
                            Variables["OUT"] = Outs[Outs.Count - 1];
                            localVar = Locals[Locals.Count - 1];
                            thisID = IDs[IDs.Count - 1];
                            Variables["t"] = localVar;
                        }

                        break;
                    }
                }

                return;
            }
            switch (context.variable().child(index).property().pieceProp().GetText())
            {
                case "PosX":
                    pi.posX = (int)Visit(context.expression());
                    break;
                case "PosY":
                    pi.posY = (int)Visit(context.expression());
                    break;
                case "player":
                    pi.player = (Player)Visit(context.expression());
                    break;
                case "Color":
                    pi.color = (string)Visit(context.expression());
                    break;
                case "Texture":
                    pi.texture = (string)Visit(context.expression());
                    break;
                case "Route":
                    if (context.variable().child().Length > index + 1 && context.variable().child(index + 1).element() != null)
                    {
                        if (context.variable().child().Length > index + 2 && pi.route.Count > (int)Visit(context.variable().child(index + 1).element().expression()))
                            SetTileType(context, index + 2, pi.route[(int)Visit(context.variable().child(index + 1).element().expression())]);
                        else if (pi.route.Count > (int)Visit(context.variable().child(index + 1).element().expression()))
                            pi.route[(int)Visit(context.variable().child(index + 1).element().expression())] = (Tile)Visit(context.expression());
                    }
                    else
                        pi.route = (List<Tile>)Visit(context.expression());
                    break;
                case "RoutePosition":
                    pi.RoutePosition = (int)Visit(context.expression());
                    break;
            }
        }

        void SetPlayerType([NotNull] Combined1Parser.AssignmentContext context, int index, Player pl)
        {
            /*if (context.variable().child(index).functionBody() != null)
			{
				var value = context.variable().child(index).functionBody().functionBlock();

				Functions[new Function(pl, context.variable().child(index).functionBody().functionName().GetText())] = value;

				return;
			}*/
            if (context.variable().child(index).functionCall() != null)
            {
                if (context.variable().child(index).functionCall().functionName().GetText() == "Remove")
                {
                    object subject = Visit(context.variable().child(index).functionCall().constructor().expression(0));
                    string Key = Variables.FirstOrDefault(x => x.Value == subject).Key;
                    if (subject is Piece p)
                        p.player.pieces.Remove(p);
                    //Variables.Remove(Key);

                    return;
                }
                if (context.variable().child(index).functionCall().functionName().GetText() == "Turn")
                {
                    pl.Turn(context.variable().child(index).functionCall().constructor().expression().Select(Visit).ToArray());
                    return;
                }

                if (inFunc)
                {
                    Outs.Add(Variables["OUT"]);
                    Locals.Add(localVar);
                    IDs.Add(thisID);
                }

                Variables["OUT"] = false;

                if (context.variable().child(index).functionCall().constructor().expression().Length != 0)
                    localVar = Visit(context.variable().child(index).functionCall().constructor().expression(0));
                thisID = Variables.FirstOrDefault(x => x.Value == pl).Key;
                foreach (KeyValuePair<Function, Combined1Parser.FunctionBlockContext> item in Functions)
                {
                    if (item.Key.caller == pl && item.Key.name == context.variable().child(index).functionCall().functionName().GetText())
                    {
                        Visit(item.Value);

                        if (Outs.Count != 0)
                        {
                            Variables["OUT"] = Outs[Outs.Count - 1];
                            localVar = Locals[Locals.Count - 1];
                            thisID = IDs[IDs.Count - 1];
                            Variables["t"] = localVar;
                        }

                        break;
                    }
                }

                return;
            }
            switch (context.variable().child(index).property().playerProp().GetText())
            {
                case "pieces":
                    if (context.variable().child(index + 1).collection() != null)
                    {
                        switch (context.variable().child(index + 1).collection().GetText())
                        {
                            case "all":
                                //if (context.variable().child(index) != null)
                                {
                                    foreach (Piece p in pl.pieces)
                                        SetPieceType(context, index + 2, p);
                                }
                                break;
                        }
                    }
                    else
                        pl.pieces = (List<Piece>)Visit(context.expression());
                    break;
            }
        }

        void SetTileType([NotNull] Combined1Parser.AssignmentContext context, int index, Tile ti)
        {
            if (context.variable().child(index).property() == null)
            {
                ti = (Tile)Visit(context.expression());
                return;
            }
            switch (context.variable().child(index).property().GetText())
            {
                case "PosX":
                    ti.posX = (int)Visit(context.expression());
                    break;
                case "PosY":
                    ti.posY = (int)Visit(context.expression());
                    break;
                case "pieces":
                    if (context.variable().child().Length > index + 2 && context.variable().child(index + 1).element() != null)
                        if (ti.pieces.Count > (int)Visit(context.variable().child(index + 1).element().expression()))
                            SetPieceType(context, index + 2, ti.pieces[(int)Visit(context.variable().child(index + 1).element().expression())]);
                    break;
            }
        }


        object GetPieceType([NotNull] Combined1Parser.VariableContext context, int index, Piece pi)
        {
            /*if (context.variable().child(index).functionBody() != null)
			{
				return Functions[new Function(pi, context.variable().child(index).functionBody().functionName().GetText())];
			}*/
            if (context.child(index).functionCall() != null)
            {
                if (context.child(index).functionCall().functionName().GetText() == "Remove")
                {
                    object subject = Visit(context.child(index).functionCall().constructor().expression(0));
                    string Key = Variables.FirstOrDefault(x => x.Value == subject).Key;
                    if (subject is Piece p)
                        p.player.pieces.Remove(p);
                    //Variables.Remove(Key);

                    return null;
                }

                if (inFunc)
                {
                    Outs.Add(Variables["OUT"]);
                }

                Variables["OUT"] = false;

                if (context.child(index).functionCall().constructor().expression().Length != 0)
                    localVar = Visit(context.child(index).functionCall().constructor().expression(0));
                thisID = Variables.FirstOrDefault(x => x.Value == pi).Key;
                foreach (KeyValuePair<Function, Combined1Parser.FunctionBlockContext> item in Functions)
                {
                    if (item.Key.caller == pi && item.Key.name == context.child(index).functionCall().functionName().GetText())
                    {
                        Visit(item.Value);

                        if (Outs.Count != 0)
                            Variables["OUT"] = Outs[Outs.Count - 1];

                        break;
                    }
                }

                return Variables["OUT"];
            }
            switch (context.child(index).property().pieceProp().GetText())
            {
                case "PosX":
                    return pi.posX;
                case "PosY":
                    return pi.posY;
                case "player":
                    return pi.player;
                case "Color":
                    return pi.color;
                case "Texture":
                    return pi.texture;
                case "RoutePosition":
                    return pi.RoutePosition;
                case "Route":
                    if (context.child().Length > index + 2 && context.child(index + 1).element() != null)
                        if (pi.route.Count > (int)Visit(context.child(index + 1).element().expression()))
                            return GetTileType(context, index + 2, pi.route[(int)Visit(context.child(index + 1).element().expression())]);
                    return pi.route;
                case "Type":
                    foreach (var item in Variables)
                    {
                        if (item.Value is List<Piece> lp && lp.Contains(pi))
                        {
                            return item.Key;
                        }
                    }
                    break;

            }
            return pi;
        }

        object GetPlayerType([NotNull] Combined1Parser.VariableContext context, int index, Player pl)
        {

            switch (context.child(index).property().playerProp().GetText())
            {
                case "pieces":
                    if (context.child().Length > index + 2)
                    {
                        if (context.child(index + 1).collection() != null)
                        {
                            switch (context.child(index + 1).collection().GetText())
                            {
                                case "all":
                                    //if (context.variable().child(index) != null)
                                    {
                                        List<object> temp1 = new List<object>();
                                        temp1.Add("all");
                                        foreach (Piece p in pl.pieces)
                                            temp1.Add(GetPieceType(context, index + 2, p));
                                        return temp1;
                                    }
                                case "any":
                                    List<object> temp2 = new List<object>();
                                    temp2.Add("any");
                                    foreach (Piece p in pl.pieces)
                                        temp2.Add(GetPieceType(context, index + 2, p));
                                    return temp2;
                                case "none":
                                    List<object> temp3 = new List<object>();
                                    temp3.Add("none");
                                    foreach (Piece p in pl.pieces)
                                        temp3.Add(GetPieceType(context, index + 2, p));
                                    return temp3;
                            }
                            break;
                        }
                        break;
                    }
                    else
                        return pl.pieces;
            }
            return pl;

        }

        object GetTileType([NotNull] Combined1Parser.VariableContext context, int index, Tile ti)
        {
            switch (context.child(index).property().GetText())
            {
                case "PosX":
                    return ti.posX;
                case "PosY":
                    return ti.posY;
                case "pieces":
                    if (context.child().Length > index + 2)
                    {
                        if (context.child(index + 1).element() != null)
                            if (context.child().Length > index + 2 && ti.pieces.Count > (int)Visit(context.child(index + 1).element().expression()))
                                return GetPieceType(context, index + 2, ti.pieces[(int)Visit(context.child(index + 1).element().expression())]);
                        if (context.child(index + 1).collection() != null)
                        {
                            switch (context.child(index + 1).collection().GetText())
                            {
                                case "all":
                                    List<object> temp1 = new List<object>();
                                    temp1.Add("all");
                                    foreach (Piece p in ti.pieces)
                                        temp1.Add(GetPieceType(context, index + 2, p));
                                    return temp1;
                                case "any":
                                    List<object> temp2 = new List<object>();
                                    temp2.Add("any");
                                    foreach (Piece p in ti.pieces)
                                        temp2.Add(GetPieceType(context, index + 2, p));
                                    return temp2;
                                case "none":
                                    List<object> temp3 = new List<object>();
                                    temp3.Add("none");
                                    foreach (Piece p in ti.pieces)
                                        temp3.Add(GetPieceType(context, index + 2, p));
                                    return temp3;
                            }
                            break;
                        }
                    }
                    else if (context.child().Length > index + 1)
                    {
                        if (context.child(index + 1).element() != null)
                            if (ti.pieces.Count > (int)Visit(context.child(index + 1).element().expression()))
                                return ti.pieces[(int)Visit(context.child(index + 1).element().expression())];
                    }
                    else
                        return ti.pieces.Count;
                    break;
            }
            return null;
        }

        object GetDiceType([NotNull] Combined1Parser.VariableContext context, int index, Dice di)
        {
            switch (context.child(index).property().diceProp().GetText())
            {
                case "value":
                    return di.value;
            }
            return di;
        }



        public override object VisitConstructor([NotNull] Combined1Parser.ConstructorContext context)
        {
            var args = context.expression().Select(Visit).ToArray();

            return args;
        }

        public override object VisitVariable([NotNull] Combined1Parser.VariableContext context)
        {
            var varName = thisID;
            if (context.ID() != null)
                varName = context.ID().GetText();

            if (context.expression().Length == 2)
            {
                foreach (var item in Variables)
                {
                    if (item.Value is Tile t)
                    {
                        if ((int)Visit(context.expression(0)) < 0 || (int)Visit(context.expression(1)) < 0 || (int)Visit(context.expression(0)) > Manager.GetMaxX() || (int)Visit(context.expression(1)) > Manager.GetMaxY())
                            return null;
                        if (t.posX == (int)Visit(context.expression(0)) && t.posY == (int)Visit(context.expression(1)))
                        {
                            if (context.child().Length == 0)
                                return t;
                            else
                            {
                                varName = item.Key;
                                break;
                            }
                        }
                    }
                }
            }

            if (context.child(0) != null)
            {
                if (Variables[varName] is Piece pi)
                {
                    return GetPieceType(context, 0, pi);
                }
                if (Variables[varName] is Player pl)
                {
                    return GetPlayerType(context, 0, pl);
                }
                if (Variables[varName] is Tile ti)
                {
                    return GetTileType(context, 0, ti);
                }
                if (Variables[varName] is Dice di)
                {
                    return GetDiceType(context, 0, di);
                }
                if (Variables[varName] is List<Piece> lp)
                {
                    foreach (Piece p in lp)
                        GetPieceType(context, 0, p);
                }
            }
            if (Variables.ContainsKey(varName))
                return Variables[varName];
            else
                return varName;
        }

        public override object VisitVarExpression([NotNull] Combined1Parser.VarExpressionContext context)
        {
            /*var varName = thisID;
			if (context.variable().ID() != null)
				varName = context.variable().ID().GetText();

			if (context.variable().expression().Length == 2)
			{
				foreach (var item in Variables)
				{
					if (item.Value is Tile t)
					{
						if (t.posX == (int)Visit(context.variable().expression(0)) && t.posY == (int)Visit(context.variable().expression(1)))
						{
							if (context.variable().child().Length == 0)
								return t;
							else
							{
								varName = item.Key;
								break;
							}
						}
					}
				}
			}

			if (context.variable().child(0) != null)
			{
				if (Variables[varName] is Piece pi)
				{
					return GetPieceType(context, 0, pi);
				}
				if (Variables[varName] is Player pl)
				{
					return GetPlayerType(context, 0, pl);
				}
				if (Variables[varName] is Tile ti)
				{
					return GetTileType(context, 0, ti);
				}
				if (Variables[varName] is Dice di)
				{
					return GetDiceType(context, 0, di);
				}
				if (Variables[varName] is List<Piece> lp)
				{
					foreach (Piece p in lp)
						GetPieceType(context, 0, p);
				}
			}*/
            return Visit(context.variable());
        }

        public override object VisitConstant([NotNull] Combined1Parser.ConstantContext context)
        {
            if (context.INTEGER() != null)
                return int.Parse(context.GetText());

            if (context.FLOAT() != null)
                return float.Parse(context.GetText());

            if (context.BOOL() != null)
                return context.GetText() == "true";

            if (context.STRING() != null)
                return context.GetText().Replace("\"", "");

            if (context.NULL() != null)
                return null;

            return null;
        }

        public override object VisitAddExpression([NotNull] Combined1Parser.AddExpressionContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));

            switch (context.addOp().GetText())
            {
                case "+":
                    if (left is int lp && right is int rp)
                        return lp + rp;
                    break;
                case "-":
                    if (left is int lm && right is int rm)
                        return lm - rm;
                    break;
                case "%":
                    if (left is int lmo && right is int rmo)
                        return lmo % rmo;
                    break;
            }

            return null;
        }

        public override object VisitCompExpression([NotNull] Combined1Parser.CompExpressionContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));

            switch (context.compareOp().GetText())
            {
                case "==":
                    if (left is List<object> llist && llist[0] is string s)
                    {
                        switch (s)
                        {
                            case "all":
                                for (int i = 1; i < llist.Count; i++)
                                {
                                    if (!object.Equals(llist[i], right))
                                        return false;
                                }
                                return true;
                            case "any":
                                for (int i = 1; i < llist.Count; i++)
                                {
                                    if (object.Equals(llist[i], right))
                                        return true;
                                }
                                return false;
                            case "none":
                                for (int i = 1; i < llist.Count; i++)
                                {
                                    if (object.Equals(llist[i], right))
                                        return false;
                                }
                                return true;
                        }
                    }
                    return object.Equals(left, right);
                case "!=":
                    return !object.Equals(left, right);
                case ">":
                    return (left is int l1 && right is int r1 && l1 > r1);
                case "<":
                    return (left is int l2 && right is int r2 && l2 < r2);
                case ">=":
                    return (left is int l3 && right is int r3 && l3 >= r3);
                case "<=":
                    return (left is int l4 && right is int r4 && l4 <= r4);
            }
            return null;
        }

        public override object VisitBoolExpression([NotNull] Combined1Parser.BoolExpressionContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));

            switch (context.boolOp().GetText())
            {
                case "AND":
                    return (bool)left && (bool)right;
                case "OR":
                    return (bool)left || (bool)right;
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

        public override object VisitRepeatUntil([NotNull] Combined1Parser.RepeatUntilContext context)
        {
            do
            {
                Visit(context.block());
            }
            while ((bool)Visit(context.expression()));

            return null;
        }

        public override object VisitWait([NotNull] Combined1Parser.WaitContext context)
        {

            object subject = Visit(context.expression());

            Variables[context.ID().GetText()] = Manager.WaitForEvent(subject);
            Visit(context.block());
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

        public override object VisitParentExpression([NotNull] Combined1Parser.ParentExpressionContext context)
        {
            return Visit(context.expression());
        }

        public override object VisitAbsExpression([NotNull] Combined1Parser.AbsExpressionContext context)
        {
            return Math.Abs((int)Visit(context.expression()));
        }

        /*public override object VisitTurnStages([NotNull] Combined1Parser.TurnStagesContext context)
		{
			if (context == null)
				return new string(context.GetText().ToArray());
			//return Variables[context.ID().GetText()];
			return null;
		}*/
        public override object VisitTurnStagesExp([NotNull] Combined1Parser.TurnStagesExpContext context)
        {
            //return new string(context.turnStages().ID().GetText().ToArray());
            if (context.turnStages().ID() != null)
                return Variables[context.turnStages().ID().GetText()];
            /*if (context.turnStages().expression() != null)
                return null;// Variables[context.turnStages().expression().GetText()];*/
            return new string(context.GetText().ToArray());
        }

        int F = 0;
        public override object VisitFunctionBlock([NotNull] Combined1Parser.FunctionBlockContext context)
        {
            F++;
            inFunc = true;
            if (localVar != null)
                Variables[context.declaration().ID().GetText()] = localVar;
            Visit(context.block());
            F--;
            localVar = null;
            if (context.declaration() != null)
                Variables[context.declaration().ID().GetText()] = null;
            inFunc = false;

            foreach (var item in LocVariables)
            {
                if (Variables.ContainsKey(item.Key) && item.Key != "OUT")
                {
                    object temp = Variables[item.Key];
                    Variables.Remove(item.Key);
                    string key = item.Key + "0";
                    while (Variables.ContainsKey(key))
                        key += "0";
                    Variables[key] = temp;
                }
            }
            LocVariables.Clear();
            if (F == 0)
            {
                Outs.Clear();
                Locals.Clear();
                IDs.Clear();
                thisID = "Board";
            }
            return null;
        }

        public override object VisitListExpression([NotNull] Combined1Parser.ListExpressionContext context)
        {
            List<Tile> temp = new List<Tile>();

            for (int i = 0; i < context.list().expression().Length; i++)
            {
                temp.Add((Tile)Visit(context.list().expression(i)));
            }

            return temp;
        }

        public override object VisitFunctionCall([NotNull] Combined1Parser.FunctionCallContext context)
        {
            if (context.functionName().GetText() == "Remove")
            {
                object subject = Visit(context.constructor().expression(0));
                string Key = Variables.FirstOrDefault(x => x.Value == subject).Key;
                if (subject is Piece p)
                    p.player.pieces.Remove(p);
                //Variables.Remove(Key);
            }
            return null;
        }

        public override object VisitFunctionBody([NotNull] Combined1Parser.FunctionBodyContext context)
        {
            {
                if (Visit(context.variable()) is Player pl)
                {
                    var value = context.functionBlock();

                    Functions[new Function(pl, context.functionName().GetText())] = value;

                    return null;
                }
                else if (Visit(context.variable()) is List<Piece> pls)
                {
                    var value = context.functionBlock();
                    foreach (var item in pls)
                        Functions[new Function(item, context.functionName().GetText())] = value;

                    return null;
                }
                else if (Visit(context.variable()) is Piece pi)
                {
                    var value = context.functionBlock();

                    Functions[new Function(pi, context.functionName().GetText())] = value;

                    return null;
                }
                else
                {
                    var value = context.functionBlock();

                    Functions[new Function(null, context.functionName().GetText())] = value;

                    return null;
                }
            }

        }
    }
}
