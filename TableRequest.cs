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

        public void Add<T>(string customerName) where T : MenuItem, new()
        {
            CustomerOrders customer = orders.Find(c => c.Name == customerName);

            if (customer == null)
            {
                customer = new CustomerOrders(customerName);
                orders.Add(customer);
            }

            T item = new T();
            item.CustomerName = customerName;

            customer.Items.Add(item);
        }

        public List<T> Get<T>() where T : MenuItem
        {
            List<T> result = new List<T>();

            foreach (var customer in orders)
            {
                foreach (var item in customer.Items)
                {
                    if (item is T typed)
                        result.Add(typed);
                }
            }

            return result;
        }

        public List<MenuItem> this[string name]
        {
            get
            {
                CustomerOrders customer = orders.Find(c => c.Name == name);
                if (customer != null)
                    return customer.Items;

                return new List<MenuItem>();
            }
        }
        
        public IEnumerator<MenuItem> GetEnumerator()
        {
            foreach (var customer in orders)
                foreach (var item in customer.Items)
                    if (item is Drink)
                        yield return item;

            foreach (var customer in orders)
                foreach (var item in customer.Items)
                    if (!(item is Drink))
                        yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
