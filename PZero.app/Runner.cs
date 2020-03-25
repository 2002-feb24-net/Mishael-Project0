using PZero.dtb;

namespace PZero.app
{
    class Runner
    {
        private bool manageMode = false;
        private string state = "";
        private string input = "";
        int activeCustomer = -1;
        int activeStore = -1;

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
                    activeCustomer = Data.FindCustomer(Output.PrintCustNames, Input.GetName);
                    break;
                case "4": break;
                case "5":
                    input = Input.GetInput(InputType.unformatedName);
                    break;
                case "6": break;
                case "7":
                    activeStore = Data.FindLocation(Output.PrintStores, Input.GetUnformatedName);
                    break;
                case "8": break;
                case "9":
                    System.Console.Write("Enter Product Name: ");
                    string name = Input.GetInput(InputType.unformatedName);
                    System.Console.Write("Enter price: ");
                    decimal price = decimal.Parse(Input.GetInput(InputType.price));
                    System.Console.Write("Enter Stock: ");
                    int stock = int.Parse(Input.GetInput(InputType.Int));
                    Data.AddProduct(name, activeStore, price, stock);
                    break;
                case "10":
                    int product = Input.GetProduct(activeStore);
                    System.Console.Write("by how much: ");
                    Data.StockProduct(product, int.Parse(Input.GetInput(InputType.Int)));
                    break;
                case "11":
                    Data.AddOrder(activeCustomer,Input.PlaceOrder(activeCustomer));
                    break;
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
                    Data.AddCustomer(input);
                    break;
                case "2":
                    Output.PrintCustNames(Data.GetCustomers());
                    break;
                case "4":
                    Data.RemoveCustomer(activeCustomer);
                    activeCustomer = -1;
                    break;
                case "5":
                    Data.AddLocation(input);
                    break;
                case "6":
                    Output.PrintStores(Data.GetStores());
                    break;
                case "8":
                    Data.RemoveStore(activeStore);
                    break;
                case "10":
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
            System.Console.WriteLine("6. List availible stores");
            System.Console.WriteLine("3. Select active Customer");
            if (activeCustomer != -1)
            {
                System.Console.WriteLine("Active costumer: " + Data.GetCustomer(activeCustomer));
                System.Console.WriteLine("11. Place order");
                System.Console.WriteLine("4. Remove active Customer");
            }
            if (manageMode)
            {
                System.Console.WriteLine("Manager mode:");
                System.Console.WriteLine("7. Set active store");
                if (activeStore != -1) System.Console.WriteLine($"Current active location : {Data.GetStore(activeStore)}");
                System.Console.WriteLine("5. Add a store");
                System.Console.WriteLine("8. Remove active store");
                System.Console.WriteLine("9. add a product");
                System.Console.WriteLine("10. stock a product");
            }

            if (manageMode)
            {
                if (activeCustomer == -1)
                {
                    if (activeStore == -1)
                    {
                        state = Input.GetInput(InputType.mainSelect,"1", "2", "3", "5", "6", "7");
                    }
                    else
                    {
                        state = Input.GetInput(InputType.mainSelect, "1", "2", "3", "5", "6", "7", "8" , "9", "10");
                    }
                }
                else
                {
                    if (activeStore == -1)
                    {
                        state = Input.GetInput(InputType.mainSelect, "1", "2", "3", "4", "5", "6", "7", "11");
                    }
                    else
                    {
                        state = Input.GetInput(InputType.mainSelect, "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11");
                    }
                }
            }
            else
            {
                if (activeCustomer == -1)
                {
                    state = Input.GetInput(InputType.mainSelect, "1", "2", "3", "6");
                }
                else
                {
                    state = Input.GetInput(InputType.mainSelect, "1", "2", "3", "4", "6", "11");
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