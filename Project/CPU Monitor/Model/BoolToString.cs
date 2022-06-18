using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Monitor.Model
{
    internal class BoolToString
    {
        public String convert(Boolean bool_data)
        {
            if (bool_data == true)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
    }
}
