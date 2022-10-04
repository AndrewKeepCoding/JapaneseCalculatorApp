using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System.Windows.Input;

namespace JapaneseCalculatorApp.Views;

public sealed partial class CalculatorButton : UserControl
{
    public static readonly DependencyProperty ButtonBackgroundProperty =
        DependencyProperty.Register(
            nameof(ButtonBackground),
            typeof(Brush),
            typeof(CalculatorButton),
            new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

    public static readonly DependencyProperty ButtonForegroundProperty =
        DependencyProperty.Register(
            nameof(ButtonForeground),
            typeof(Brush),
            typeof(CalculatorButton),
            new PropertyMetadata(default));

    public static readonly DependencyProperty ButtonMarginProperty =
        DependencyProperty.Register(
            nameof(ButtonMargin),
            typeof(GridLength),
            typeof(CalculatorButton),
            new PropertyMetadata(default));

    public static readonly DependencyProperty CommandParameterProperty =
        DependencyProperty.Register(
            nameof(CommandParameter),
            typeof(object),
            typeof(CalculatorButton),
            new PropertyMetadata(default));

    public static readonly DependencyProperty CommandProperty =
        DependencyProperty.Register(
            nameof(Command),
            typeof(ICommand),
            typeof(CalculatorButton),
            new PropertyMetadata(default));

    public static readonly DependencyProperty TextMarginProperty =
        DependencyProperty.Register(
            nameof(TextMargin),
            typeof(Thickness),
            typeof(CalculatorButton),
            new PropertyMetadata(default));

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(CalculatorButton),
            new PropertyMetadata(default));

    public CalculatorButton()
    {
        InitializeComponent();
    }

    public Brush ButtonBackground
    {
        get => (Brush)GetValue(ButtonBackgroundProperty);
        set => SetValue(ButtonBackgroundProperty, value);
    }

    public Brush ButtonForeground
    {
        get => (Brush)GetValue(ButtonForegroundProperty);
        set => SetValue(ButtonForegroundProperty, value);
    }

    public GridLength ButtonMargin
    {
        get => (GridLength)GetValue(ButtonMarginProperty);
        set => SetValue(ButtonMarginProperty, value);
    }

    public ICommand Command
    {
        get => (ICommand)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    public object CommandParameter
    {
        get => (object)GetValue(CommandParameterProperty);
        set => SetValue(CommandParameterProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public Thickness TextMargin
    {
        get => (Thickness)GetValue(TextMarginProperty);
        set => SetValue(TextMarginProperty, value);
    }

    private void ButtonControl_PointerEntered(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        _ = VisualStateManager.GoToState(this, nameof(this.MouseOver), useTransitions: true);
    }

    private void ButtonControl_PointerExited(object sender, Microsoft.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        _ = VisualStateManager.GoToState(this, nameof(this.Normal), useTransitions: true);
    }
}