using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace JapaneseCalculatorApp.Views;

public sealed partial class VerticalTextBlock : UserControl
{
    public static readonly DependencyProperty TextBlockStyleProperty = DependencyProperty.Register(
        nameof(TextBlockStyle),
        typeof(Style),
        typeof(VerticalTextBlock),
        new PropertyMetadata(default));

    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text),
        typeof(string),
        typeof(VerticalTextBlock),
        new PropertyMetadata(default, (d, _) => (d as VerticalTextBlock)?.UpdateText()));

    public VerticalTextBlock()
    {
        InitializeComponent();
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public Style TextBlockStyle
    {
        get => (Style)GetValue(TextBlockStyleProperty);
        set => SetValue(TextBlockStyleProperty, value);
    }

    private bool TryGetChildText(int index, out string text)
    {
        if (index < this.StackPanel.Children.Count &&
            this.StackPanel.Children[index] is TextBlock textBlock)
        {
            text = textBlock.Text;
            return true;
        }

        text = string.Empty;
        return false;
    }

    private void UpdateText()
    {
        this.StackPanel.Children.Clear();

        for (int i = 0; i < Text.Length; i++)
        {
            string character = Text[i].ToString();

            if (TryGetChildText(i, out string childText) is true &&
                character.Equals(childText) is true)
            {
                continue;
            }

            this.StackPanel.Children.Add(new TextBlock()
            {
                Text = Text[i].ToString(),
                Style = TextBlockStyle,
                HorizontalAlignment = HorizontalAlignment.Center
            });
        }
    }
}
