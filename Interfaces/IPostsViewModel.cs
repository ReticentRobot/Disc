using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Disc.Models;
using RestSharp;

namespace Disc.Interfaces
{
    public interface IPostsViewModel
    {
        // Properties
        Root Data { get; set; }
        Root Next { get; set; }
        string Body { get; set; }
        string CommunityName { get; set; }
        string CreatedAt { get; set; }
        string Downvotes { get; set; }
        string IsPinned { get; set; }
        string NoComments { get; set; }
        string Title { get; set; }
        string Type { get; set; }
        string Upvotes { get; set; }
        string Username { get; set; }
        Models.Image Image { get; set; }
        string ImageUrl { get; set; }
        Link Link { get; set; }
        string LinkUrl { get; set; }
        string Hostname { get; set; }

        // Method Properties
        string endPoint { get; set; }
        RestClient client { get; set; }

        // Methods
        Task LoadPosts();

        // Events
        // Add any events that the view model raises here
    }
}