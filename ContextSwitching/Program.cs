namespace ContextSwitching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(WriteUsingNewThread);

            // Worker Thread
            thread.Start();
            thread.Name = "MyWorker";

            // Main thread - alays has the UI on it
            Thread.CurrentThread.Name = "MyMain";
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(" A" + i + " ");
            }
        }

        private static void WriteUsingNewThread()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(" Z" + i + " ");
            }
        }

        // There is no real logic in execution of those two threads. System determines when 
        // switch the context.
        // Threading is quite complex.
    }
}