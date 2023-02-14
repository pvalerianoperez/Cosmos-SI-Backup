using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.Utilerias
{
    
    public class StringHelper
    {
        
        public static string ListToCSV(int[] list, string delimiter) {
            string result = "";
            if (list != null) {
                if (list.Length > 0) {
                    StringBuilder sb = new StringBuilder();
                    foreach (int v in list)
                    {
                        if (!string.IsNullOrEmpty(delimiter)) {
                            if (sb.Length > 0) { sb.Append(delimiter); }
                        }
                        sb.Append(v.ToString());
                    }
                    result = sb.ToString();
                }                
            }
            return result;
        }
        public static string ListToCSV(string[] list, string delimiter)
        {
            string result = "";
            if (list != null)
            {
                if (list.Length > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string v in list)
                    {
                        if (!string.IsNullOrEmpty(delimiter))
                        {
                            if (sb.Length > 0) { sb.Append(delimiter); }
                        }
                        sb.Append(v.ToString());
                    }
                    result = sb.ToString();
                }
            }
            return result;
        }
    }
}
