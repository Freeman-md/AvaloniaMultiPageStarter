using AvaloniaMultiPageStarter.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaMultiPageStarter.Services;

public partial class AppConfigService: ObservableObject, IAppConfigService
{
    [ObservableProperty]
    private string username = "Freeman";
    [ObservableProperty]
    private bool isDarkMode = false;
}