using PZero.lib;
using System.Collections.Generic;

namespace PZero.app
{
    class Output
    {
        public static void PrintCustNames(List<Customer> x)
        {
            string[] print = new string[x.Count];
            for (int i = 0; i < x.Count; i++) print[i] = x[i].GetName() + " ";
            PrintStringList(print);
        }

        private static void PrintStringList(string[] x)
        {
            string output = "";

            for (int i = 0; i < x.Length; i++)
            {
                if (output.Length + x[i].Length < System.Console.WindowWidth)
                {
                    output += x[i];
                }
                else
                {
                    System.Console.WriteLine(output);
                    output = "";
                }
            }

            System.Console.WriteLine(output);
        }
    }
}