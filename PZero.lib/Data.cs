using System;
using System.Collections.Generic;

namespace PZero.lib
{

    public class Data
    {
        public List<Customer> customers = new List<Customer>();
        private List<Store> Stores = new List<Store>();

        public void AddCustomer(Customer x)
        {
            customers.Add(x);
        }

        public void AddStore(string x)
        {
            Stores.Add(new Store(x));
        }

        public Customer SearchCustomer(Action<List<Customer>> OutputNames, Func<string[]> GetNames)
        {
            List<Customer> found = new List<Customer>();

            while (found.Count != 1)
            {
                OutputNames(found);
                while (found.Count > 0) found.RemoveAt(0);
                string[] input = GetNames();
                foreach (var item in customers)
                {
                    bool isIn = true;
                    foreach (var x in input)
                    {
                        isIn = isIn && item.GetRName().Contains(x);
                    }
                    if (isIn) found.Add(item);
                    if (isIn && item.GetRName() == input[0] + (input.Length > 1 ? input[1] : ""))
                    {
                        while (found.Count > 1) found.RemoveAt(0);
                        break;
                    }
                }

            }

            return found[0];
        }

        public List<Store> GetStores() => Stores;
    }
}