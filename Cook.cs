using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_4
{
    internal class Cook
    {
        public event EventHandler Processed;

        public void Subscribe(Server server)
        {
            server.Ready += ProcessOrders;  
        }
        
        private void ProcessOrders(object sender, TableReadyEventArgs e)
        {
            foreach (Chicken chicken in e.Table.Get<Chicken>())
            {
                chicken.Obtain();
                chicken.CutUp();
                chicken.Cook();
            }

            foreach (Egg egg in e.Table.Get<Egg>())
            {
                egg.Obtain();

                using (egg)
                {
                    egg.Crack();
                    egg.Cook();
                }
            }

            Processed?.Invoke(this, EventArgs.Empty);
        }


    }
}
