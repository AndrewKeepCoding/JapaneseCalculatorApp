using JapaneseCalculatorApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace JapaneseCalculatorApp.Views;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
        ViewModel = App.Current.Services.GetRequiredService<MainPageViewModel>();
    }

    public MainPageViewModel ViewModel { get; }
}
