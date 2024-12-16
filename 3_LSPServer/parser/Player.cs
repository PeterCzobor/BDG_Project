using Assets.Language;
using Newtonsoft.Json.Linq;
using parser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
        public override string ToString()
        {
            return "Player";
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
    }

    public class CustomFunction
    {
        public string name;
        public List<object> args = new List<object>();
    }
}
