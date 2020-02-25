using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorPatternExample
{
    // Run to completion
    class Program
    {
        static void Main(string[] args)
        {
            Actor actor = new Actor();
            Command command = new SecondaryCommand();
            actor.Push(command);
            command = new PrimaryCommand();
            actor.Push(command);
            actor.Run();

            Console.Write("Press any key to continue . . .");
            Console.ReadKey();
        }
    }
}
