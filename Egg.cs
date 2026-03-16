using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_4
{

    internal class Egg : MenuItem, IDisposable
    {
        private static Random rnd = new Random();

        public int Quality { get; private set; }

        public Egg()
        {
            Quality = rnd.Next(1, 101);
        }

        public override void Obtain() { }

        public void Crack() { }

        public override void Cook() { }

        public override void Serve() { }

        public void Dispose()
        {
            DiscardShells();
        }

        private void DiscardShells() { }
    }
}
