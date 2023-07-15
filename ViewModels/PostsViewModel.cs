using System.Runtime.CompilerServices;
using System.Windows.Input;
using Disc.Services;

namespace Disc.ViewModels;

public class PostsViewModel : BaseViewModel
{
	public const string DisplayName = "Posts";

	readonly IPostsService postsService;
	State state;
	string title;
	string body;

    public ICommand LoadPostsCommand { get; }

    public State State
    {
        get => state;
        set => SetProperty(ref state, value);
    }

    public string Title
    {
        get => title;
        set => SetProperty(ref title, value);
    }

    public string Body
    {
        get => body;
        set => SetProperty(ref body, value);
    }

    public PostsViewModel(IPostsService postsService)
    {
        this.postsService = postsService;

        LoadPostsCommand = new Command(async () => await LoadPosts());

        Task.Run(async () => await LoadPosts());

        return;
    }

    public int Position { get; set; }

    public string Type => DisplayName;

    private async Task LoadPosts()
    {
        try
        {
            State = State.Loading;

            var posts = await postsService.GetTasksAsync();

            Title = posts.Title;
            Body = posts.Body;

            State = State.Loaded;
        }
        catch (Exception ex)
        {
            State = State.Error;
        }
    }
}

public enum State
{
    None = 0,
    Loading = 1,
    Loaded = 2,
    Error = 3
}