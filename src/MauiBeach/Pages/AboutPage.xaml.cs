using MauiBeach.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiBeach.Pages;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        InitializeComponent();
        BindingContext = new AboutViewModel();
    }
}
