using System;

namespace Lwgh
{
    public class Program
    {
        public static int Main(string[] args)
        {
            switch (args[0])
            {
            case "help":
                return new Commands.HelpCommand(args).Run();
            case "info":
                return new Commands.InfoCommand(args).Run();
            case "user":
                return new Commands.UserCommand(args).Run();
            case "followers":
                return new Commands.FollowersCommand(args).Run();
            default:
                Console.Error.WriteLine($"Error: please specify a command\nRun 'lwgh help' for help.");
                return 1;
            }
        }
    }
}
