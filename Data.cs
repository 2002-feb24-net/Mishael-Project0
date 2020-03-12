using System.Collections.Generic;

namespace p0
{

    class Data
    {
        public List<Customer> customers = new List<Customer>();

        public void AddCustomer(Customer x)
        {
            customers.Add(x);
        }

        public Customer SearchCustomer()
        {
            Customer output = null;
            List<Customer> found = new List<Customer>();

            while(found.Count!=1)
            {
                Output.PrintCustNames(found);
                string[] input = Input.GetInput(InputType.name).Split(",");
                for (int i = 0; i < input.Length; i++) input[i] = Input.RegString(input[i]);
                foreach (var item in customers)
                {
                    bool isIn = true;
                    foreach (var x in input)
                    {
                        isIn = isIn && item.GetRName().Contains(x);
                    }
                    if (isIn && item.GetRName().Contains(input[0] + (input.Length>1?input[1]:"")))
                    {
                        while (found.Count > 1) found.RemoveAt(0);
                        break;
                    }
                    if (isIn) found.Add(item);
                }
                
            }

            return output;
        }
    }
}