#nullable enable
using System.Text.Json.Serialization;

namespace Disc.Models
{
    public class Copy
    {
        [JsonPropertyName("url")] public string? Url { get; set; }
    }

    public class Image
    {
        [JsonPropertyName("url")] public string? ImageUrl { get; set; }
        [JsonPropertyName("copies")] public List<Copy>? Copies { get; set; }
    }

    public class Link
    {
        [JsonPropertyName("url")] public string? LinkUrl { get; set; }
        [JsonPropertyName("hostname")] public string? Hostname { get; set; }
        [JsonPropertyName("image")] public Image? Image { get; set; }
    }

    public class Post
    {
        [JsonPropertyName("type")] public string? Type { get; set; }
        [JsonPropertyName("username")] public string? Username { get; set; }
        [JsonPropertyName("communityName")] public string? CommunityName { get; set; }
        [JsonPropertyName("title")] public string? Title { get; set; }
        [JsonPropertyName("link")] public Link? Link { get; set; }
        [JsonPropertyName("upvotes")] public int Upvotes { get; set; }
        [JsonPropertyName("downvotes")] public int Downvotes { get; set; }
        [JsonPropertyName("createdAt")] public DateTime CreatedAt { get; set; }
        //[JsonPropertyName("editedAt")] public object? EditedAt { get; set; }
        [JsonPropertyName("noComments")] public int NoComments { get; set; }
        //[JsonPropertyName("userVoted")] public string? UserVoted { get; set; }
        //[JsonPropertyName("userVotedUp")] public string? UserVotedUp { get; set; }
    }


    public class Root
    {
        [JsonPropertyName("posts")] public List<Post>? Posts { get; set; }
        [JsonPropertyName("next")] public string? Next { get; set; }
    }
}