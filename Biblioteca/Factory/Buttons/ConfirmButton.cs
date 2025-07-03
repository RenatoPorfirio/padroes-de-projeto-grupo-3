using Biblioteca.Abstract;
using System;

namespace Biblioteca.Factory.Buttons
{
    public class ConfirmButton : ButtonAbstract
    {
        public override void SetButtonProperties()
        {
            Text = "Confirmar";
            TextColor = Colors.White;
            BackgroundColor = Colors.Green;
            FontSize = 16;
            CornerRadius = 10;
            HeightRequest = 50;
            WidthRequest = 200;
            Clicked += (s, e) => Console.WriteLine("Botao de confirmar clicado!");
        }
    }
}
