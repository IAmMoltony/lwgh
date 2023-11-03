using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lwgh.User
{
    public class UserInfo
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("company")]
        public string? Company { get; set; }

        [JsonPropertyName("bio")]
        public string? Bio { get; set; }

        [JsonPropertyName("site_admin")]
        public bool IsSiteAdmin { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        [JsonPropertyName("blog")]
        public string? Blog { get; set; }

        [JsonPropertyName("twitter_username")]
        public string? TwitterUsername { get; set; }

        [JsonPropertyName("followers")]
        public int Followers { get; set; }

        [JsonPropertyName("following")]
        public int Following { get; set; }

        [JsonPropertyName("public_repos")]
        public int Repos { get; set; }

        [JsonPropertyName("pulic_gists")]
        public int Gists { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        public static UserInfo? Load(string name)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Lwgh/1.0");
            var task = Task.Run(() => client.GetAsync($"https://api.github.com/users/{name}"));
            task.Wait();
            var result = task.Result;
            bool success = true;
            if (!result.IsSuccessStatusCode)
            {
                Console.Error.WriteLine("*** User Load Error");
                Console.Error.WriteLine($"HTTP status code: {result.StatusCode}");
                success = false;
            }
            string response = result.Content.ReadAsStringAsync().Result;
            if (!success)
            {
                Console.Error.WriteLine(response);
                return null;
            }

            return JsonSerializer.Deserialize<UserInfo>(response);
        }
    }
}
