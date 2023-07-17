using Disc.Models;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace Disc.Views;

public partial class HomePage : ContentPage
{
    public ObservableCollection<Posts> PostCollection { get; set; }

    public HomePage()
    {
        InitializeComponent();
    }

    async public void OnAppearing()
    {
        /*
        await RestService.GetPostData();
        var getPostData = await RestService.GetPostData();
        BindingContext = this;

        Hoping to get this working after figuring out how to get the data from the REST API into a ListView
        */
    }

    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public static async Task<Posts> GetPostData()
        {
            var url = $"https://discuit.net/api/posts";
            var client = new HttpClient();
            var response = await client.GetStringAsync(url);
            var successCode = await client.GetAsync(url);

            //validate connection
            if (successCode.IsSuccessStatusCode)
            {
                Console.WriteLine("Code 200 -  Successful Connection to REST API");

                JObject root = JObject.Parse(response);

                //Get JSON results into a list
                List<JToken> results = root["posts"].Children().ToList();

                int count = 0;
                while (count < 10)
                {
                    //create variables for data needed
                    string postType = (string)root["posts"][count]["type"];
                    string postUsername = (string)root["posts"][count]["username"];
                    string postCommunityName = (string)root["posts"][count]["communityName"];
                    string postTitle = (string)root["posts"][count]["title"];
                    string postBody = (string)root["posts"][count]["body"];
                    string postNoComments = (string)root["posts"][count]["noComments"];

                    Console.WriteLine(postTitle);
                    if (postBody != null)
                    {
                        Console.WriteLine(postBody);
                    }
                    Console.WriteLine(postType);
                    Console.WriteLine(postUsername);
                    Console.WriteLine(postCommunityName);
                    Console.WriteLine(postNoComments);

                    //PostCollection.Add(new Posts { Title = postTitle, Body = postBody });

                    count++;
                }

                //Get JSON results into a list
                IList<JToken> resultsB = root["posts"].Children().ToList();

                var PostCollection = new ObservableCollection<Posts>();
                count = 0;
                //serialize JSON results into .NET objects
                IList<Posts> postCollection = new List<Posts>();
                foreach (JToken result in results)
                {
                    //create variables for data needed
                    string postType = (string)root["posts"][count]["type"];
                    string postUsername = (string)root["posts"][count]["username"];
                    string postCommunityName = (string)root["posts"][count]["communityName"];
                    string postTitle = (string)root["posts"][count]["title"];
                    string postBody = (string)root["posts"][count]["body"];
                    string postNoComments = (string)root["posts"][count]["noComments"];

                    PostCollection.Add(new Posts
                    {
                        Type = "postType",
                        Username = "postUsername",
                        CommunityName = "postCommunityName",
                        Title = "postTitle",
                        Body = "postBody",
                        NoComments = "postNoComments"
                    });

                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    Posts postResult = result.ToObject<Posts>();

                    count++;
                }

                return null;
            }
            else
            {
                Console.WriteLine("Error connecting to API");
                return null;
            }
        }
    }

    async private void GetJSON_Clicked(object sender, EventArgs e)
    {
        var getPostData = await RestService.GetPostData();
        Console.WriteLine("Button Clicked");
    }
}