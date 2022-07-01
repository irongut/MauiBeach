using MauiBeach.Services;
using System.Text;
using System.Windows.Input;

namespace MauiBeach.ViewModels;

internal class AboutViewModel
{
    public ICommand BlogCommand { get; }
    public ICommand GitHubCommand { get; }

    public string AppVersion => $"Version: {AppInfo.VersionString}{Environment.NewLine}Copyright © 2021 Taranis Software";

    public string Description => "A playground for experiments with .Net MAUI. All code is available on GitHub and development is documented on my blog 'Sailing the Sharp Sea'.";

    public string Platform
    {
        get
        {
            StringBuilder platform = new();
            platform.Append("Platform: ").AppendLine(DeviceInfoService.Platform());
            platform.Append("Manufacturer: ").AppendLine(DeviceInfo.Manufacturer);
            platform.Append("Device: ").AppendLine(DeviceInfoService.Model());

            return platform.ToString();
        }
    }

    public AboutViewModel()
    {
        BlogCommand = new Command(async () => await OpenBlogAsync().ConfigureAwait(false));
        GitHubCommand = new Command(async () => await OpenGitHubAsync().ConfigureAwait(false));
    }

    private async Task OpenBlogAsync()
    {
        try
        {
            await Browser.OpenAsync(new Uri("https://blog.taranissoftware.com/"), BrowserLaunchMode.External).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK").ConfigureAwait(false);
        }
    }

    private async Task OpenGitHubAsync()
    {
        try
        {
            await Browser.OpenAsync(new Uri("https://github.com/irongut/MauiBeach"), BrowserLaunchMode.External).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK").ConfigureAwait(false);
        }
    }
}
