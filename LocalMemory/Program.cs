namespace LocalMemory
{
    internal class Program
    {
        // There witll be separate copies of local variable i
        static void Main(string[] args)
        {
            // Worker Thread
            new Thread(PrintOneToThirty).Start();

            // Main Thread
            PrintOneToThirty();
        }

        private static void PrintOneToThirty()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.Write(i + 1 + " ");
            }
        }
    }
}