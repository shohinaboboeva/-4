using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Симулятор_простого_рестарана_4
{
    internal class TableRequest : IEnumerable<MenuItem>
    {
        private List<CustomerOrders> orders = new List<CustomerOrders>();

        public void Add<T>(string name) where T : MenuItem, new()
        {
            var customer = orders.Find(c => c.Name == name);

            if (customer == null)
            {
                customer = new CustomerOrders(name);
                orders.Add(customer);
            }

            T item = new T();
            item.CustomerName = name;
            customer.Items.Add(item);
        }

        public List<T> Get<T>() where T : MenuItem
        {
            List<T> result = new List<T>();

            foreach (var customer in orders)
            {
                foreach (var item in customer.Items)
                {
                    if (item is T t)
                        result.Add(t);
                }
            }

            return result;
        }

        public List<MenuItem> this[string name]
        {
            get
            {
                var customer = orders.Find(c => c.Name == name);
                return customer.Items;
            }
        }

        public IEnumerator<MenuItem> GetEnumerator()
        {
            foreach (var customer in orders)
            {
                foreach (var item in customer.Items)
                {
                    if (item is Drink)
                        yield return item;
                }
            }

            foreach (var customer in orders)
            {
                foreach (var item in customer.Items)
                {
                    if (!(item is Drink))
                        yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
