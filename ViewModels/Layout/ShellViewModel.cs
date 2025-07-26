using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AvaloniaMultiPageStarter.ViewModels.Pages;

namespace AvaloniaMultiPageStarter.ViewModels.Layout;


public enum PageType
{
    Home,
    Settings,
    About
}

public partial class ShellViewModel : ObservableObject
{
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


    public ShellViewModel()
    {
        ShowHome();
    }

    [RelayCommand]
    private void ShowHome() {
        CurrentViewModel = new HomeViewModel();
        CurrentPage = PageType.Home;
    }

    [RelayCommand]
    private void ShowSettings() {
        CurrentViewModel = new SettingsViewModel();
        CurrentPage = PageType.Settings;
    }

    [RelayCommand]
    private void ShowAbout() {
        CurrentViewModel = new AboutViewModel();
        CurrentPage = PageType.About;
    }
}
