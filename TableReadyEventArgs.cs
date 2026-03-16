using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_4
{
    internal class TableReadyEventArgs : EventArgs
    {
        public TableRequest Table { get; }

        public TableReadyEventArgs(TableRequest table)
        {
            Table = table;
        }
    }
}
