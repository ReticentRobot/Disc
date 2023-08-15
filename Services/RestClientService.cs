using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Disc.Services
{
    public class RestService : IRestClientService
    {
        //FetchNextData vars
        public string baseUrl { get; set; } = Constants.RestUrl;
        //public string endPoint { get; set; } //= "/posts?limit=" + Constants.PageSize;
        public RestClient client { get; set; } //= new RestClient();

        public RestService(string baseUrl)
        {
            Console.WriteLine("Setting Client Options");
            var clientoptions = new RestClientOptions(baseUrl)
            {
                //todo?
            };

            Console.WriteLine("Creating Client");
            client = new RestClient(
                                    clientoptions,
                                    configureSerialization: s => s.UseNewtonsoftJson()
                );
            Console.WriteLine("Client Value: " + client);
        }
    }
}
