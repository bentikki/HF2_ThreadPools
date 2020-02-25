using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolOpgaver
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch mywatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");

            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();

            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + string.Format("{0:#,0.00}", mywatch.ElapsedTicks) + " ticks" );

            mywatch.Reset();
            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + string.Format("{0:#,0.00}", mywatch.ElapsedTicks) + " ticks");
            Console.ReadKey();
        }

        static void Process(object callBack)
        {
            //string s = (String)callBack;
            //Console.WriteLine("[{3} - {0}] ThreadPriority = {1} | IsBackground = {2}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.Priority, Thread.CurrentThread.IsBackground, s);
            
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {

                }
            }
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start("ProcessWithThreadMethod");
            }
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process, "ProcessWithThreadPoolMethod");
            }
        }
    }
}
