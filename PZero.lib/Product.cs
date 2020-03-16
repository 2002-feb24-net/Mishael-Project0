namespace PZero.lib
{
    public class Product
    {
        string name;
        double price;
        string regname;

        public Product(string n, double p)
        {
            name = n;
            price = p;
            SetRegName();
        }

        public string GetName() { return name; }
        public double GetPrice() { return price; }
        public string GetRegname() { return regname; }

        private void SetRegName()
        {
            regname = name.ToUpper();
            while (regname.IndexOf(' ') != -1)
            {
                int i = regname.IndexOf(' ');
                regname = regname.Substring(0, i) + regname.Substring(i + 1, regname.Length - i - 1);
            }
        }

        public void ChangePrice(double x)
        {
            price = x;
        }

        public void SetName(string x)
        {
            name = x;
        }
    }
}