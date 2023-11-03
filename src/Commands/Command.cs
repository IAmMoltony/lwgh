using System;

namespace Lwgh
{
    namespace Commands
    {
        public abstract class Command
        {
            protected string[] args;

            public Command(string[] args)
            {
                this.args = args;
            }

            public abstract int Run();
        }
    }
}