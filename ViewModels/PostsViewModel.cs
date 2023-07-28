using Disc.Models;
using System.Text.Json;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Disc.ViewModels;

public class PostsViewModel : BaseViewModel
{
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
    private string _url;
    public string Url { get => _url; set { _url = value; OnPropertyChanged(nameof(Url)); } }

    public ICommand LoadPostsCommand { get; set; }


    public PostsViewModel() 
    {
        LoadPostsCommand = new Command(async () => await LoadPosts());
    }

    public async Task LoadPosts()
    {
        var url = $"https://discuit.net/api/posts";
        var client = new HttpClient();
        var response = await client.GetAsync(url);
        var successCode = await client.GetAsync(url);

        // validate connection
        if (successCode.IsSuccessStatusCode)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Code 200 -  Successful Connection to REST API");
            Console.WriteLine("-----------------------------------");

            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            Data = JsonSerializer.Deserialize<Root>(content, options); 
            var posts = JsonSerializer.Deserialize<Post>(content, options);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Data: " + Data);
            Console.WriteLine("Posts: " + posts);
            Console.WriteLine("-----------------------------------");

            var Type = posts.Type;
            var Username = posts.Username;
            var CommunityName = posts.CommunityName;
            var Title = posts.Title;
            var Body = posts.Body;
            var noComments = posts.NoComments;
        }
        else
        {
            Console.WriteLine("Error connecting to API");
        }
    }
}