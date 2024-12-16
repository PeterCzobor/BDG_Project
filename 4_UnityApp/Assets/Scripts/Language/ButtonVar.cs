using Assets.Language;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

namespace Language
{
    public class ButtonVar : ComplexVar
    {
        public bool active;
        public Color color;
        public Color textColor;
        public string texture;
        public string label;
        public float fontsize;

        public ButtonVar()
        {

        }

        public ButtonVar(bool active, Color color, Color textColor, string texture, string label, float fontsize)
        {
            this.active = active;
            this.color = color;
            this.textColor = textColor;
            this.texture = texture;
            this.label = label;
            this.fontsize = fontsize;
        }

        public override void Setter(string num, object val)
        {
            switch (num)
            {
                case "active":
                    active = (bool)val;
                    break;
            }
        }
        public override object Getter(string num)
        {
            switch (num)
            {
                case "active":
                    return active;
            }
            return null;
        }
    }
}
