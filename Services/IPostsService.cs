using Disc.Models;

namespace Disc.Services
{
    public interface IPostsService
    {
        Task<Posts> GetPosts();
    }
}
