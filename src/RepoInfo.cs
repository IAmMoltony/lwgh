using System.ComponentModel;
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
        public RepoLicenseInfo License { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("homepage")]
        public string HomePage { get; set; }

        [JsonPropertyName("default_branch")]
        public string DefaultBranch { get; set; }

        [JsonPropertyName("open_issues_count")]
        public int OpenIssues { get; set; }

        [JsonPropertyName("size")]
        public int SizeKilobytes { get; set; }

        [JsonPropertyName("archived")]
        public bool IsArchived { get; set; }

        [JsonPropertyName("fork")]
        public bool IsFork { get; set; }

        [JsonPropertyName("parent")]
        public RepoParentInfo Parent { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("pushed_at")]
        public DateTime PushedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("topics")]
        public string[] Topics { get; set; }
    }
}