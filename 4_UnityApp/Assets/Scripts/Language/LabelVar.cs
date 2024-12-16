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
    public class LabelVar : ComplexVar
    {
        public bool active;
        public Color color;
        public Color textColor;
        public string texture;
        public string text;
        public float fontsize;

        public LabelVar()
        {

        }

        public LabelVar(bool active, Color color, Color textColor, string texture, string text, float fontsize)
        {
            this.active = active;
            this.color = color;
            this.textColor = textColor;
            this.texture = texture;
            this.text = text;
            this.fontsize = fontsize;
        }

        public override void Setter(string num, object val)
        {
            switch (num)
            {
                case "active":
                    active = (bool)val;
                    break;
                case "text":
                    text = val.ToString();
                    break;
            }
        }
        public override object Getter(string num)
        {
            switch (num)
            {
                case "active":
                    return active;
                case "text":
                    return text;
            }
            return null;
        }

        public override string ToString()
        {
            return "Label";
        }
    }
}
