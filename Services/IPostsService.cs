using Disc.Models;

namespace Disc.Services
{
    public interface IPostsService
    {
        Task<Posts> GetTasksAsync();
        //Task<Posts> GetPosts();
    }
}
