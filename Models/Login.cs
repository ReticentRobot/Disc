using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Disc.Models
{
    [JsonObject]
    public class LoginInfo
    {
        [JsonPropertyName("username")] public string Username { get; set; }
        [JsonPropertyName("password")] public string Password { get; set; }
    }
}