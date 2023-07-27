using Disc.Models;
using System.Text.Json;
using System.Windows.Input;

namespace Disc.ViewModels;

public class PostsViewModel : BaseViewModel
{
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

    public ICommand LoadPostsCommand { get; set; }

    public PostsViewModel() 
    {
        LoadPostsCommand = new Command(async () => await LoadPosts());
    }
    private async Task LoadPosts()
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

            var data = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var posts = JsonSerializer.Deserialize<Posts>(data, options);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Data: " + data);
            Console.WriteLine("Posts: " + posts);
            Console.WriteLine("-----------------------------------");

            var Type = posts.Type;
            var Username = posts.Username;
            var CommunityName = posts.CommunityName;
            var Title = posts.Title;
            var Body = posts.Body;    
        }
        else
        {
            Console.WriteLine("Error connecting to API");
        }
    }
}