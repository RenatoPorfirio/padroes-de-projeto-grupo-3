using Microsoft.Maui.Controls;
using Biblioteca.Singleton.Theme;

namespace Biblioteca.Factory;

public static class LabelFactory
{
    private static void ApplyProperties(Label label, Style? customStyle = null)
    {
        label.TextColor = ThemeManagerSingleton.Instance.CurrentColors.PrimaryForeground; // Cor do texto baseada no tema
        label.FontSize = 14;
        label.HorizontalOptions = LayoutOptions.Start;
        label.VerticalOptions = LayoutOptions.Center;
        label.Padding = new Thickness(0);

        if (customStyle != null)
        {
            label.Style = customStyle;
        }
    }

    public static Label CreateLabel(string text, Style? customStyle = null)
    {
        var label = new Label
        {
            Text = text,
        };

        ApplyProperties(label, customStyle);

        return label;
    }

    public static Label CreateTitleLabel(string text, Style? customStyle = null)
    {
        var label = new Label
        {
            Text = text,
            FontSize = 20,
            FontAttributes = FontAttributes.Bold,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
        };

        ApplyProperties(label, customStyle);

        return label;
    }

    public static Label CreateBodyLabel(string text, Style? customStyle = null)
    {
        var label = new Label
        {
            Text = text,
            LineBreakMode = LineBreakMode.WordWrap,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.Start,
        };

        ApplyProperties(label, customStyle);

        return label;
    }
}