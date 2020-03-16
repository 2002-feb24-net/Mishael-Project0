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
                case "mng":
                    manageMode = true;
                    state = "none";
                    running = false;
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
                default: break;
            }

            return running;
        }

        private bool AskMain()
        {
            bool running = true;

            System.Console.WriteLine("Choose an option by entering a number or enter \'q\' to quit\n1. add Custumer\n2. show all Customer names\n3. set active Customer");
            if (active != null) System.Console.WriteLine($"active costumer : {active.GetName()}\n4. remove active Customer");

            if (active != null) state = Input.GetInput(InputType.mainSelect, "1", "2", "3", "4");
            else state = Input.GetInput(InputType.mainSelect, "1", "2", "3");

            return running;
        }

        private void GetInputCustomer()
        {
            System.Console.WriteLine("enter the customer's name\neither enter a single name alone or two names separated by \',\'\n(first,last)");
            input = Input.GetInput(InputType.name);
        }
    }
}