using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Disc.Views;

public class LoginData
{
    [JsonPropertyName("username")] public string Username { get; set; }
    [JsonPropertyName("password")] public string Password { get; set; }
}

public partial class SubscriptionsPage : ContentPage
{
	public SubscriptionsPage()
	{
		InitializeComponent();

        // set url for api endpoint to initialize session
        var uri = new Uri("https://discuit.net/api/_initial");

        // create http client and request message to obtain SID and CSRF token from response headers
        HttpClientHandler handler = new HttpClientHandler();
        handler.UseCookies = true;
        handler.CookieContainer = new CookieContainer();
        HttpClient client = new HttpClient(handler);

        HttpResponseMessage repsonse = client.GetAsync(uri).Result;
        CookieCollection cookies = handler.CookieContainer.GetCookies(uri);

        // create new Dictionary to store cookie data
        var cookieList = new Dictionary<string, string>();

        // get Session ID and CSRF token into variables
        foreach ( Cookie cookie in cookies)
        {
            cookieList.Add(cookie.Name, cookie.Value);
        }

        var SID = cookieList["SID"];
        var csrftoken = cookieList["csrftoken"];

        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("SID: " + SID);
        Console.WriteLine("x-csrf-token: " + csrftoken);
        Console.WriteLine("-----------------------------------------");

        // new variable url set to login endpoint
        var url = new Uri("https://discuit.net/api/_login");

        // create a cookie container and add the SID to the api/_login url
        CookieContainer cookieContainer = new CookieContainer();
        cookieContainer.Add(url, new Cookie("SID", SID));

        // Add X-CSRF-Token to client
        client.DefaultRequestHeaders.Add("x-csrf-token", csrftoken);

        // create sample json with valid credentials
        // TODO: Get credentials from login page once this is working
        var login = new LoginData { Username = "discapp", Password = "testing123" };

        // send json login request to server using new http client with handler
        var result = client.PostAsJsonAsync(url, login).Result;
        
        if(result.IsSuccessStatusCode)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("StatusCode: " + result.StatusCode);
            Console.WriteLine("RESULT: " + result);
            Console.WriteLine("-----------------------------------------");
            // TODO: Return token
        }
        else
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"The web API returned an error: {result.StatusCode}");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("RESULT: " + result);
            Console.WriteLine("-----------------------------------------");
        }
        
    }
}