using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActorModel
{
    class Program
    {
        static void Main(string[] args)
        {
            var actor = new Actor<string>(x => Console.WriteLine(x.ToUpper())).Start();
            var task1 = Task.Factory.StartNew(() => SendMessagesToActor(actor));
            var task2 = Task.Factory.StartNew(() => SendMessagesToActor(actor));
            Task.WaitAll(new[] { task1, task2 });
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("PRESS ENTER TO STOP THE ACTOR");
            Console.ReadLine();

            actor.Stop();

            Console.Write("Press any key to continue. . .");
            Console.ReadKey();
        }

        private static void SendMessagesToActor(Actor<string> actor)
        {
            var counter = 0;
            while (counter < 5)
            {
                actor.Send(String.Format("message #[{0}] from thread #[{1}]", counter,
                                         Thread.CurrentThread.ManagedThreadId));
                Thread.Sleep(100); // To avoid of OutOfMemory issues
                counter++;
            }
        }
    }
}
