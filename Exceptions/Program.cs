using System;
using System.Security;
using System.Threading;

namespace Exceptions
{
    internal class Program
    {
        // Exception handling is async PartialTrustVisibilityLevel of thread
        static void Main(string[] args)
        {
            //try
            //{
                // Worker thread
                new Thread(Demmo).Start();
            //}
            //// Main Thread
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        private static void Demmo()
        {   // Handle exceptions in the thread that they can occur
            try
            {
                throw null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}