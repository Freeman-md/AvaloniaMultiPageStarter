using AvaloniaMultiPageStarter.Interfaces;
using AvaloniaMultiPageStarter.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaMultiPageStarter.ViewModels.Pages;

public partial class HomeViewModel : ViewModelBase
{
    private readonly IAppConfigService _config;

    public string Username => _config.Username;

    public HomeViewModel(IAppConfigService config)
    {
        _config = config;

        // Optional: auto-refresh if Username changes
        _config.PropertyChanged += (_, e) =>
        {
            if (e.PropertyName == nameof(_config.Username))
                OnPropertyChanged(nameof(Username));
        };
    }
}