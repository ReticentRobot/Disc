﻿using Disc.Models;
using System.Windows.Input;


namespace Disc.ViewModels
{
    public class ImageViewModel : BaseViewModel
    {
        // Declare a property to store the link object
        public Link Link { get; set; }

        // Declare a constructor that takes a link parameter
        public ImageViewModel(string linkUrl)
        {
            // Create a new Link object and set its LinkUrl property to the linkUrl parameter
            Link link = new Link();
            link.LinkUrl = linkUrl;

            // Assign the link object to the Link property
            Link = link;

            // Initialize the GoBackCommand property
            GoBackCommand = new Command(async () => await Application.Current.MainPage.Navigation.PopModalAsync());
        }

        // Declare the GoBackCommand property
        public ICommand GoBackCommand { get; set; }
    }
}