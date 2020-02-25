using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorPatternExample
{
    public class SecondaryCommand : Command
    {
        public override void Execute(Actor actor)
        {
            Console.WriteLine("Execute SecondaryCommand");
            Command command = new InitializeSecondaryCommand();
            actor.Push(command);
        }
    }
}
