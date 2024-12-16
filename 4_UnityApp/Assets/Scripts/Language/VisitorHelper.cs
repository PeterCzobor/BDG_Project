using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language
{
    class VisitorHelper
    {

        public static object Add(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li + ri;
            if (left is double lf && right is double rf)
                return lf + rf;
            if (left is int lif && right is double rif)
                return lif + rif;
            if (left is double lfi && right is int rfi)
                return lfi + rfi;
            if (left is string || right is string)
                return $"{left}{right}";
            return null;
        }
        public static object Sub(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li - ri;
            if (left is double lf && right is double rf)
                return lf - rf;
            if (left is int lif && right is double rif)
                return lif - rif;
            if (left is double lfi && right is int rfi)
                return lfi - rfi;
            return null;
        }
        public static object Mul(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li * ri;
            if (left is double lf && right is double rf)
                return lf * rf;
            if (left is int lif && right is double rif)
                return lif * rif;
            if (left is double lfi && right is int rfi)
                return lfi * rfi;
            return null;
        }
        public static object Div(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li / ri;
            if (left is double lf && right is double rf)
                return lf / rf;
            if (left is int lif && right is double rif)
                return lif / rif;
            if (left is double lfi && right is int rfi)
                return lfi / rfi;
            return null;
        }
        public static object Mod(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li % ri;
            if (left is double lf && right is double rf)
                return lf % rf;
            if (left is int lif && right is double rif)
                return lif % rif;
            if (left is double lfi && right is int rfi)
                return lfi % rfi;
            return null;
        }
        public static bool Great(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li > ri;
            if (left is double lf && right is double rf)
                return lf > rf;
            if (left is int lif && right is double rif)
                return lif > rif;
            if (left is double lfi && right is int rfi)
                return lfi > rfi;
            return false;
        }
        public static bool GreatEqu(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li >= ri;
            if (left is double lf && right is double rf)
                return lf >= rf;
            if (left is int lif && right is double rif)
                return lif >= rif;
            if (left is double lfi && right is int rfi)
                return lfi >= rfi;
            return false;
        }
        public static bool Small(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li < ri;
            if (left is double lf && right is double rf)
                return lf < rf;
            if (left is int lif && right is double rif)
                return lif < rif;
            if (left is double lfi && right is int rfi)
                return lfi < rfi;
            return false;
        }
        public static bool SmallEqu(object left, object right)
        {
            if (left is Int64 li64)
                left = Convert.ToInt32(li64);
            if (right is Int64 ri64)
                left = Convert.ToInt32(ri64);

            if (left is int li && right is int ri)
                return li <= ri;
            if (left is double lf && right is double rf)
                return lf <= rf;
            if (left is int lif && right is double rif)
                return lif <= rif;
            if (left is double lfi && right is int rfi)
                return lfi <= rfi;
            return false;
        }
    }
}
