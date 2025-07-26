using System.ComponentModel;

namespace AvaloniaMultiPageStarter.Interfaces;

public interface IAppConfigService : INotifyPropertyChanged
{
    string Username { get; set; }
    
    bool IsDarkMode { get; set; }
}