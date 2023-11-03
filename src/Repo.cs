using System.Text.Json;

namespace Lwgh
{
    public class Repo
    {
        public RepoInfo info;

        public static Repo? Load(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Lwgh/1.0");
            var task = Task.Run(() => client.GetAsync($"https://api.github.com/repos/{url}"));
            task.Wait();
            var result = task.Result;
            bool success = true;
            if (!result.IsSuccessStatusCode)
            {
                Console.Error.WriteLine("*** Repo Load Error");
                Console.Error.WriteLine($"HTTP status code: {result.StatusCode}");
                success = false;
            }
            string response = result.Content.ReadAsStringAsync().Result;
            if (!success)
            {
                Console.Error.WriteLine(response);
                return null;
            }

            Repo repo = new()
            {
                info = JsonSerializer.Deserialize<RepoInfo>(response)
            };
            return repo;
        }
    }
}