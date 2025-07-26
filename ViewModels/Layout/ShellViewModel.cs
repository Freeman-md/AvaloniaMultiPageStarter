using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AvaloniaMultiPageStarter.ViewModels.Pages;

namespace AvaloniaMultiPageStarter.ViewModels.Layout;

public partial class ShellViewModel : ObservableObject
{
    [ObservableProperty]
    private ViewModelBase? currentViewModel;

    public ShellViewModel()
    {
        ShowHome();
    }

    [RelayCommand]
    private void ShowHome() => CurrentViewModel = new HomeViewModel();

    [RelayCommand]
    private void ShowSettings() => CurrentViewModel = new SettingsViewModel();

    [RelayCommand]
    private void ShowAbout() => CurrentViewModel = new AboutViewModel();
}
