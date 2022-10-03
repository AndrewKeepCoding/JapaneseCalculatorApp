using JapaneseCalculatorApp.ViewModels;
using JapaneseCalculatorApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;
using WinUIEx;

namespace JapaneseCalculatorApp;
public partial class App : Application
{
    private WindowEx? window;

    public App()
    {
        InitializeComponent();
        Services = ConfigureServices();
    }

    public new static App Current => (App)Application.Current;

    public IServiceProvider Services { get; }

    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        this.window = new MainWindow();
        this.window.Activate();
        this.window.SetWindowSize(1000, 800);
        this.window.SetIsResizable(false);
    }

    private static IServiceProvider ConfigureServices()
    {
        return new ServiceCollection()
            .AddSingleton<MainPageViewModel>()
            .BuildServiceProvider();
    }
}
