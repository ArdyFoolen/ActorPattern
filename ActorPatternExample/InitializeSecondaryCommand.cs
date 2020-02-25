using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorPatternExample
{
    public class InitializeSecondaryCommand : Command
    {
        public override void Execute(Actor actor)
        {
            Console.WriteLine("  Execute Secondary InitializeCommand");
            Command command = new TeardownSecondaryCommand();
            actor.Push(command);
        }
    }
}
