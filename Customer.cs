namespace p0
{
    class Customer
    {
        private string fname = "NULL";
        private string lname = "NULL";
        private string regname = "NULL";

        public Customer(string name)
        {
            SetName(name);
        }

        public Customer(string f, string l)
        {
            SetName(f, l);
        }

        public string GetName() { return fname + ( lname!="NULL" ? ", " + lname : "" ); }
        public string GetFName() { return fname; }
        public string GetLName() { return lname; }
        public string GetRName() { return regname; }

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
            regname = fname.ToUpper() + lname.ToUpper();
        }

    }
}