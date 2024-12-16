using Assets.Language;
using Language;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Simulator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SimulateTurn(string caller, object[] o)
    {
        GameManager.simulating = true;
        List<string> pieces = new List<string>();
        List<string> tiles = new List<string>();
        //List<CustomFunction> cfs = new List<CustomFunction>();
        CustomFunction cf = new CustomFunction();
        GameManager.visitor.Variables["CurrentPlayer"] = GameManager.visitor.Variables[caller];

        GameManager.SaveState();

        foreach (object item in o)
        {
            if (item is IList list)
            {
                if(list.Contains("Rule"))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i] is string s && s == "Rule" && i > 0)
                        {
                            if (list[i - 1] is ComplexList pList)
                            {
                                foreach (Piece p in pList.list)
                                    pieces.Add(GameManager.visitor.Variables.FirstOrDefault(x => x.Value == p).Key);
                            }
                            if (list.Count > i + 1 && list[i + 1] is ComplexList tList)
                            {
                                foreach (Tile t in tList.list)
                                    tiles.Add(GameManager.visitor.Variables.FirstOrDefault(x => x.Value == t).Key);
                            }
                        }
                    }
                }
                else
                {
                    cf.name = (string)list[0];
                    cf.args.Add(null);
                }
            }
        }

        foreach (string p in pieces)
        {
            GameManager.PieceKey = p;

            if (tiles.Count != 0)
            {
                foreach (string t in tiles)
                {
                    GameManager.TileKey = t;
                    if (GameManager.CheckRule())
                    {
                        if (cf.name == null || GameManager.CheckCustom(cf, ""))
                        {
                            GameManager.RollBack();
                            GameManager.ResetKeys();
                            GameManager.simulating = false;
                            return true;
                        }
                    }
                }
            }
            else
            {
                if (GameManager.CheckRule())
                {
                    if (cf.name == null || GameManager.CheckCustom(cf, ""))
                    {
                        GameManager.RollBack();
                        GameManager.ResetKeys();
                        GameManager.simulating = false;
                        return true;
                    }
                }
            }
        }

        GameManager.RollBack();
        GameManager.ResetKeys();
        GameManager.simulating = false;
        return false;
    }
}
