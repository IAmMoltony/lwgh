using System.Text.Json.Serialization;

namespace Lwgh
{
    public class RepoLicenseInfo
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}