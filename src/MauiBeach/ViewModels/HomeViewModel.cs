using Microsoft.Maui.Controls;
using System.Diagnostics;
using System.Windows.Input;

namespace MauiBeach.ViewModels;

internal class HomeViewModel
{
    public ICommand AlertCommand { get; }
    public ICommand ActionSheetCommand { get; }
    public ICommand PromptCommand { get; }

    public HomeViewModel()
    {
        AlertCommand = new Command(async () => await Shell.Current.DisplayAlert("Alert", "It's alerting!", "OK").ConfigureAwait(false));
        ActionSheetCommand = new Command(async () =>
        {
            string action = await Shell.Current.DisplayActionSheet("ActionSheet Demo", "Cancel", "View", "Rename", "Delete").ConfigureAwait(false);
            Debug.WriteLine($"ActionSheet Demo: {action}");
        });
        PromptCommand = new Command(async () =>
        {
            string prompt = await Shell.Current.DisplayPromptAsync("Question", "What is your name?").ConfigureAwait(false);
            Debug.WriteLine($"Prompt Demo: {prompt}");
        });
    }
}
