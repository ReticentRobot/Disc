using Disc.Models;

namespace Disc.Services
{
    public class PostService : IPostService
    {
        IRestService _restService;

        public PostService(IRestService service)
        {
            _restService = service;
        }

        public Task<List<PostItem>> GetTasksAsync()
        {
            return _restService.RefreshDataAsync();
        }
    }
}