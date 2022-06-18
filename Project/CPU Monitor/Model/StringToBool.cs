using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Monitor.Model
{
    internal class StringToBool
    {
        public Boolean convert(String str_data)
        {
            if(str_data == "1" || str_data == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
