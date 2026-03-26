using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Симулятор_простого_рестарана_4
{
    internal class Server
    {
        public event EventHandler<TableReadyEventArgs> Ready;

        private TableRequest table = new TableRequest();



        public void TakeOrder(string name, int chicken, int egg, bool drink)
        {
            for (int i = 0; i < chicken; i++)
                table.Add<Chicken>(name);

            for (int i = 0; i < egg; i++)
                table.Add<Egg>(name);

            if (drink)
                table.Add<Drink>(name);
        }

        public void SendOrders()
        {
            Ready?.Invoke(this, new TableReadyEventArgs(table));
        }

        // 🔥 ПРАВИЛЬНО: через IEnumerable
        public void ServeFood(object sender, EventArgs e)
        {
            foreach (var item in table)
            {
                item.Serve();
            }
        }
    }
}
