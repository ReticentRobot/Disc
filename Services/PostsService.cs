using Disc.Models;
using System.Text.Json;
//using Newtonsoft.Json;

namespace Disc.Services
{
    public class PostsService : IPostsService
    {
        private readonly HttpClient httpClient;
        private const string ServerUrl = "https://discuit.net/api/posts?feed=home&sort=hot";

        public PostsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Posts> GetTasksAsync()
        {
            var response = await httpClient.GetAsync(ServerUrl).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            Console.WriteLine("String Content = " + stringContent);

            return JsonSerializer.Deserialize<Posts>(stringContent, options);
        }
    }
}