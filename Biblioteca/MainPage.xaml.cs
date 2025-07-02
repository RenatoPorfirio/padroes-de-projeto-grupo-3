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
				Padding = new Thickness(30, 0),
				Spacing = 25
			};
			Content = new ScrollView { Content = newLayout };
		}

		VerticalStackLayout? currentLayout = (Content as ScrollView).Content as VerticalStackLayout ?? throw new InvalidOperationException("O layout atual não é um VerticalStackLayout.");

		Label titleLabel = LabelFactory.CreateTitleLabel("Teste da biblioteca de componentes");
		currentLayout?.Children.Add(titleLabel);

		Label bodyLabel = LabelFactory.CreateBodyLabel("Esta é uma demonstração de como a biblioteca de componentes funciona. Você pode mudar o tema clicando no botão abaixo.");
		currentLayout?.Children.Add(bodyLabel);

		Label themeLabel = LabelFactory.CreateLabel($"Tema Atual: {ThemeManagerSingleton.Instance.CurrentTheme}");
		currentLayout?.Children.Add(themeLabel);

		Button themeToggleButton = ButtonFactory.CreateButton("Mudar Tema", OnToggleThemeClicked);
		currentLayout?.Children.Add(themeToggleButton);
		
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
