using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Disc.Models;

namespace Disc.Services
{
    public class RestService //: IRestService
    {
//        HttpClient _client;

//        JsonSerializerOptions _serializerOptions;
//        IHttpsClientHandlerService _httpsClientHandlerService;

//        public List<LoginInfo> Items { get; private set; }

//        public RestService(IHttpsClientHandlerService service)
//        {
//#if DEBUG
//            _httpsClientHandlerService = service;
//            HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
//            if (handler != null)
//                _client = new HttpClient(handler);
//            else
//                _client = new HttpClient();
//#else
//            _client = new HttpClient();
//#endif
//            _serializerOptions = new JsonSerializerOptions
//            {
//                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
//                WriteIndented = true
//            };
//        }

//        public async Task LoginAsync(LoginInfo login)
//        {
//            Uri uri = new Uri(string.Format(Constants.RestUrl + "_login", string.Empty));

//            try
//            {

//                string json = JsonSerializer.Serialize<LoginInfo>(login, _serializerOptions);
//                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
//                Console.WriteLine("-----------------------------------------");
//                Console.WriteLine("Login: " + login);
//                Console.WriteLine("Content: " + json);
//                Console.WriteLine("Content: " + content);
//                Console.WriteLine("-----------------------------------------");

//                HttpResponseMessage response = null;
//                response = await _client.PostAsync(uri, content);
//                Console.WriteLine("-----------------------------------------");
//                Console.WriteLine("URI: " + uri);
//                Console.WriteLine("Content: " + response);
//                Console.WriteLine("-----------------------------------------");

//                if (response.IsSuccessStatusCode == true)
//                {
//                    Console.WriteLine("-----------------------------------------");
//                    Console.WriteLine(response.IsSuccessStatusCode);
//                    Console.WriteLine("Login Verified");
//                    Console.WriteLine("-----------------------------------------");
//                }
//                else
//                {
//                    Console.WriteLine("-----------------------------------------");
//                    Console.WriteLine(response.IsSuccessStatusCode);
//                    Console.WriteLine("Login Failed");
//                    Console.WriteLine("-----------------------------------------");
//                }
                    
//            }
//            catch (Exception ex)
//            {
//                Debug.WriteLine(@"\tERROR {0}", ex.Message);
//            }
//        }
    }
}