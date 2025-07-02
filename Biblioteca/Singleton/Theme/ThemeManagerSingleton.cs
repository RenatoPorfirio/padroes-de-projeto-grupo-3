using System.ComponentModel;
using System.Runtime.CompilerServices;
using Biblioteca.Common.Theme;
using Microsoft.Maui.Graphics;

namespace Biblioteca.Singleton.Theme;

public class ThemeManagerSingleton : INotifyPropertyChanged
{
    private static ThemeManagerSingleton? instance;
    private static readonly object objLock = new();
    private ThemeType _currentTheme;
    private ThemeColors _currentColors;

    public static ThemeManagerSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                lock (objLock)
                    instance ??= new ThemeManagerSingleton();
            }
            return instance;
        }
    }

    public ThemeType CurrentTheme
    {
        get => _currentTheme;
        set
        {
            if (_currentTheme != value)
            {
                _currentTheme = value;
                LoadThemeColors();
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentColors));
            }
        }
    }

    public ThemeColors CurrentColors
    {
        get => _currentColors;
        private set
        {
            if (_currentColors != value)
            {
                _currentColors = value;
                OnPropertyChanged();
            }
        }
    }

    private ThemeManagerSingleton()
    {
        _currentTheme = ThemeType.Light;
        LoadThemeColors();
    }

    private void LoadThemeColors()
    {
        CurrentColors = CurrentTheme switch
        {
            ThemeType.Light => new ThemeColors
            {
                Primary = Colors.White,
                PrimaryForeground = Colors.Black,
                Secondary = Colors.LightGray,
                SecondaryForeground = Colors.Black,
                Foreground = Colors.Black,
                Background = Colors.White
            },
            ThemeType.Dark => new ThemeColors
            {
                Primary = Colors.Black,
                PrimaryForeground = Colors.White,
                Secondary = Colors.DarkGray,
                SecondaryForeground = Colors.White,
                Foreground = Colors.White,
                Background = Colors.Black
            },
            ThemeType.Gray => new ThemeColors
            {
                Primary = Colors.Gray,
                PrimaryForeground = Colors.LightGray,
                Secondary = Colors.DarkSlateGray,
                SecondaryForeground = Colors.LightGray,
                Foreground = Colors.LightGray,
                Background = Colors.Gray
            },
            _ => throw new ArgumentOutOfRangeException(nameof(CurrentTheme), CurrentTheme, "Tema não suportado")
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}