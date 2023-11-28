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
            case "languages":
                return new Commands.LanguagesCommand(args).Run();
            case "octocat":
                return new Commands.OctocatCommand(args).Run();
            default:
                Console.Error.WriteLine("Error: no command specified.\nRun 'lwgh help' for help.");
                return 1;
            }
        }
    }
}
