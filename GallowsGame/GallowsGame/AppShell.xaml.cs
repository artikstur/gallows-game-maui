using GallowsGame.Pages;
using Microsoft.Maui.Controls;
namespace GallowsGame
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EnterWordPage), typeof(EnterWordPage));
        }
    }
}
