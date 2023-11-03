using System.Text.Json.Serialization;

namespace Lwgh
{
    public class RepoParentInfo
    {
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }
    }
}