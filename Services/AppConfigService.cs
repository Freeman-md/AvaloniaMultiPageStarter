using AvaloniaMultiPageStarter.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaMultiPageStarter.Services;

public partial class AppConfigService: ObservableObject, IAppConfigService
{
    [ObservableProperty]
    private string _username = "Freeman";
    [ObservableProperty]
    private bool _isDarkMode = false;
    [ObservableProperty]
    private bool _hasCompletedOnboarding = false;
}