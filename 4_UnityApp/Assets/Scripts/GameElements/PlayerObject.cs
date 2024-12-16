using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Language;

public class PlayerObject : GameElement
{
    public Player player;
    public string playerKey;

    public override string VariableKey { get => playerKey; set => playerKey = value; }
    public override object VariableObject { get => player; set => player = (Player)value; }

    public override void CreateElement(object[] args)
    {
        if (args[0] is Player player_)
            player = player_;
        if (args[1] is string playerKey_)
            playerKey = playerKey_;

        name = "Player_" + player.name;
    }
}
