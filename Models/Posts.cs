using System.Text.Json.Serialization;

namespace Disc.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class CommunityBannerImage
    {
        [JsonPropertyName("mimetype")] public string Mimetype { get; set; }
        [JsonPropertyName("width")] public int Width { get; set; }
        [JsonPropertyName("height")] public int Height { get; set; }
        [JsonPropertyName("size")] public int Size { get; set; }
        [JsonPropertyName("averageColor")] public string AverageColor { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }
        [JsonPropertyName("copies")] public List<Copy> Copies { get; set; }
    }

    public class CommunityProPic
    {
        [JsonPropertyName("mimetype")] public string Mimetype { get; set; }
        [JsonPropertyName("width")] public int Width { get; set; }
        [JsonPropertyName("height")] public int Height { get; set; }
        [JsonPropertyName("size")] public int Size { get; set; }
        [JsonPropertyName("averageColor")] public string AverageColor { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }
        [JsonPropertyName("copies")] public List<Copy> Copies { get; set; }
    }

    public class Copy
    {
        [JsonPropertyName("copyId")] public string CopyId { get; set; }
        [JsonPropertyName("width")] public int Width { get; set; }
        [JsonPropertyName("height")] public int Height { get; set; }
        [JsonPropertyName("size")] public int Size { get; set; }
        [JsonPropertyName("url")] public string Url { get; set; }
        [JsonPropertyName("objectFit")] public string ObjectFit { get; set; }
    }

    public class Image
    {
        [JsonPropertyName("mimetype")] public string Mimetype { get; set; }
        [JsonPropertyName("width")] public int Width { get; set; }
        [JsonPropertyName("height")] public int Height { get; set; }
        [JsonPropertyName("size")] public int Size { get; set; }
        [JsonPropertyName("averageColor")] public string AverageColor { get; set; }
        [JsonPropertyName("url")] public string ImageUrl { get; set; }
        [JsonPropertyName("copies")] public List<Copy> Copies { get; set; }
    }

    public class Link
    {
        [JsonPropertyName("url")] public string LinkUrl { get; set; }
        [JsonPropertyName("hostname")] public string Hostname { get; set; }
        [JsonPropertyName("image")] public Image Image { get; set; }
    }

    public class Post
    {
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("type")] public string Type { get; set; }
        [JsonPropertyName("publicId")] public string PublicId { get; set; }
        [JsonPropertyName("userId")] public string UserId { get; set; }
        [JsonPropertyName("username")] public string Username { get; set; }
        [JsonPropertyName("userGroup")] public string UserGroup { get; set; }
        [JsonPropertyName("userDeleted")] public bool UserDeleted { get; set; }
        [JsonPropertyName("isPinned")] public bool IsPinned { get; set; }
        [JsonPropertyName("communityId")] public string CommunityId { get; set; }
        [JsonPropertyName("communityName")] public string CommunityName { get; set; }
        [JsonPropertyName("communityProPic")] public CommunityProPic CommunityProPic { get; set; }
        [JsonPropertyName("communityBannerImage")] public CommunityBannerImage CommunityBannerImage { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("body")] public object Body { get; set; }
        [JsonPropertyName("link")] public Link Link { get; set; }
        [JsonPropertyName("locked")] public bool Locked { get; set; }
        [JsonPropertyName("lockedBy")] public object LockedBy { get; set; }
        [JsonPropertyName("lockedAt")] public object LockedAt { get; set; }
        [JsonPropertyName("upvotes")] public int Upvotes { get; set; }
        [JsonPropertyName("downvotes")] public int Downvotes { get; set; }
        [JsonPropertyName("hotness")] public object Hotness { get; set; }
        [JsonPropertyName("createdAt")] public DateTime CreatedAt { get; set; }
        [JsonPropertyName("editedAt")] public object EditedAt { get; set; }
        [JsonPropertyName("lastActivityAt")] public DateTime LastActivityAt { get; set; }
        [JsonPropertyName("deleted")] public bool Deleted { get; set; }
        [JsonPropertyName("deletedAt")] public object DeletedAt { get; set; }
        [JsonPropertyName("deletedContent")] public bool DeletedContent { get; set; }
        [JsonPropertyName("noComments")] public int NoComments { get; set; }
        [JsonPropertyName("comments")] public object Comments { get; set; }
        [JsonPropertyName("commentsNext")] public object CommentsNext { get; set; }
        [JsonPropertyName("userVoted")] public string UserVoted { get; set; }
        [JsonPropertyName("userVotedUp")] public string? UserVotedUp { get; set; }
    }

    
    public class Root
    {
        [JsonPropertyName("posts")] public List<Post> Posts { get; set; }
        [JsonPropertyName("next")] public string Next { get; set; }
    }
}