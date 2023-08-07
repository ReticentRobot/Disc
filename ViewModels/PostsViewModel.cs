using Disc.Models;
using System.Windows.Input;
using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json;
using RestSharp.Serializers.NewtonsoftJson;
using System.Collections.ObjectModel;

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

    //FetchNextData vars
    public string baseUrl { get; set; } = Constants.RestUrl;
    public string endPoint { get; set; } = "/posts?limit=" + Constants.PageSize;
    public RestClient client { get; set; } //= new RestClient();

    // Bindable Property to check if data is loading
    //public bool IsLoadingMoreItems { get; set; } = false;
    //public static readonly BindableProperty IsLoadingMoreItemsProperty = BindableProperty.Create(nameof(IsLoadingMoreItems), typeof(bool), typeof(PostsViewModel), false);

    public ObservableCollection<Post> Posts { get; set; }

    // constructor to initialize objects
    public PostsViewModel()
    {
        var clientoptions = new RestClientOptions(baseUrl)
        {
            //Authenticator = new HttpBasicAuthenticator("discapp", "testing123")
        };

        client = new RestClient(
                                clientoptions,
                                configureSerialization: s => s.UseNewtonsoftJson()
            );

        Posts = new ObservableCollection<Post>();
    }

    //bool flag = false;

    public async Task LoadPosts()
    {
        //if (flag) return;
        //flag = true;

        //IsLoadingMoreItems = false;
        Console.WriteLine("********************");
        Console.WriteLine("LoadPosts() Launched");
        Console.WriteLine("********************");
        string url = baseUrl + endPoint;

        // add the parameter for Next page of data
        if (Data != null && !string.IsNullOrEmpty(Data.Next))
        {
            url += "&next=" + Data.Next;
            Console.WriteLine("................................................................................");
            Console.WriteLine("New URL: " + url);
            Console.WriteLine("................................................................................");
        }

        var request = new RestRequest(url);
        var TotalPostsBeforePull = Posts.Count; //Total number of posts before pulling new posts
        var content = await client.GetAsync(request);

        //set json options
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        if (content.StatusCode.ToString() == "OK")
        {
            //IsLoadingMoreItems = true;
            Data = JsonSerializer.Deserialize<Root>(content.Content, options);

            var NewPosts = Data.Posts.Count; //Total number of new posts grabbed
            Console.WriteLine("---------");
            Console.WriteLine("Status OK");
            Console.WriteLine("---------");
            Console.WriteLine("....................................................");
            Console.WriteLine("Number of Posts in pull: " + NewPosts);

            var PostsCount = NewPosts + TotalPostsBeforePull; //Total number of posts after pulling new posts
            Console.WriteLine("Total number of posts after pulling new posts: " + PostsCount);
            Console.WriteLine("....................................................");
            Console.WriteLine(".....................................................................");

            var Index = NewPosts - Constants.PageSize; //Get the root index of the new posts pulled in
            
            while (NewPosts > Index) //while the total number of posts is greater than the total number of posts minus the limit of posts to add
            {
                Posts.Add(Data.Posts[Index]);
                Console.WriteLine("Current Post Index: (" + Index + ")" + Data.Posts[Index].Title);
                Index++;
            }
            //flag = false;
            Console.WriteLine(".....................................................................");
        }
        else
        {
            Console.WriteLine("Error connecting to API");
        } 
    }
}

//public async Task LoadPosts()
//{
//    //create a request to the api
//    var clientoptions = new RestClientOptions(baseUrl)
//    {
//        //Authenticator = new HttpBasicAuthenticator("discapp", "testing123")
//    };
//    var client = new RestClient(
//                        clientoptions,
//                        configureSerialization: s => s.UseNewtonsoftJson()
//    );
//    //client.AddDefaultParameter("feed", "all");      //One of: home, all, community.
//    //client.AddDefaultParameter("filter", "all");    //One of: all, deleted, locked. If not set, all is the default.*
//    //client.AddDefaultParameter("sort", "hot");      //One of: latest, hot, activity, day, week, month, year, all.
//    string endPoint = "/posts";
//    var request = new RestRequest(endPoint);
//    var content = await client.GetAsync(request);

//    //set json options
//    var options = new JsonSerializerOptions
//    {
//        PropertyNameCaseInsensitive = true,
//    };

//    if (content.StatusCode.ToString() == "OK")
//    {
//        Data = JsonSerializer.Deserialize<Root>(content.Content, options);
//        Console.WriteLine("Status OK");
//    }
//    else
//    {
//        Console.WriteLine("Error connecting to API");
//    }
//}

//get next data function to be called from the code behind
//public async void FetchNextData()
//{
//    Console.WriteLine("Threshold Reached");

//    //create a request to the api with the next page string
//    request = new RestRequest(endPoint + "?" + Data.Next);

//    //get next results
//    content = await client.GetAsync(nextrequest);

//    if (content.StatusCode.ToString() == "OK")
//    {
//        Console.WriteLine("Status OK");
//        Data = JsonSerializer.Deserialize<Root>(content.Content, options);
//    }
//    else
//    {
//        Console.WriteLine("Error connecting to API");
//    }
//}

