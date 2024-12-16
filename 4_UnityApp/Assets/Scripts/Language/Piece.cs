using Antlr4.Runtime.Misc;
using Assets.Language;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Language
{
	public class Piece : ComplexVar
    {
		public int posX;
		public int posY;
		public string color;
		public List<Tile> route = new List<Tile>();
		public int RoutePosition;
		public Player player;
		public string texture;
        public bool real = true;

		public Piece()
		{
            real = false;
        }

        public void CopyData(Piece other)
		{
            posX = other.posX;
            posY = other.posY;
            color = other.color;
            route = other.route;
            RoutePosition = other.RoutePosition;
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
                real = true;
            }
		}

		public void Step(object args)
		{
            if (args is object[] o && o[0] is int x && o[1] is string type)
            {
                if (route.Count != 0)
                {
                    switch(type)
                    {
                        case "Step":
                            if(x>RoutePosition)
                                GameObject.Find("Manager").GetComponent<GameManager>().PieceMove(this, route.GetRange(RoutePosition + 1,x-RoutePosition), MoveType.Step);
                            else
                            {
                                List<Tile> temp = new List<Tile>();
                                for (int i = RoutePosition; i >= x; i--)
                                    temp.Add(route[i]);
                                GameObject.Find("Manager").GetComponent<GameManager>().PieceMove(this, temp, MoveType.Step);
                            }
                            break;
                        case "Slide":
                            GameObject.Find("Manager").GetComponent<GameManager>().PieceMove(this, new List<Tile>() { route[x] }, MoveType.Slide);
                            break;
                        case "Jump":
                            break;
                    }
                    RoutePosition = x;
                    if (RoutePosition >= route.Count - 1)
                        RoutePosition = route.Count - 1;
                    posX = route[RoutePosition].posX;
                    posY = route[RoutePosition].posY;
                }
            }
            else if(args is int)
            {
                if (route.Count != 0)
                {
                    posX = route[RoutePosition].posX;
                    posY = route[RoutePosition].posY;
                }
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
                case "color":
                    color = (string)val;
                    return;
                case "texture":
                    texture = (string)val;
                    return;
                case "routePosition":
                    RoutePosition = Convert.ToInt32(val);
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
                case "color":
                    return color;
                case "texture":
                    return texture;
                case "routePosition":
                    return RoutePosition;
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

        public override string ToString()
        {
            return "Piece";
        }

        public override Dictionary<string, object> GetDetails()
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>
            {
                { "posX", posX },
                { "posY", posY },
                { "color", color },
                { "player", player }
            };
            return dictionary;
        }
    }
}
