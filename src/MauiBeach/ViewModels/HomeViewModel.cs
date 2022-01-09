using Microsoft.Maui.Controls;
using MonkeyCache.FileStore;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiBeach.ViewModels;

internal class HomeViewModel : INotifyPropertyChanged
{
    private const string key = "dateCache";

    public ICommand AlertCommand { get; }
    public ICommand ActionSheetCommand { get; }
    public ICommand PromptCommand { get; }
    public ICommand UpdateCacheCommand { get; }
    public ICommand ClearCacheCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    private string _cacheValue;
    public string CacheValue { get => _cacheValue; set => SetProperty(ref _cacheValue, value); }

    public HomeViewModel()
    {
        Barrel.ApplicationId = "com.taranissoftware.mauibeach";

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

        UpdateCacheCommand = new Command(() =>
        {
            string data = DateTime.Now.ToString();
            Barrel.Current.Add(key, data, TimeSpan.FromMinutes(2));
            CacheValue = data;
        });

        ClearCacheCommand = new Command(() =>
        {
            Barrel.Current.Empty(key);
            CacheValue = "Empty";
        });

        if (Barrel.Current.Exists(key))
        {
            CacheValue = Barrel.Current.IsExpired(key) ? "Expired" : Barrel.Current.Get<string>(key);
        }
        else
        {
            CacheValue = "Empty";
        }
    }

    protected bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
    {
        if (!Equals(field, newValue))
        {
            field = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        return false;
    }
}
