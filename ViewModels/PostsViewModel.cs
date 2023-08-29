using Disc.Models;
using RestSharp;
using System.Text.Json;
using System.Collections.ObjectModel;
using Disc.Services;
using System.Diagnostics;

namespace Disc.ViewModels;

public partial class PostsViewModel : BaseViewModel
{
    //Get Root Data
    public Root Data { get; set; }

    //Get Pagination Data
    public Root Next { get; set; }

    //Get Posts Data
    public string Body { get; set; }
    public string CommunityName { get; set; }
    public string CreatedAt { get; set; }
    public string Downvotes { get; set; }

    public string IsPinned { get; set; }
    public string NoComments { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public string Upvotes { get; set; }
    public string Username { get; set; }

    //Get Post Image Data
    public Models.Image Image { get; set; }
    public string ImageUrl { get; set; }

    //Get Post Link Data
    public Link Link { get; set; }
    public string LinkUrl { get; set; }
    public string Hostname { get; set; }

    //FetchNextData vars
    public string baseUrl { get; set; } = Constants.RestUrl;
    public string feedSort { get; set; } = "&sort=hot";
    public string endPoint { get; set; } = "/posts?limit=" + Constants.PageSize;
    public RestClient client { get; set; }

    private readonly RestService _restService;

    public ObservableCollection<Post> Posts { get; set; }

    // constructor to initialize objects
    public PostsViewModel(IServiceProvider serviceProvider)
    {
        Debug.WriteLine("Setting _restService to restService");
        _restService = serviceProvider.GetRequiredService<RestService>();

        var client = _restService.client;
        Debug.WriteLine("Client Value in constructor: " + client);

        Posts = new ObservableCollection<Post>();
    }

    public async Task LoadPosts()
    {
        string url = baseUrl + endPoint + feedSort;

        // add the parameter for Next page of data
        if (Data != null && !string.IsNullOrEmpty(Data.Next))
        {
            url += "&next=" + Data.Next;
        }

        var request = new RestRequest(url);
        var TotalPostsBeforePull = Posts.Count; //Total number of posts before pulling new posts

        Debug.WriteLine("Client Value in LoadPosts: " + client); ;
        var content = await _restService.client.GetAsync(request);

        //set json options
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        if (content.StatusCode.ToString() == "OK")
        {
            Data = JsonSerializer.Deserialize<Root>(content.Content, options);

            var NewPosts = Data.Posts.Count; //Total number of new posts grabbed

            // Loop through the new posts and add them to Data.Posts
            var Target = 0;
            while (NewPosts > Target) 
            {
                Posts.Add(Data.Posts[Target]);
                Target++;
            }
        }
        else
        {
            Debug.WriteLine("Error connecting to API");
        }
    }
}
