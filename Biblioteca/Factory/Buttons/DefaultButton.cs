using Biblioteca.Abstract;

namespace Biblioteca.Factory.Buttons
{
    public class DefaultButton : ButtonAbstract
    {
        public override void SetButtonProperties()
        {
            Text = "Default";
            TextColor = Colors.White;
            BackgroundColor = Colors.Gray;
            FontSize = 16;
            CornerRadius = 10;
            HeightRequest = 50;
            WidthRequest = 200;
            Clicked += (s, e) => Console.WriteLine("Botao padrao clicado!");
        }
    }
}
