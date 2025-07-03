using Biblioteca.Abstract;
using Biblioteca.Singleton.Theme;

namespace Biblioteca.Factory.Buttons
{
    public class ThemeButton : ButtonAbstract
    {
        public override void SetButtonProperties()
        {
            Text = "Mudar tema";
            TextColor = Colors.White;
            BackgroundColor = Colors.Blue;
            FontSize = 16;
            CornerRadius = 10;
            HeightRequest = 50;
            WidthRequest = 200;
            Clicked += (s, e) =>
            {
                ThemeManagerSingleton.Instance.CurrentTheme = ThemeManagerSingleton.Instance.CurrentTheme switch
                {
                    Common.Theme.ThemeType.Light => Common.Theme.ThemeType.Dark,
                    Common.Theme.ThemeType.Dark => Common.Theme.ThemeType.Gray,
                    Common.Theme.ThemeType.Gray => Common.Theme.ThemeType.Light,
                    _ => throw new System.ArgumentOutOfRangeException(),
                };
            };
        }
    }
}
