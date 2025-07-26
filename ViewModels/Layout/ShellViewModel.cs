using System;
using AvaloniaMultiPageStarter.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AvaloniaMultiPageStarter.ViewModels.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaMultiPageStarter.ViewModels.Layout;


public enum PageType
{
    Home,
    Settings,
    About
}

public partial class ShellViewModel : ObservableObject
{
    private readonly IServiceProvider _services;
    private readonly IAppConfigService _config;
    
    [ObservableProperty]
    private ViewModelBase? currentViewModel;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsHomeActive))]
    [NotifyPropertyChangedFor(nameof(IsSettingsActive))]
    [NotifyPropertyChangedFor(nameof(IsAboutActive))]
    private PageType currentPage;
    
    public bool IsHomeActive => CurrentPage ==  PageType.Home;
    public bool IsSettingsActive => CurrentPage ==  PageType.Settings;
    public bool IsAboutActive => CurrentPage ==  PageType.About;


    public ShellViewModel(
        IServiceProvider services,
        IAppConfigService config
        )
    {
        _services = services;
        _config = config;
        ShowHome();
    }

    [RelayCommand]
    private void ShowHome() {
        CurrentViewModel = _services.GetRequiredService<HomeViewModel>();
        CurrentPage = PageType.Home;
    }

    [RelayCommand]
    private void ShowSettings() {
        CurrentViewModel = _services.GetRequiredService<SettingsViewModel>();;
        CurrentPage = PageType.Settings;
    }

    [RelayCommand]
    private void ShowAbout() {
        CurrentViewModel = _services.GetRequiredService<AboutViewModel>();;
        CurrentPage = PageType.About;
    }
}
