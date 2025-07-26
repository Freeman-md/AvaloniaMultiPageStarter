using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using AvaloniaMultiPageStarter.Interfaces;
using AvaloniaMultiPageStarter.Services;
using AvaloniaMultiPageStarter.ViewModels.Layout;
using AvaloniaMultiPageStarter.Views.Layout;
using AvaloniaMultiPageStarter.ViewModels.Layout;
using AvaloniaMultiPageStarter.ViewModels.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaMultiPageStarter;

public partial class App : Application
{
    public readonly ServiceProvider _services = Bootstrapper.Init();

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var shellViewModel = _services.GetRequiredService<ShellViewModel>();
            
            DisableAvaloniaDataAnnotationValidation();
            
            desktop.MainWindow = new ShellView
            {
                DataContext = shellViewModel,
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
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
}