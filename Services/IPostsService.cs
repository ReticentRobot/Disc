using Disc.Models;

namespace Disc.Services
{
    public interface IPostsService
    {
        Task<Post> GetPosts();
    }
}
