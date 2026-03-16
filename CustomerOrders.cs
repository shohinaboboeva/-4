using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_4
{
    internal class CustomerOrders
    {
        public string Name { get; }

        public List<MenuItem> Items { get; }

        public CustomerOrders(string name)
        {
            Name = name;
            Items = new List<MenuItem>();
        }
    }
}
