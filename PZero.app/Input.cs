namespace PZero.app
{

    enum InputType { select, mainSelect, price, name, unformatedName }
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
                    output = GetLetteredString();
                    break;
                case InputType.unformatedName:
                    output = GetUnformatedName();
                    break;
                default:
                    System.Console.WriteLine("no input type");
                    break;
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

        private static string GetLetteredString()
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