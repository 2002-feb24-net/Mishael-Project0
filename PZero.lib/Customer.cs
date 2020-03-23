using System.Collections.Generic;
using System.Linq;

namespace PZero.lib
{
    public class Customer
    {
        private string fname = "NULL";
        private string lname = "NULL";
        private string regname = "NULL";
        private List<Order> history = new List<Order>();

        public Customer(string name)
        {
            SetName(name);
        }

        public Customer(string f, string l)
        {
            SetName(f, l);
        }

        public string GetName() => fname + (lname != "NULL" ? "," + lname : "");
        public string GetFName() => fname;
        public string GetLName() => lname;
        public string GetRName() => regname;
        public List<Order> GetOrders() => history;

        public void AddOrder(Order x) => history.Add(x);

        public void SetFirst(string x)
        {
            fname = x;
            SetRegName();
        }

        public void SetLast(string x)
        {
            lname = x;
            SetRegName();
        }

        public void SetName(string name)
        {
            if (name.Contains(','))
            {
                int i = name.IndexOf(',');
                fname = name.Substring(0, i);
                lname = name.Substring(i + 1, name.Length - i - 1);
            }
            else fname = name;

            SetRegName();
        }

        public void SetName(string f, string l)
        {
            fname = f;
            lname = l;

            SetRegName();
        }

        private void SetRegName()
        {
            regname = fname.ToUpper() + (lname != "NULL" ? lname.ToUpper() : "");
        }

    }
}