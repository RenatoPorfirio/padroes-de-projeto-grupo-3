using Microsoft.Maui.Controls;
using Biblioteca.Singleton.Theme;

namespace Biblioteca.Factory;

public static class ButtonFactory
{
    public static Button CreateButton(string text, EventHandler? onClick = null, Style? customStyle = null)
    {
        var button = new Button
        {
            Text = text,
        };

        ApplyProperties(button, customStyle);

        if (onClick != null)
        {
            button.Clicked += onClick;
        }

        return button;
    }

    private static void ApplyProperties(Button button, Style? customStyle = null)
    {
        // Aplica as propriedades padrão da fábrica
        button.BackgroundColor = ThemeManagerSingleton.Instance.CurrentColors.Primary;
        button.TextColor = ThemeManagerSingleton.Instance.CurrentColors.PrimaryForeground;
        button.BorderColor = ThemeManagerSingleton.Instance.CurrentColors.Secondary;
        button.BorderWidth = 1;
        button.MinimumWidthRequest = 200;
        button.CornerRadius = 5;
        button.Padding = new Thickness(10);

        if (customStyle != null)
        {
            button.Style = customStyle;
        }
    }

}