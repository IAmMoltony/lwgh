using System.Text.Json.Nodes;

namespace Lwgh.Commands
{
    public class InfoCommand : Command
    {
        public InfoCommand(string[] args) : base(args)
        {
        }

        public override int Run()
        {
            string repoFullName = args[1];
            Repo? repo = Repo.Load(repoFullName);
            if (repo == null)
            {
                Console.Error.WriteLine("Error: repo is null");
                return 1;
            }
            RepoInfo info = repo.info;

            Console.WriteLine($"Repository {repoFullName}");
            Console.WriteLine($"{info.Stars} stars");
            Console.WriteLine($"{info.Forks} forks");
            Console.WriteLine($"{info.Subscribers} subscribers");
            Console.WriteLine($"License: {info.License.Name}");
            Console.WriteLine($"Written in {info.Language ?? "[unknown language]"}");
            Console.WriteLine($"Home page: {info.HomePage}");
            Console.WriteLine($"Default branch: {info.DefaultBranch}");
            Console.WriteLine($"Size: {info.SizeKilobytes} KB ({info.SizeKilobytes / 1000} MB)");

            if (info.IsArchived)
            {
                Console.WriteLine("Repository is archived.");
            }
            if (info.IsFork)
            {
                Console.WriteLine($"Repository is a fork of {info.Parent.FullName}");
            }

            Console.WriteLine($"Description: {info.Description}");
            Console.WriteLine($"Created at {info.CreatedAt}; pushed at {info.PushedAt}; updated at " +
                              $"{info.UpdatedAt}");

            string topics = string.Join(", ", info.Topics);
            Console.WriteLine($"Topics: {topics}");

            return 0;
        }
    }
}