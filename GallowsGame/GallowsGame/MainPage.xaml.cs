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
            button.IsEnabled = false;
            button.Background = Colors.Transparent;
            button.TextColor = Colors.Navy;
            try
            {
                await button.ScaleTo(1.2, 100, Easing.Linear);
                await button.ScaleTo(1, 100, Easing.Linear);

                Environment.Exit(0);
            }
            finally
            {
                button.IsEnabled = true;
            }

        }

        private async void OnStartGameButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.IsEnabled = false;
            button.Background = Colors.Transparent;
            button.TextColor = Colors.Navy;
            try
            {
                await button.ScaleTo(1.2, 100, Easing.Linear);
                await button.ScaleTo(1, 100, Easing.Linear);

                await Navigation.PushAsync(new SidePeekPage());
            }
            finally
            {
                button.IsEnabled = true;
            }
        }

        private async void OnGameRulesButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.IsEnabled = false;
            button.Background = Colors.Transparent;
            button.TextColor = Colors.Navy;
            try
            {
                await button.ScaleTo(1.2, 100, Easing.Linear);
                await button.ScaleTo(1, 100, Easing.Linear);
                await Navigation.PushAsync(new GameRulesPage());
            }

            finally
            {
                button.IsEnabled = true;
            }
        }
    }
}
