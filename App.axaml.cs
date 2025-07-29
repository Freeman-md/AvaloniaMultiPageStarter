using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaMultiPageStarter.Interfaces;
using AvaloniaMultiPageStarter.Services;
using AvaloniaMultiPageStarter.ViewModels.Layout;
using AvaloniaMultiPageStarter.Views.Layout;
using AvaloniaMultiPageStarter.ViewModels.Onboarding;
using AvaloniaMultiPageStarter.Views.Onboarding;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaMultiPageStarter;

public partial class App : Application
{
    public static readonly ServiceProvider Services = Bootstrapper.Init();

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var onboardingViewModel = Services.GetRequiredService<OnboardingViewModel>();
        var shellViewModel = Services.GetRequiredService<ShellViewModel>();
        var config = Services.GetRequiredService<IAppConfigService>();
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            if (!config.HasCompletedOnboarding)
            {
                DisableAvaloniaDataAnnotationValidation();
                
                desktop.MainWindow = new OnboardingWindow
                {
                    DataContext = onboardingViewModel,
                };  
            }
            else
            {
                desktop.MainWindow = new ShellWindow
                {
                    DataContext = shellViewModel
                };
            }
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
    
    public static void LaunchMainWindow()
    {
        DisableAvaloniaDataAnnotationValidation();
        
        Console.WriteLine("In LaunchMainWindow");
        
        if (Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var shellViewModel = Services.GetRequiredService<ShellViewModel>();
            var newMainWindow = new ShellWindow
            {
                DataContext = shellViewModel
            };

            // Show the new window *first*
            newMainWindow.Show();

            // Then close the old onboarding window
            (desktop.MainWindow as Window)?.Close();

            // Reassign the main window
            desktop.MainWindow = newMainWindow;
        }
    }
}