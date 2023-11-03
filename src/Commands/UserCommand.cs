using System;

namespace Lwgh.Commands
{
    public class UserCommand : Command
    {
        public UserCommand(string[] args) : base(args)
        {
        }

        public override int Run()
        {
            string userName = args[1];
            User.UserInfo? info = User.UserInfo.Load(userName);
            if (info == null)
            {
                Console.Error.WriteLine("Error: info is null");
                return 1;
            }

            Console.WriteLine($"User @{userName}");
            Console.WriteLine($"Name: {info.Name}");
            Console.WriteLine($"Company: {info.Company ?? "none"}");
            Console.WriteLine($"Bio: {info.Bio ?? "none"}");

            if (info.IsSiteAdmin)
            {
                Console.WriteLine("User is a site admin.");
            }
            else
            {
                Console.WriteLine("User is not a site admin.");
            }

            Console.WriteLine($"Location: {info.Location ?? "none"}");
            Console.WriteLine($"Website: {info.Blog ?? "none"}");
            Console.WriteLine($"Twitter username: {info.TwitterUsername ?? "none"}");
            Console.WriteLine($"{info.Followers} followers; {info.Following} following");
            Console.WriteLine($"{info.Repos} repositories; {info.Gists} gists");
            Console.WriteLine($"Email: {info.Email ?? "none"}");

            return 0;
        }
    }
}
