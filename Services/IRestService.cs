using Disc.Models;

namespace Disc.Services
{
    public interface IRestService
    {
        Task<List<PostItem>> RefreshDataAsync();
    }
}