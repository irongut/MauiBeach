namespace MauiBeach.Services;

internal static partial class DeviceInfoService
{
    internal static partial string Model() => DeviceInfo.Model;

    internal static partial string Platform() => $"{DeviceInfo.Platform} {DeviceInfo.VersionString}";
}
