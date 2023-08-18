using RestSharp;

namespace Disc.Interfaces
{
    public interface IRestClientService
    {
        // Declare the members that your service class must implement
        string baseUrl { get; set; }
        RestClient client { get; set; }
    }
}
