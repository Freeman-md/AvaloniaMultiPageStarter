using AvaloniaMultiPageStarter.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaMultiPageStarter.ViewModels.Pages;

public partial class SettingsViewModel : ViewModelBase
{
    private readonly IAppConfigService _config;

    [ObservableProperty]
    private string inputName;

    public SettingsViewModel(IAppConfigService config)
    {
        _config = config;
        InputName = _config.Username;
    }

    [RelayCommand]
    private void SaveName()
    {
        if (!string.IsNullOrWhiteSpace(InputName))
            _config.Username = InputName;
    }
}