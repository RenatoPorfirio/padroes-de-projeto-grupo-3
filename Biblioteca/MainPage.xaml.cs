using Biblioteca.Common.Theme;
using Biblioteca.Singleton.Theme;
using Biblioteca.Factory;
using Microsoft.Maui.Controls;
using System.ComponentModel;

namespace Biblioteca;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        ThemeManagerSingleton.Instance.PropertyChanged += OnThemeManagerPropertyChanged;
        Build();
    }

    private void Build()
    {
        if (Content is ScrollView scrollView && scrollView.Content is VerticalStackLayout layout)
        {
            layout.Children.Clear();
        }
        else
        {
            var newLayout = new VerticalStackLayout
            {
                Padding = new Thickness(30, 100, 30, 0),
                Spacing = 25,
                HorizontalOptions = LayoutOptions.Center
            };
            Content = new ScrollView { Content = newLayout };
        }

        VerticalStackLayout? currentLayout = (Content as ScrollView)?.Content as VerticalStackLayout ?? throw new InvalidOperationException("O layout atual não é um VerticalStackLayout.");
        currentLayout.Padding = new Thickness(30, 100, 30, 0);
        currentLayout.HorizontalOptions = LayoutOptions.Center;

        currentLayout?.Children.Add(ButtonFactory.CreateButton(ButtonType.DEFAULT_BUTTON));
        currentLayout?.Children.Add(ButtonFactory.CreateButton(ButtonType.CONFIRM_BUTTON));
        currentLayout?.Children.Add(ButtonFactory.CreateButton(ButtonType.CANCEL_BUTTON));
        currentLayout?.Children.Add(ButtonFactory.CreateButton(ButtonType.THEME_BUTTON));

        BackgroundColor = ThemeManagerSingleton.Instance.CurrentColors.Background;
    }

    private void OnThemeManagerPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ThemeManagerSingleton.CurrentColors))
        {
            Build();
        }
    }

    private void OnToggleThemeClicked(object sender, EventArgs e)
    {
        ThemeManagerSingleton.Instance.CurrentTheme = ThemeManagerSingleton.Instance.CurrentTheme switch
        {
            ThemeType.Light => ThemeType.Dark,
            ThemeType.Dark => ThemeType.Gray,
            ThemeType.Gray => ThemeType.Light,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}

