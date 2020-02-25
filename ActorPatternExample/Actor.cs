using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorPatternExample
{
    public class Actor
    {
        private Stack<Command> commands = new Stack<Command>();

        public void Push(Command command)
        {
            this.commands.Push(command);
        }

        public void Run()
        {
            while (this.commands.Count != 0)
            {
                Command command = this.commands.Pop();
                command.Execute(this);
            }
        }
    }
}
