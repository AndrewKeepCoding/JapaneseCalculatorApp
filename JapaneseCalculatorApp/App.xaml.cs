using JapaneseCalculatorApp.Views;
using Microsoft.UI.Xaml;
using WinUIEx;

namespace JapaneseCalculatorApp;
public partial class App : Application
{
    private WindowEx? window;

    public App()
    {
        InitializeComponent();
    }

    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        this.window = new MainWindow();
        this.window.Activate();
        this.window.SetWindowSize(1000, 800);
        this.window.SetIsResizable(false);
    }
}
