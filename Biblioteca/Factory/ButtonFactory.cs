using Biblioteca.Abstract;
using Biblioteca.Factory.Buttons;
using System;

namespace Biblioteca.Factory
{
    public static class ButtonFactory
    {
        public static ButtonAbstract CreateButton(ButtonType type)
        {
            ButtonAbstract button = type switch
            {
                ButtonType.DEFAULT_BUTTON => new DefaultButton(),
                ButtonType.CONFIRM_BUTTON => new ConfirmButton(),
                ButtonType.CANCEL_BUTTON => new CancelButton(),
                ButtonType.THEME_BUTTON => new ThemeButton(),
                _ => throw new ArgumentException("Botao invalido"),
            };
            button.SetButtonProperties();
            return button;
        }
    }
}
