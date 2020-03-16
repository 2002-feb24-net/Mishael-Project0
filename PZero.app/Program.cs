namespace PZero.app
{

    class p0
    {
        static void Main()
        {
            Runner main = new Runner();
            bool running = true;
            while (running)
            {
                running = main.GetInput();
                if (running) running = main.Run();
            }
        }
    }
}