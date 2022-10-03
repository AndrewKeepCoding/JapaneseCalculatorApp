using WinUIEx;

namespace JapaneseCalculatorApp.Views;

public sealed partial class MainWindow : WindowEx
{
    public MainWindow()
    {
        InitializeComponent();
        ExtendsContentIntoTitleBar = true;
        SetTitleBar(this.AppTitleBar);
        this.AppTitleBarText.Text = "日本語電卓";
    }
}
