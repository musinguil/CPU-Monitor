using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Monitor.Model
{
    internal interface Processor
    {
        int getTemp();
        float getUsing();

    }
}
