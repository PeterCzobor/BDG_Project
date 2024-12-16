using Assets.Language;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

namespace Language
{
	public class Tile : ComplexVar
    {
		public int posX;
		public int posY;

		public Tile()
		{

		}

        public Tile(object args)
		{
			if (args is object[] o)
			{
				posX = Convert.ToInt32(o[0]);
				posY = Convert.ToInt32(o[1]);
			}
		}

        public override void Setter(string num, object val)
        {
            switch (num)
            {
                case "posX":
                    posX = Convert.ToInt32(val);
                    break;
                case "posY":
                    posY = Convert.ToInt32(val);
                    break;
            }
        }
        public override object Getter(string num)
        {
            switch (num)
            {
                case "posX":
                    return posX;
                case "posY":
                    return posY;
            }
            return null;
        }

        public override string ToString()
        {
            return "Tile";
        }
    }
}
