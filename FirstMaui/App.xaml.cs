using Microsoft.Maui.Controls;

namespace FirstMaui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}