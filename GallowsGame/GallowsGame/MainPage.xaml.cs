using GallowsGame.Pages;

namespace GallowsGame
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnExitButtonClicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void OnStartGameButtonClicked(object sender, EventArgs e)
        {

        }

        private async void OnGameRulesButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GameRulesPage());
        }
    }
}
