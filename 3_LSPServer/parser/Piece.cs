using Antlr4.Runtime.Misc;
using Assets.Language;
using parser;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language
{
	public class Piece : ComplexVar
    {
		public int posX;
		public int posY;
		public string color;
		public List<Tile> route = new List<Tile>();
		public int routePosition;
		public Player player;
		public string texture;

		public Piece()
		{

        }
        public override string ToString()
        {
            return "Piece";
        }

        public void CopyData(Piece other)
		{
            posX = other.posX;
            posY = other.posY;
            color = other.color;
            route = other.route;
            routePosition = other.routePosition;
			player = other.player;
            texture = other.texture;
        }


        public Piece(object args)
		{
			if (args is object[] o)
			{
				player = (Player)o[0];
				player.pieces.Add(this);
				o[0] = player;
				posX = Convert.ToInt32(o[1]);
				posY = Convert.ToInt32(o[2]);
			}
		}

		public void Step(int x)
		{
			if (route.Count != 0)
			{
				routePosition += x;
				if (routePosition >= route.Count - 1)
					routePosition = route.Count - 1;
				posX = route[routePosition].posX;
				posY = route[routePosition].posY;
			}
		}

        public override void Setter(string num, object val)
        {
            switch (num)
            {
                case "posX":
                    posX= Convert.ToInt32(val);
                    return;
                case "posY":
                    posY = Convert.ToInt32(val);
                    return;
                case "Color":
                    color = (string)val;
                    return;
                case "texture":
                    texture = (string)val;
                    return;
                case "routePosition":
                    routePosition = Convert.ToInt32(val);
                    return;
                case "route":
                    if (val is List<object> tiles)
                        foreach (object item in tiles)
                                route.Add((Tile)item);
                    return;
            }
            if(num.Contains("route"))
            {
                string temp = num.Remove(0, ("route").Length);
                route[int.Parse(temp)] = (Tile)val;
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
                case "Color":
                    return color;
                case "texture":
                    return texture;
                case "routePosition":
                    return routePosition;
                case "route":
                    return route;
            }
            if (num.Contains("route"))
            {
                string temp = num.Remove(0, ("route").Length);
                return route[Math.Min(int.Parse(temp), route.Count - 1)];
            }
            return null;
        }
    }
}
