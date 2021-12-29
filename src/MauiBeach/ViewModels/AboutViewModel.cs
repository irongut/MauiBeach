using MauiBeach.Services;
using Microsoft.Maui.Essentials;
using System;
using System.Text;

namespace MauiBeach.ViewModels;

internal class AboutViewModel
{
    public string AppVersion => $"Version: {AppInfo.VersionString}{Environment.NewLine}Copyright © 2021 Taranis Software";

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
}
