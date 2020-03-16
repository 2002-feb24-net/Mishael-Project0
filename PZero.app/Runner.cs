using PZero.lib;

namespace PZero.app
{
    class Runner
    {
        private bool manageMode = false;
        private string state = "";
        private string input = "";
        private Data storage = new Data();
        Customer active;

        public bool GetInput()
        {
            bool running = true;
            input = "";

            running = AskMain();

            switch (state)
            {
                case "1":
                    GetInputCustomer();
                    break;
                case "2":
                    break;
                case "3":
                    active = storage.SearchCustomer();
                    break;
                case "4": break;
                case "5":
                    input = Input.GetInput(InputType.unformatedName);
                    break;
                case "6": break;
                case "mng":
                    manageMode = true;
                    state = "none";
                    break;
                case "Q":
                default:
                    state = "none";
                    running = false;
                    break;
            }

            return running;
        }

        public bool Run()
        {
            bool running = true;

            switch (state)
            {
                case "1":
                    storage.AddCustomer(new Customer(input));
                    break;
                case "2":
                    Output.PrintCustNames(storage.customers);
                    break;
                case "4":
                    storage.customers.Remove(active);
                    active = null;
                    break;
                case "5":
                    storage.AddStore(input);
                    break;
                case "6":
                    Output.PrintStores(storage.GetStores());
                    break;
                default: break;
            }

            return running;
        }

        private bool AskMain()
        {
            bool running = true;

            System.Console.WriteLine("Enter a number or \'q\' to quit");
            System.Console.WriteLine("1. Add Customer");
            System.Console.WriteLine("2. List Customers");
            System.Console.WriteLine("3. Select active Customer");
            System.Console.WriteLine("6. List availible stores");
            if (active != null)
            {
                System.Console.WriteLine("Active costumer: " + active.GetName());
                System.Console.WriteLine("4. Remove active Customer");
            }
            if (manageMode)
            {
                System.Console.WriteLine("Manager mode:");
                System.Console.WriteLine("5. Add a store");
            }

            if (manageMode)
            {
                if (active == null)
                {
                    state = Input.GetInput(InputType.mainSelect,"1", "2", "3", "5", "6");
                }
                else
                {
                    state = Input.GetInput(InputType.mainSelect, "1", "2", "3", "4", "5", "6");
                }
            }
            else
            {
                if (active == null)
                {
                    state = Input.GetInput(InputType.mainSelect, "1", "2", "3", "6");
                }
                else
                {
                    state = Input.GetInput(InputType.mainSelect, "1", "2", "3", "4", "6");
                }
            }
            
            

            return running;
        }

        private void GetInputCustomer()
        {
            System.Console.WriteLine("enter the customer's name\neither enter a single name alone or two names separated by \',\'\n(first,last)");
            input = Input.GetInput(InputType.name);
        }
    }
}