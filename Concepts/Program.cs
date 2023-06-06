namespace Concepts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(PrintHelloWorld);
            //Worker thread
            thread.Start();
            thread.IsBackground = true;

            // Main Thread
            // Join called in main thread on worker, causes that main waits till worker finishes.
            thread.Join();
            Console.WriteLine("Hello World printed");
        }

        private static void PrintHelloWorld()
        {
            Console.WriteLine("Hello World!");
            Thread.Sleep(5000);
        }
    }
}