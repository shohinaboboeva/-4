using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_4
{
    internal abstract class MenuItem
    {
        public string CustomerName { get; set; }

        
        public abstract void Obtain();
        public abstract void Cook();
        public abstract void Serve();
    }
}
