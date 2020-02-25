using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorPatternExample
{
    public class InitializePrimaryCommand : Command
    {
        public override void Execute(Actor actor)
        {
            Console.WriteLine("  Execute Primary InitializeCommand");
            Command command = new TeardownPrimaryCommand();
            actor.Push(command);
        }
    }
}
