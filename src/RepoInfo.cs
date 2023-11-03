using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lwgh
{
    public class RepoInfo
    {
        [JsonPropertyName("stargazers_count")]
        public int Stars { get; set; }

        [JsonPropertyName("forks_count")]
        public int Forks { get; set; }

        [JsonPropertyName("subscribers_count")]
        public int Subscribers { get; set; }

        [JsonPropertyName("license")]
        public RepoLicenseInfo? License { get; set; }

        [JsonPropertyName("language")]
        public string? Language { get; set; }

        [JsonPropertyName("homepage")]
        public string? HomePage { get; set; }

        [JsonPropertyName("default_branch")]
        public string? DefaultBranch { get; set; }

        [JsonPropertyName("open_issues_count")]
        public int OpenIssues { get; set; }

        [JsonPropertyName("size")]
        public int SizeKilobytes { get; set; }

        [JsonPropertyName("archived")]
        public bool IsArchived { get; set; }

        [JsonPropertyName("fork")]
        public bool IsFork { get; set; }

        [JsonPropertyName("parent")]
        public RepoParentInfo? Parent { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("pushed_at")]
        public DateTime PushedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("topics")]
        public string[]? Topics { get; set; }

        // TODO extract code like this into its own function
        public static RepoInfo? Load(string url)
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

            return JsonSerializer.Deserialize<RepoInfo>(response);
        }
    }
}
