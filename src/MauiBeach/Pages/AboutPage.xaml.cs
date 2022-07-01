using MauiBeach.ViewModels;

namespace MauiBeach.Pages;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
        BindingContext = new AboutViewModel();
    }
}