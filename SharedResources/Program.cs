namespace SharedResources
{
    internal class Program
    {
        private static bool isCompleted;

        // The message should be printed only once
        static void Main(string[] args)
        {
            Thread thread = new Thread(HelloWorld);
            // Worker Thread
            thread.Start();

            // Main Thread
            HelloWorld();
        }

        private static void HelloWorld()
        {
            if (!isCompleted)
            {
                Console.WriteLine("Hello World should print only once");
                isCompleted = true;
            }
            
        }
    }
}