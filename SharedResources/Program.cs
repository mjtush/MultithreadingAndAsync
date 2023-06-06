namespace SharedResources
{
    internal class Program
    {
        private static bool isCompleted;
        // In order to assure that message is printed only once, the lock is introduced
        private static readonly object lockCompleted = new object();

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
            /*That means every other thread that comes to lock line after first thread, 
             *  will have to wait until that particular 
             * thread is able to use this and finish*/
            lock (lockCompleted)
            {
                if (!isCompleted)
                {
                    isCompleted = true;
                    Console.WriteLine("Hello World should print only once");
                }
            }
        }
    }
}