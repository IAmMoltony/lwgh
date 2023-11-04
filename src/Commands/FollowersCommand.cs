using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Lwgh.Commands
{
    public class FollowersCommand : Command
    {
        public FollowersCommand(string[] args) : base(args)
        {
        }

        public override int Run()
        {
            int page = args.Count() == 3 ? int.Parse(args[2]) : 1;
            string userName = args[1];
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Lwgh/1.0");
            var task = Task.Run(() => client.GetAsync($"https://api.github.com/users/{userName}/followers?page={page}"));
            task.Wait();
            var result = task.Result;
            bool success = true;
            if (!result.IsSuccessStatusCode)
            {
                Console.Error.WriteLine("*** User Followers Load Error");
                Console.Error.WriteLine($"HTTP status code: {result.StatusCode}");
                success = false;
            }
            string response = result.Content.ReadAsStringAsync().Result;
            if (!success)
            {
                Console.Error.WriteLine(response);
                return 1;
            }

            List<JsonElement>? followers = JsonSerializer.Deserialize<List<JsonElement>>(response);
            if (followers == null)
            {
                Console.WriteLine($"User {userName} has no followers.");
            }
            else
            {
                Console.WriteLine($"Page {page}");
                for (int i = 0; i < followers.Count; i++)
                {
                    string? name = followers[i].GetProperty("login").GetString();
                    Console.WriteLine($"{i + 1 + 30 * (page - 1)}: @{name ?? "(unknown)"}");
                }
            }

            return 0;
        }
    }
}
