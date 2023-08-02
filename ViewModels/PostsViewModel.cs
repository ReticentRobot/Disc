using Disc.Models;
using System.Windows.Input;
using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json;
using RestSharp.Serializers.NewtonsoftJson;
using Newtonsoft.Json.Linq;

namespace Disc.ViewModels;

public partial class PostsViewModel : BaseViewModel
{
    //Get Posts Root Data
    private Root _Data;
    public Root Data { get => _Data; set { _Data = value; OnPropertyChanged(nameof(Data)); } }



    private string _type;
    public string Type { get =>  _type; set { _type = value; OnPropertyChanged(nameof(Type)); } }
    private string _username;
    public string Username { get => _username; set { _username = value; OnPropertyChanged(nameof(Username)); } }
    private string _communityName;
    public string CommunityName { get => _communityName; set { _communityName = value; OnPropertyChanged(nameof(CommunityName)); } }
    private string _title;
    public string Title { get => _title; set { _title = value; OnPropertyChanged(nameof(Title)); } }
    private string _body;
    public string Body { get => _body; set { _body = value; OnPropertyChanged(nameof(Body)); } }
    private string _noComments;
    public string NoComments { get => _noComments; set { _noComments = value; OnPropertyChanged(nameof(NoComments)); } }

    //Get Post Image Data
    private Disc.Models.Image _Image;
    public Disc.Models.Image Image { get => _Image; set { _Image = value; OnPropertyChanged(nameof(Image)); } }
    private string _imageurl;
    public string ImageUrl { get => _imageurl; set { _imageurl = value; OnPropertyChanged(nameof(ImageUrl)); } }

    //Get Post Link Data
    private Disc.Models.Link _Link;
    public Disc.Models.Link Link { get => _Link; set { _Link = value; OnPropertyChanged(nameof(Link)); } }
    private string _linkurl;
    public string LinkUrl { get => _linkurl; set { _linkurl = value; OnPropertyChanged(nameof(LinkUrl)); } }

    /*
    public ICommand LoadPostsCommand { get; set; }

    public PostsViewModel() 
    {
        LoadPostsCommand = new Command(async () => await LoadPosts());
    }
    */

    /*
    [RelayCommand]
    void Appearing()
    {
        LoadPostsCommand = new Command(async () => await LoadPosts());
    }

    [RelayCommand]
    void Disappearing()
    {
        // Do something when the page disappears
    }
    */

    public async Task LoadPosts()
    {
        //create a request to the api
        var clientoptions = new RestClientOptions("https://discuit.net/api")
        {
            //Authenticator = new HttpBasicAuthenticator("discapp", "testing123")
        };
        var client = new RestClient(
            clientoptions,
            configureSerialization: s => s.UseNewtonsoftJson()
        );
        //client.AddDefaultParameter("feed", "all");      //One of: home, all, community.
        //client.AddDefaultParameter("filter", "all");    //One of: all, deleted, locked. If not set, all is the default.*
        //client.AddDefaultParameter("sort", "hot");      //One of: latest, hot, activity, day, week, month, year, all.
        var request = new RestRequest("/posts");
        var content = await client.GetAsync(request);

        //set json options
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        if (content.StatusCode.ToString() == "OK")
        {
            Data = JsonSerializer.Deserialize<Root>(content.Content, options);
            
            //var posts = JsonSerializer.Deserialize<Post>(content.Content, options);
            //var images = JsonSerializer.Deserialize<Disc.Models.Image>(content.Content, options);
            //var links = JsonSerializer.Deserialize<Disc.Models.Link>(content.Content, options);
            //JToken linkurl = JObject.Parse(content.Content)["link"];

            //Posts Data
            /*var Type = posts.Type;
            var Username = posts.Username;
            var CommunityName = posts.CommunityName;
            var Title = posts.Title;
            var Body = posts.Body;
            var noComments = posts.NoComments;


            foreach (var post in Data.Posts)
            {
                Console.WriteLine("Type: " + post.Type);
                Console.WriteLine("Username: " + post.Username);
                Console.WriteLine("CommunityName: " + post.CommunityName);
                Console.WriteLine("Title: " + post.Title);
                Console.WriteLine("Body: " + post.Body);
                Console.WriteLine("NoComments: " + post.NoComments);

                //Console.WriteLine("Link: " + link.url);
            }
            */

        }
        else
        {
            Console.WriteLine("Error connecting to API");
        }
    }
}