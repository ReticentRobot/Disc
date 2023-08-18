#nullable enable
using Disc.Interfaces;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;
using System.Diagnostics;

namespace Disc.Services
{
    public class RestService : IRestClientService
    {
        //FetchNextData vars
        public string? baseUrl { get; set; } = Constants.RestUrl;
        //public string endPoint { get; set; } //= "/posts?limit=" + Constants.PageSize;
        public RestClient? client { get; set; } //= new RestClient();

        public RestService(string baseUrl)
        {
            try
            {
                Debug.WriteLine("Setting Client Options");
                var clientoptions = new RestClientOptions(baseUrl)
                {
                    //todo?
                };

                Debug.WriteLine("Creating Client");
                client = new RestClient(
                                        clientoptions,
                                        configureSerialization: s => s.UseNewtonsoftJson()
                    );
                Debug.WriteLine("Client Value: " + client);
            }
            catch (NullReferenceException e)
            {
                // Handle the NullReferenceException error
                Debug.WriteLine(e.Message);
            }
        }
    }
}
