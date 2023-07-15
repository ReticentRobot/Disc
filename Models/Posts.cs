using System.Text.Json.Serialization;

namespace Disc.Models
{
    public class Posts
    {
        //public string Id { get; }
        //[JsonPropertyName("type")] public string Type { get; }
        //public string PublicId { get; }
        //public string UserId { get; }
        //public string UserGroup { get; }
        //public string UserDeleted { get; }
        //public string IsPinned { get; }
        //public string CommunityId { get; }
        //[JsonPropertyName("communityName")] public string CommunityName { get; }
        [JsonPropertyName("title")] public string Title { get; }
        [JsonPropertyName("body")] public string Body { get; }
        //public string Locked { get; }
        //public string Upvotes { get; }
        //public string Downvotes { get; }
        //public string Hotness { get; }
        //public string CreatedAt { get; }
        //public string EditiedAt { get; }
        //public string LastActivityAt { get; }
        //public string Deleted { get; }
        //public string NoComments { get; }
        //public string CommentsNext { get; }
        //public string UserVoted { get; }

    }
}