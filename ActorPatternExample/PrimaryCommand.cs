using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorPatternExample
{
    public class PrimaryCommand : Command
    {
        public override void Execute(Actor actor)
        {
            Console.WriteLine("Execute PrimaryCommand");
            Command command = new InitializePrimaryCommand();
            actor.Push(command);
        }
    }
}
