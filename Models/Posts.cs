using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Disc.Models
{
    [JsonObject]
    public class Posts
    {
        //public string Id { get; }
        [JsonPropertyName("type")] public string Type { get; set; }
        //public string PublicId { get; }
        //public string UserId { get; }
        [JsonPropertyName("username")] public string Username { get; set; }
        //public string UserGroup { get; }
        //public string UserDeleted { get; }
        //public string IsPinned { get; }
        //public string CommunityId { get; }
        [JsonPropertyName("communityName")] public string CommunityName { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("body")] public string Body { get; set; }
        //public string Locked { get; }
        //public string Upvotes { get; }
        //public string Downvotes { get; }
        //public string Hotness { get; }
        //public string CreatedAt { get; }
        //public string EditiedAt { get; }
        //public string LastActivityAt { get; }
        //public string Deleted { get; }
        [JsonPropertyName("noComments")] public string NoComments { get; set; }
        //public string CommentsNext { get; }
        //public string UserVoted { get; }

    }
}