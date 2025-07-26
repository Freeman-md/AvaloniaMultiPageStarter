using AvaloniaMultiPageStarter.Interfaces;
using AvaloniaMultiPageStarter.ViewModels.Layout;
using AvaloniaMultiPageStarter.ViewModels.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaMultiPageStarter.Services;

public class Bootstrapper
{
    public static ServiceProvider Init()
    {
        var services = new ServiceCollection();

        // Shared Services
        services.AddSingleton<IAppConfigService, AppConfigService>();

        // Shell + Pages
        services.AddSingleton<ShellViewModel>();
        services.AddTransient<HomeViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<AboutViewModel>();

        return services.BuildServiceProvider();
    }
}