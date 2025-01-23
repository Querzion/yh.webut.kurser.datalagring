using CommunityToolkit.Mvvm.ComponentModel;

namespace Presentation.Avalonia.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";
}