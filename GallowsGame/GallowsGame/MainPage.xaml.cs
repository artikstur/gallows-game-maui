using GallowsGame.Pages;

namespace GallowsGame
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnExitButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await button.ScaleTo(1.2, 100, Easing.Linear);
            await button.ScaleTo(1, 100, Easing.Linear);

            Environment.Exit(0);
        }

        private async void OnStartGameButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await button.ScaleTo(1.2, 100, Easing.Linear);
            await button.ScaleTo(1, 100, Easing.Linear);

            await Navigation.PushAsync(new SidePeekPage());
        }

        private async void OnGameRulesButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await button.ScaleTo(1.2, 100, Easing.Linear);
            await button.ScaleTo(1, 100, Easing.Linear);

            await Navigation.PushAsync(new GameRulesPage());
        }
    }
}
