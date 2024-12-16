using Assets.Language;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Language
{
	public class Player : ComplexVar
    {
		public List<Piece> pieces = new List<Piece>();
		public string name;
        public List<int> stages= new List<int>();
        public int currentStage;

		public Dice dice;
        public int customFuncsIndex;
		public List<CustomFunction> funcs = new List<CustomFunction>();

		public Player()
		{

		}

        public void CopyData(Player other)
        {
            pieces = other.pieces;
            name = other.name;
            stages = other.stages;
            currentStage = other.currentStage;
            dice = other.dice;
            customFuncsIndex = other.customFuncsIndex;
            funcs = other.funcs;
        }

        public Player(object args)
		{
			if (args is object[] o)
			{
				name = (string)o[0];
			}
		}

        public bool TryTurn(string caller, object args)
        {
            if (args is object[] o)
            {
                return GameObject.Find("Manager").GetComponent<GameManager>().SimulateTurn(caller, o);

            }
            return true;
        }

        public void EndTurn()
        {
            GameObject.Find("Manager").GetComponent<GameManager>().EndTurn();
        }

        public void CancelStep()
        {
            GameManager.cancel = true;
        }

        public void Turn(object args)
		{
            int prevLength =0;
            if (currentStage != 0)
                prevLength = stages.Count;
            stages.Clear();
            dice = null;
            funcs.Clear();
			if (args is object[] o)
			{
				foreach (var item in o)
				{
                    if (item is string s1 && s1 == "SelectPiece")
                        stages.Add((int)TurnStages.SelectPiece);
                    else if (item is string s2 && s2 == "SelectTile")
                        stages.Add((int)TurnStages.SelectTile);
                    else if (item is string s3 && s3 == "Rule")
                        stages.Add((int)TurnStages.CheckRule);
                    else if (item is Dice d)
                    {
                        dice = d;
                        stages.Add((int)TurnStages.RollDice);
                    }
                    else if (item is List<object> l)
                    {
                        CustomFunction cf = new CustomFunction();
                        cf.name = (string)l[0];
                        for (int i = 1; i < l.Count; i++)
                            cf.args.Add(l[i]);
                        if (cf.args.Count == 0)
                            cf.args.Add(null);
                        funcs.Add(cf);
                        stages.Add((int)TurnStages.CustomFuncs);
                    }
                }
                stages.Add((int)TurnStages.CheckWin);
                if (prevLength > stages.Count)
                    currentStage -= prevLength - stages.Count;
            }
            else
            {
                stages.Add((int)TurnStages.CheckWin);
                if (prevLength > stages.Count)
                    currentStage -= prevLength - stages.Count;
            }
        }


        public override void Setter(string num, object val)
        {
            switch (num)
            {
                case "name":
                    name = (string)val;
                    break;
            }
        }
        public override object Getter(string num)
        {
            switch (num)
            {
                case "name":
                    return name;
            }
            return null;
        }

        public override string ToString()
        {
            return "Player";
        }


        public override Dictionary<string, object> GetDetails()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>
            {
                { "name", name },
                { "pieces", pieces }
            };
            return dictionary;
        }
    }

    public class CustomFunction
    {
        public string name;
        public List<object> args = new List<object>();
    }
}
