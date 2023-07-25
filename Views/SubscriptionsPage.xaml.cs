using Microsoft.Maui.Controls.PlatformConfiguration;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;

namespace Disc.Views;

public class LoginData
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public partial class SubscriptionsPage : ContentPage
{
	public SubscriptionsPage()
	{
		InitializeComponent();

        //set url for api endpoint to initialize session
        var uri = new Uri("https://discuit.net/api/_initial");

        //create http client and request message to obtain SID and CSRF token from response headers
        var httpClient = new HttpClient();
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        var httpResponseMessage = httpClient.SendAsync(httpRequestMessage).Result;

        //get response headers to retrieve Session ID and CSRF token
        var headersResult = httpResponseMessage.Headers;

        //get Session ID and CSRF token into variables
        var cookies = httpResponseMessage.Headers.GetValues("Set-Cookie");
        //var splitCookies = cookies.Split(';');


        //ask bing tomorrow how to parse cookies from httpResponseMessage.Headers
        foreach (var cookie in cookies)
        {
            cookie.Split(';');
            Console.WriteLine(cookie);
        }


        var cookieList = cookies.ToList();
        var SID = cookieList[0];
        var csrftoken = cookieList[1];

        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("SID: " + SID);
        Console.WriteLine("csrftoken: " + csrftoken);
        Console.WriteLine("-----------------------------------------");


        //var httpLoginRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

        //httpLoginRequestMessage.Headers.Add("Cookie", SID) ;
        //httpLoginRequestMessage.Headers.Add("Cookie", csrftoken);

        // set url to login endpoint
        var url = new Uri("https://discuit.net/api/_login");

        // create a cookie container and add the cookies to it so we can send a POST request to login
        var cookieContainer = new CookieContainer();
        var handler = new HttpClientHandler() { CookieContainer = cookieContainer };
        var client = new HttpClient(handler);
        //HttpClient client = new HttpClient(handler);

        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("Adding Cookies to CookieContainer");
        Console.WriteLine("-----------------------------------------");

        // add the cookies to the cookie container
        cookieContainer.Add(url, new Cookie("SID", SID));
        cookieContainer.Add(url, new Cookie("csrftoken", csrftoken));

        //sample json
        /*
        LoginData login = new LoginData();
        login.Username = "ReticentRobot";
        login.Password = "testing123";
        */

        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("Creating JSON Data");
        Console.WriteLine("-----------------------------------------");

        var data = new
        {
            Username = "ReticentRobot",
            Password = "testing123"
        };

        //string json = JsonConvert.SerializeObject(login);
        //StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        // try logging into the site
        //string loginjson = JsonSerializer.Serialize(content);
        // HttpResponseMessage response = null;
        //response = await _client.PostAsync(uri, content);

        // Console.WriteLine("-----------------------------------------");
        //Console.WriteLine("JSON: " + json);
        // Console.WriteLine("-----------------------------------------");

        // Send json request to server

        
        

        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("Posting Data");
        Console.WriteLine("-----------------------------------------");

        // send json login request to server using new http client with handler
        var httpLoginResponseMessage = client.PostAsJsonAsync(url, data);
        //var httpLoginResponseMessage = httpClient.SendAsync(httpLoginRequestMessage).Result;

        Console.WriteLine("-----------------------------------------");
        Console.WriteLine("RESULT: " + httpLoginResponseMessage);
        Console.WriteLine("-----------------------------------------");

    }
}