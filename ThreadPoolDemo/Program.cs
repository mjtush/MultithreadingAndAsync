using System;
using System.Threading;

namespace ThreadPoolDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            // Prints whether current thread is thread pool
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
#endif
            var employee = new Employee();
            employee.Name = "Mike Bike";
            employee.CompanyName = "Bike Road";

            ThreadPool.QueueUserWorkItem(
                new WaitCallback(DisplayEmployeeInfo), employee);

            // Checkin processor count which by defoult is min num of threads.
            // Number of threads in thread poll cannot be less than that.
            var processorCount = Environment.ProcessorCount;
            ThreadPool.SetMaxThreads(processorCount * 2, processorCount * 2);

            int workerThreads = 0;
            int completitionPortThreads = 0;
            ThreadPool.GetMinThreads(out workerThreads, out completitionPortThreads);

#if DEBUG
            // Prints whether current thread is thread pool
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
#endif
            Console.ReadKey();
        }

        private static void DisplayEmployeeInfo(object? employee)
        {
#if DEBUG
            // Prints whether current thread is thread pool
            Console.WriteLine(Thread.CurrentThread.IsThreadPoolThread);
#endif
            var emp = employee as Employee;

            if (emp is null)
            {
                throw new ArgumentNullException(nameof(emp));
            }

            Console.WriteLine($"Person name is {emp.Name} and " +
                $"company name is {emp.CompanyName}");
        }
    }

    public class Employee
    {
        public string Name { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
    }
}