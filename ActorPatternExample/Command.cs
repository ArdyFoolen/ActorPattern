using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorPatternExample
{
    public abstract class Command
    {
        public abstract void Execute(Actor actor);
    }
}
