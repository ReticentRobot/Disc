using Disc.Models;

namespace Disc.Services
{
    public interface IPostService
    {
        Task<List<PostItem>> GetTasksAsync();
    }
}
