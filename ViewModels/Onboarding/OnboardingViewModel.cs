using System;
using Avalonia.Controls;
using AvaloniaMultiPageStarter.Views.Onboarding.Steps;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaMultiPageStarter.ViewModels.Onboarding;

public partial class OnboardingViewModel : ViewModelBase
{
    private readonly UserControl[] _steps =
    {
    new WelcomeStepView(),
    new PreferencesStepView(),
    new CompletionStepView()
    };

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CurrentStepView))]
    [NotifyPropertyChangedFor(nameof(ShowPreviousButton))]
    [NotifyPropertyChangedFor(nameof(PrimaryButtonText))]
    [NotifyPropertyChangedFor(nameof(CanGoPrevious))]
    [NotifyCanExecuteChangedFor(nameof(PreviousStepCommand))]
    private int _currentStepIndex;

    [ObservableProperty]
    private UserControl _currentStepView;

    private bool CanGoPrevious => CurrentStepIndex > 0;
    public bool ShowPreviousButton => CurrentStepIndex > 0;
    public string PrimaryButtonText => CurrentStepIndex == _steps.Length - 1 ? "Finish" : "Next";

    public OnboardingViewModel()
    {
        CurrentStepView = _steps[0];
    }

    [RelayCommand(CanExecute = nameof(CanGoPrevious))]
    private void PreviousStep()
    {
        if (CurrentStepIndex > 0)
        {
            CurrentStepIndex--;
            CurrentStepView = _steps[CurrentStepIndex];
        }
    }
    
    [RelayCommand]
    private void PrimaryAction()
    {
        if (CurrentStepIndex < _steps.Length - 1)
        {
            CurrentStepIndex++;
            CurrentStepView = _steps[CurrentStepIndex];
        }
        else
        {
            Console.WriteLine("Launching main window");
            // Mark onboarding complete (save to config/store)
            App.LaunchMainWindow();
        }
    }
}