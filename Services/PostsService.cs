using Disc.Models;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;

//using Newtonsoft.Json;

namespace Disc.Services
{
    public class PostsService : IPostsService
    {
        public async Task<Posts> GetPosts()
        {
            var url = $"https://discuit.net/api/posts";
            var client = new HttpClient();
            var response = await client.GetAsync(url).ConfigureAwait(false);
            var successCode = await client.GetAsync(url);

            //validate connection
            if (successCode.IsSuccessStatusCode)
            {
                Console.WriteLine("Code 200 -  Successful Connection to REST API");

                //JObject root = JObject.Parse(response);
                
                var stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                Console.WriteLine("String Content = " + stringContent);
                var PostList = JsonSerializer.Deserialize<Posts>(stringContent, options);

                return JsonSerializer.Deserialize<Posts>(stringContent, options);
            }
            else
            {
                Console.WriteLine("Error connecting to API");
                return null;
            }
        }

        /*
        private readonly HttpClient httpClient;
        private const string ServerUrl = "https://discuit.net/api/posts?feed=home&sort=hot";
        

        var url = $"https://discuit.net/api/posts";
        var client = new HttpClient();

        public PostsService()
        {
            
            this.httpClient = httpClient;
            
        }

        public async Task<Posts> GetPosts()
        {
            Console.WriteLine("Entering GetTasksAsync");
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
        */
    }
}