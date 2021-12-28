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
            platform.Append("Platform: ").Append(DeviceInfo.Platform).Append(' ').AppendLine(DeviceInfo.VersionString);
            platform.Append("Manufacturer: ").AppendLine(DeviceInfo.Manufacturer);
            platform.Append("Device: ").AppendLine(DeviceInfo.Model);

            return platform.ToString();
        }
    }
}
