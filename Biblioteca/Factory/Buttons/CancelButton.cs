using Biblioteca.Abstract;
using System;

namespace Biblioteca.Factory.Buttons
{
    public class CancelButton : ButtonAbstract
    {
        public override void SetButtonProperties()
        {
            Text = "Cancelar";
            TextColor = Colors.White;
            BackgroundColor = Colors.Red;
            FontSize = 16;
            CornerRadius = 10;
            HeightRequest = 50;
            WidthRequest = 200;
            Clicked += (s, e) => Console.WriteLine("Botao de cancelar clicado!");
        }
    }
}
