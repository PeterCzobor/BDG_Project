using Language;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Language
{
    public class ComplexVar
    {
        public virtual void Setter(string num, object val)
        {
        }
        public virtual object Getter(string num)
        {
            return null;
        }

        public virtual Dictionary<string, object> GetDetails()
        {
            return new Dictionary<string, object>();
        }
    }

    public class Variable
    {
        public object nonNumeric;
        public string numeric;

        public Variable(object nonNumeric, string numeric)
        {
            this.nonNumeric = nonNumeric;
            this.numeric = numeric;
        }

        public void Setter(object val)
        {
            if (nonNumeric is ComplexVar cv)
            {
                cv.Setter(numeric, val);
            }
        }
        public object Getter()
        {
            if (nonNumeric is ComplexVar cv)
            {
                return cv.Getter(numeric);
            }
            return null;
        }
    }

    public enum Collection
    {
        ALL,
        ANY,
        NONE
    }

    public class ComplexList
    {
        public IList list = new List<object>();
        public Collection collection;

        public ComplexList(IList list, Collection collection)
        {
            this.list = list;
            this.collection = collection;
        }
    }
}
