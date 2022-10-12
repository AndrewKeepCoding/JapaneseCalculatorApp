using AK.Toolkit.WinUI3.GridIndexer;
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
        GridIndexer.RunGridIndexer(Content);
    }

    public MainPageViewModel ViewModel { get; }
}
