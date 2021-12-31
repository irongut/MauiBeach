using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace MauiBeach.ViewModels;

internal class HomeViewModel
{
    public ICommand AlertCommand { get; }

    public HomeViewModel()
    {
        AlertCommand = new Command(async () => await Shell.Current.DisplayAlert("Alert", "It's alerting!", "OK").ConfigureAwait(false));
    }
}
