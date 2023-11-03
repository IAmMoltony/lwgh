namespace Lwgh
{
    namespace Commands
    {
        public class HelpCommand : Command
        {
            public HelpCommand(string[] args) : base(args)
            {
            }

            public override int Run()
            {
                Console.WriteLine("Lwgh - GitHub browser in the terminal");

                if (args.Count() < 2)
                {
                    Console.WriteLine($"Usage: lwgh <command> [args]");
                    Console.WriteLine("Commands:");
                    Console.WriteLine(" help - show this help");
                    Console.WriteLine(" info - get basic info about a repository");
                    Console.WriteLine(" user - get info about a user");
                    Console.WriteLine($"\nRun 'lwgh help <command>' to get help about a specific command.");
                    return 0;
                }

                string cmd = args[1];
                switch (cmd)
                {
                case "help":
                    Console.WriteLine("help - show commands and usage");
                    break;
                case "info":
                    Console.WriteLine("info - show basic info about a repository");
                    Console.WriteLine("Usage: lwgh info <repo URL>");
                    Console.WriteLine("Repository URL format must be 'user/repo'.");
                    Console.WriteLine("Example: lwgh info dotnet/sdk");
                    break;
                case "user":
                    Console.WriteLine("user - show info about a user");
                    Console.WriteLine("Usage: lwgh user <username>");
                    Console.WriteLine("Example: lwgh user octocat");
                    break;
                default:
                    Console.WriteLine($"Unknown command: {cmd}");
                    return 1;
                }

                return 0;
            }
        }
    }
}
