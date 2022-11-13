using CommunityToolkit.Mvvm.ComponentModel;

namespace JapaneseCalculatorApp.ViewModels;

public partial class ElementViewModel : ObservableObject
{
    [ObservableProperty]
    private string displayName;

    public ElementViewModel(string displayName) => this.displayName = displayName;

    public bool IsNumeric { get; init; } = false;
}