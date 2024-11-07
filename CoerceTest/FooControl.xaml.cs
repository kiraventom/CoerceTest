using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace CoerceTest;

public partial class FooControl : UserControl
{
    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        nameof(Text),
        typeof(string),
        typeof(FooControl),
        new FrameworkPropertyMetadata(
        "0", 
        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, 
        OnTextChanged, OnCoerceText));

    public string Text
    {
        get => (string) GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public FooControl()
    {
        InitializeComponent();
        
        MainTextBox.DataContext = this;
    }

    private static object OnCoerceText(DependencyObject d, object baseValue)
    {
        if (baseValue is string {Length: > 3} s)
        {
            baseValue = s[..3];
        }

        Debug.WriteLine($"CoerceText: {baseValue}");
        return baseValue;
    }

    private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        Debug.WriteLine($"TextChanged: {e.NewValue}");
    }
}