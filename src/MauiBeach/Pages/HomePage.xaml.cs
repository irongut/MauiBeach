using MauiBeach.ViewModels;
using Microsoft.Maui.Controls;

namespace MauiBeach.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        BindingContext = new HomeViewModel();
    }
}
