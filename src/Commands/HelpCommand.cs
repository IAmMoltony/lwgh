using System;

namespace Lwgh.Commands
{
    public class HelpCommand : Command
    {
        private static string[] ValidCmds = {
            "help",
            "info",
            "user",
            "followers",
            "languages",
            "octocat",
        };

        private void ShowHelpFor(string cmd)
        {
            switch (cmd)
            {
            case "help":
                Console.WriteLine("help - show commands and their usage");
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
            case "followers":
                Console.WriteLine("followers - show a user's followers");
                Console.WriteLine("Usage: lwgh followers <username> [page]");
                Console.WriteLine("Example: lwgh followers octocat 4");
                break;
            case "languages":
                Console.WriteLine("languages - show the languages that a repo uses");
                Console.WriteLine("Usage: lwgh langs <repo URL>");
                Console.WriteLine("Example: lwgh langs dotnet/sdk");
                break;
            case "octocat":
                Console.WriteLine("octocat - show octocat saying the specified string");
                Console.WriteLine("Usage: lwgh octocat [string]");
                Console.WriteLine("If you don't specify a string, octocat will say something random.");
                Console.WriteLine("Example: lwgh octocat hello");
                Console.WriteLine("         lwgh octocat \"I am octocat.\"");
                break;
            default:
                Console.WriteLine($"Unknown command: {cmd}");
                break;
            }

        }

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
                Console.WriteLine(" followers - view a user's followers");
                Console.WriteLine(" languages - view the languages that a repo uses");
                Console.WriteLine(" octocat - show octocat");
                Console.WriteLine($"\nRun 'lwgh help <command>' to get help about a specific command, or 'lwgh help all' to get help about all commands (produces a lot of output).");
                return 0;
            }

            string cmd = args[1];
            if (cmd == "all")
            {
                foreach (string c in ValidCmds)
                {
                    ShowHelpFor(c);
                    Console.WriteLine(); // insert a newline
                }
            }
            else
            {
                ShowHelpFor(cmd);
            }

            return 0;
        }
    }
}

