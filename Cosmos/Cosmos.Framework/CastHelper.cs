using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Framework
{
    public class CastHelper
    {
        public static string CStr2(object o) {
            if (o == null) { return string.Empty; }
            if (o == DBNull.Value) { return string.Empty; }
            return Convert.ToString(o);
        }
        public static Int32 CInt2(object o)
        {
            int result = 0;
            if (o == null) { return result; }
            if (o == DBNull.Value) { return result; }
            
            try
            {
                result = Convert.ToInt32(o);
            }
            catch{
                result = 0;
            }
            return result;
        }

        public static double CDbl2(object o)
        {
            double result = 0;
            if (o == null) { return result; }
            if (o == DBNull.Value) { return result; }

            try
            {
                result = Convert.ToDouble(o);
            }
            catch
            {
                result = 0;
            }
            return result;
        }
        public static decimal CDecimal2(object o)
        {
            decimal result = 0;
            if (o == null) { return result; }
            if (o == DBNull.Value) { return result; }

            try
            {
                result = Convert.ToDecimal(o);
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        public static DateTime CDate2(object o)
        {
            DateTime result = new DateTime(1900,1,1);
            if (o == null) { return result; }
            if (o == DBNull.Value) { return result; }

            try
            {
                result = Convert.ToDateTime(o);
            }
            catch
            {
                result = new DateTime(1900, 1, 1);
            }
            return result;
        }

        public static bool CBool2(object o)
        {
            bool result =false;
            if (o == null) { return result; }
            if (o == DBNull.Value) { return result; }

            try
            {
                result = Convert.ToBoolean(o);
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}
