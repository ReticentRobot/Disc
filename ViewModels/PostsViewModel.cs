using Disc.Models;
using System.Windows.Input;
using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json;
using RestSharp.Serializers.NewtonsoftJson;

namespace Disc.ViewModels;

public partial class PostsViewModel : BaseViewModel
{
    //Get Root Data
    private Root _Data;
    public Root Data { get => _Data; set { _Data = value; OnPropertyChanged(nameof(Data)); } }
    
    //Get Pagination Data
    private Root _next;
    public Root Next { get => _next; set { _next = value; OnPropertyChanged(nameof(Next)); } }

    //Get Posts Data
    private string _body;
    public string Body { get => _body; set { _body = value; OnPropertyChanged(nameof(Body)); } }
    private string _communityName;
    public string CommunityName { get => _communityName; set { _communityName = value; OnPropertyChanged(nameof(CommunityName)); } }
    private string _createdAt;
    public string CreatedAt { get => _createdAt; set { _createdAt = value; OnPropertyChanged(nameof(CreatedAt)); } }
    private string _downvotes;
    public string Downvotes { get => _downvotes; set { _downvotes = value; OnPropertyChanged(nameof(Downvotes)); } }
    private string _isPinned;
    public string IsPinned { get => _isPinned; set { _isPinned = value; OnPropertyChanged(nameof(IsPinned)); } }
    private string _noComments;
    public string NoComments { get => _noComments; set { _noComments = value; OnPropertyChanged(nameof(NoComments)); } }
    private string _title;
    public string Title { get => _title; set { _title = value; OnPropertyChanged(nameof(Title)); } }
    private string _type;
    public string Type { get =>  _type; set { _type = value; OnPropertyChanged(nameof(Type)); } }
    private string _upvotes;
    public string Upvotes { get => _upvotes; set { _upvotes = value; OnPropertyChanged(nameof(Upvotes)); } }
    private string _username;
    public string Username { get => _username; set { _username = value; OnPropertyChanged(nameof(Username)); } }
    
    //Get Post Image Data
    private Models.Image _Image;
    public Models.Image Image { get => _Image; set { _Image = value; OnPropertyChanged(nameof(Image)); } }
    private string _imageurl;
    public string ImageUrl { get => _imageurl; set { _imageurl = value; OnPropertyChanged(nameof(ImageUrl)); } }

    //Get Post Link Data
    private Link _Link;
    public Link Link { get => _Link; set { _Link = value; OnPropertyChanged(nameof(Link)); } }
    private string _linkurl;
    public string LinkUrl { get => _linkurl; set { _linkurl = value; OnPropertyChanged(nameof(LinkUrl)); } }
    private string _hostname;
    public string Hostname { get => _hostname; set { _hostname = value; OnPropertyChanged(nameof(Hostname)); } }

    //Method Variables to be accessed in the code behind
    public string baseUrl { get; set; }
    public string endPoint { get; set; }
    public RestClient Client { get; set; }

    public async Task LoadPosts()
    {
        //create a request to the api
        string baseUrl = "https://discuit.net/api";
        var clientoptions = new RestClientOptions(baseUrl)
        {
            //Authenticator = new HttpBasicAuthenticator("discapp", "testing123")
        };
        var Client = new RestClient(
                            clientoptions,
                            configureSerialization: s => s.UseNewtonsoftJson()
        );
        //client.AddDefaultParameter("feed", "all");      //One of: home, all, community.
        //client.AddDefaultParameter("filter", "all");    //One of: all, deleted, locked. If not set, all is the default.*
        //client.AddDefaultParameter("sort", "hot");      //One of: latest, hot, activity, day, week, month, year, all.
        string endPoint = "/posts";
        var request = new RestRequest(endPoint);
        var content = await Client.GetAsync(request);

        //set json options
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        if (content.StatusCode.ToString() == "OK")
        {
            Data = JsonSerializer.Deserialize<Root>(content.Content, options);
            Console.WriteLine("Status OK");
        }
        else
        {
            Console.WriteLine("Error connecting to API");
        }
    }

    //get next data function to be called from the code behind
    public async void FetchNextData()
    {
        Console.WriteLine("Threshold Reached");

        //create a request to the api with the next page string
        var request = new RestRequest(endPoint + "?" + Data.Next);

        //get next results
        var content = await Client.GetAsync(request);

        //set json options
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        if (content.StatusCode.ToString() == "OK")
        {
            Console.WriteLine("Status OK");
            Data = JsonSerializer.Deserialize<Root>(content.Content, options);
        }
        else
        {
            Console.WriteLine("Error connecting to API");
        }
    }

}