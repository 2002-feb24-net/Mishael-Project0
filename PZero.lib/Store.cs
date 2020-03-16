using System;
using System.Collections.Generic;
using System.Text;

namespace PZero.lib
{
    public class Store
    {
        private readonly string name;
        private List<Product> StoreFront = new List<Product>();

        public Store(string n) => name = n;

        public void AddProduct(Product x) => StoreFront.Add(x);

        public string GetName() => name;

        public List<Product> GetProducts() => StoreFront;
    }
}
