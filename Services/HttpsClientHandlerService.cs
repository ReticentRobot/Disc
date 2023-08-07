using RestSharp;

namespace Disc.Services
{
    public class HttpsClientHandlerService : IHttpsClientHandlerService
    {
        //FetchNextData vars
        public string baseUrl { get; set; } = Constants.RestUrl;
        public string endPoint { get; set; } //= "/posts?limit=" + Constants.PageSize;
        public RestClient client { get; set; } //= new RestClient();

        public async Task HttpClientHandler(string endPoint)
        {
            string url = baseUrl + endPoint;
            var request = new RestRequest(url);
            var content = await client.GetAsync(request);
        }
    }
}
