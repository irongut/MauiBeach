using Android.OS;

namespace MauiBeach.Services;

internal static partial class DeviceInfoService
{
    internal static partial string Model() => Build.Model;

    internal static partial string Platform()
    {
        return $"Android {Build.VERSION.Release} (API {AndroidSDK()} - {AndroidCodename()})";
    }

    private static string AndroidCodename()
    {
        return (int)Build.VERSION.SdkInt switch
        {
            (int)BuildVersionCodes.Lollipop or (int)BuildVersionCodes.LollipopMr1 => "Lollipop",
            (int)BuildVersionCodes.M => "Marshmallow",
            (int)BuildVersionCodes.N or (int)BuildVersionCodes.NMr1 => "Nougat",
            (int)BuildVersionCodes.O or (int)BuildVersionCodes.OMr1 => "Oreo",
            (int)BuildVersionCodes.P => Build.VERSION.Release == "10" ? "Q Beta" : "Pie",
            (int)BuildVersionCodes.Q => "Q",
            (int)BuildVersionCodes.R => "R",
            (int)BuildVersionCodes.S => "S",
            32 => "Sv2",
            _ => "Unknown",
        };
    }

    private static int AndroidSDK()
    {
        return ((int)Build.VERSION.SdkInt == 28 && Build.VERSION.Release == "10") ? 29 : (int)Build.VERSION.SdkInt;
    }
}
