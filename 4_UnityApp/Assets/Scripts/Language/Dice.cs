using Assets.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language
{
	public class Dice : ComplexVar
    {
		List<int> values = new List<int>();
		public int value;


		public Dice(Dice other)
		{
			foreach(int i in other.values)
				values.Add(i);
			value = other.value;
		}

        public Dice()
		{
			for (int i = 1; i < 7; i++)
				values.Add(i);
		}
		public Dice(object args)
		{
			if (args is object[] o)
			{
				foreach(var item in o)
					values.Add(Convert.ToInt32(item));
			}
		}

		public void Roll()
		{
			var random = new Random();
			value = values[random.Next(values.Count)];
		}

        public override void Setter(string num, object val)
        {
            switch (num)
            {
                case "value":
                    value = Convert.ToInt32(val);
                    break;
            }
        }
        public override object Getter(string num)
        {
            switch (num)
            {
                case "value":
                    return value;
            }
            return null;
        }

        public override string ToString()
        {
            return "Dice";
        }
    }
}
