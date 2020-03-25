using PZero.dtb;
using System;
using System.Collections.Generic;

namespace PZero.app
{

    enum InputType { select, mainSelect, price, name, unformatedName,
        Int
    }
    class Input
    {
        public static string GetInput(InputType I, params string[] ops)
        {
            string output = "";
            switch (I)
            {
                case InputType.select:
                    output = GetSmallNumber(ops, false);
                    break;
                case InputType.mainSelect:
                    output = GetSmallNumber(ops, true);
                    break;
                case InputType.price:
                    output = GetPrice();
                    break;
                case InputType.name:
                    output = GetName();
                    break;
                case InputType.unformatedName:
                    output = GetUnformatedName();
                    break;
                case InputType.Int:
                    output = GetInt();
                    break;
                default:
                    System.Console.WriteLine("no input type");
                    break;
            }
            return output;
        }
        
        public static OrderCart PlaceOrder(int x)
        {
            var cart = new OrderCart(x);
            var stores = Data.GetStores();
            string input = "";
            while (input != "q")
            {
                for (int i = 0; i < stores.Count; i++) Console.WriteLine($"{i+1}. {stores[i]}");
                Console.WriteLine("Select a store or enter \'q\' to finalise");
                if (cart.Cart.Count != 0) Console.WriteLine($"Current total: ${cart.GetCurrentTotal()}");
                bool valid = false;
                while (!valid && input != "q")
                {
                    valid = true;
                    input = GetInt("q");
                    if (input != "q" && (int.Parse(input)>stores.Count || int.Parse(input)<=0))
                    {
                        valid = false;
                        Console.WriteLine("Input out of bounds");
                    }
                }
                if (input != "q")
                {
                    var PID = GetProduct(Data.GetProductNames(stores[int.Parse(input)-1]),
                        Data.GetProductPrices(stores[int.Parse(input) - 1]),
                        Data.GetProductQuantities(stores[int.Parse(input) - 1]));
                    Console.WriteLine("Enter quantity to order:");
                    var QTY = Data.GetQuantity(PID, () => int.Parse(GetInt()));
                    var PIC = Data.GetPrice(PID);
                    cart.Cart.Add(new dtb.Entities.OrderData { PrdId = PID, Quantity = QTY, Price = PIC});
                }
            }
            return cart;
        }
        
        private static int GetProduct(List<string> names, List<decimal> prices, List<int> quanties)
        {
            string input = "";
            for (int i = 0; i < names.Count; i++) Console.WriteLine($"{i + 1}. {names[i]} in stock: {quanties[i]} ${prices[i]}");
            Console.WriteLine("Select a Product");
            bool valid = false;
            while (!valid)
            {
                valid = true;
                input = GetInt();
                if (int.Parse(input) > names.Count || int.Parse(input) <= 0)
                {
                    valid = false;
                    Console.WriteLine("Input out of bounds");
                }
            }
            return Data.ProductFromName(names[int.Parse(input) - 1]);
        } 

        private static string GetInt(string end = "What If minecraft was real and all of the cheetoes had too many beens")
        {
            string output = "";
            bool valid = false;

            while (!valid && !output.Contains(end))
            {
                output = System.Console.ReadLine();
                valid = IsInt(output);
                if (!valid) Console.WriteLine("invalid, enter an integer");
            }

            return output;
        }

        private static string GetSmallNumber(string[] ops, bool main)
        {
            string i = "";
            bool valid = false;
            int length = 0;
            foreach (string x in ops) if (x.Length > length) length = x.Length;
            while (!valid)
            {
                i = System.Console.ReadLine();
                if(i.ToUpper()=="this is not correct input".ToUpper())
                {
                    System.Console.WriteLine("that is correct");
                    continue;
                }
                if (main)
                {
                    if (i == "q" || i == "Q") return "Q";
                    if (i == "mng") return "mng";
                }
                valid = true;
                if (i.Length == 0)
                {
                    System.Console.WriteLine("No input");
                    valid = false;
                }
                else if (i.Length > length)
                {
                    System.Console.WriteLine("Input too long");
                    valid = false;
                }
                else if (!IsInt(i))
                {
                    System.Console.WriteLine("Input is not an integer");
                    valid = false;
                }
                else if (!IsIn(i, ops) || int.Parse(i) < 1)
                {
                    System.Console.WriteLine("Input outside of bounds");
                    valid = false;
                }
            }
            return i;
        }

        public int SelectFromList(string[] x)
        {
            string[] print = x;
            for (int i = 1; i <= x.Length; i++) print[i - 1] = $"{i}. " + print[i - 1];
            Output.PrintStringList(print);
            string[] ops = new string[x.Length];
            for (int i = 0; i < x.Length; i++) ops[i] = (i + 1) + "";
            return int.Parse(GetSmallNumber(ops,false));
        }

        private static bool IsInt(string x)
        {
            bool valid = true;
            for (int i = 0; i < x.Length; i++) valid = valid && x[i] >= '0' && x[i] <= '9';
            return valid;
        }

        private static string GetPrice()
        {
            string i = "";
            bool valid = false;
            while (!valid)
            {
                i = System.Console.ReadLine();
                valid = true;
                if (i.Length == 0)
                {
                    System.Console.WriteLine("No input");
                    valid = false;
                }
                else if (!IsInt(i))
                {
                    int k = i.IndexOf('.');
                    if (k != -1)
                    {
                        if (IsInt(i.Substring(0, k) + i.Substring(k + 1, i.Length - k - 1))) { }
                        else
                        {
                            System.Console.WriteLine("Input is not a number");
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("Input is not a number");
                    }
                }
            }
            return i;
        }

        internal static string GetName()
        {
            string i = "";
            bool valid = false;
            while (!valid)
            {
                valid = true;
                i = System.Console.ReadLine();
                if (i.Length < 1)
                {
                    System.Console.WriteLine("No input");
                }
                else
                {
                    string test = i;
                    int comma = i.IndexOf(',');
                    if (comma != -1) test = i.Substring(0, comma) + i.Substring(comma + 1, i.Length - comma - 1);
                    if (comma == 0 || comma == i.Length - 1)
                    {
                        System.Console.WriteLine("Nothing beside comma");
                    }
                    else for (int k = 0; k < test.Length && valid; k++)
                        {
                            if (!(test[k] >= 'a' && test[k] <= 'z' || test[k] >= 'A' && test[k] <= 'Z'))
                            {
                                valid = false;
                                System.Console.WriteLine("Invalid charecter(s)");
                            }
                        }
                }
            }
            return i;
        }

        static public string GetUnformatedName()
        {
            string i = "";
            bool valid = false;
            while (!valid)
            {
                valid = true;
                i = System.Console.ReadLine();
                if (i.Length < 1)
                {
                    System.Console.WriteLine("Input empty");
                    valid = false;
                }
            }
            return i;
        }

        public static string RegString(string x)
        {
            x = x.ToUpper();
            string output = "";
            for (int i = 0; i < x.Length; i++) if (x[i] >= 'A' && x[i] <= 'Z') output += x[i];
            return output;
        }

        private static bool IsIn(string x, string[] y)
        {
            bool output = false;
            for (int i = 0; i < y.Length; i++) output = output || x == y[i];
            return output;
        }
    }
}