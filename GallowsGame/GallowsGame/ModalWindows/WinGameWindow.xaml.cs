using GallowsGame.Pages;

namespace GallowsGame
{
    public partial class WinGameWindow : ContentPage
    {
        private string winner;
        public WinGameWindow(string winner, int firstRoundsCount, int secondRoundsCount)
        {
            InitializeComponent();
            this.Opacity = 0;

            int maxWinRound = firstRoundsCount > secondRoundsCount ? firstRoundsCount : secondRoundsCount;
            int minWinRound = firstRoundsCount < secondRoundsCount ? firstRoundsCount : secondRoundsCount;

            var formattedString = new FormattedString();

            var winnerSpan = new Span
            {
                FontFamily = "Maki-Sans",
                Text = winner + "\n побеждает\n в игре со счётом\n",
                TextColor = Colors.Black 
            };

            var scoreSpan = new Span
            {
                FontFamily = "Maki-Sans",
                Text = $"{maxWinRound}:{minWinRound}",
                TextColor = Colors.Red
            };

            formattedString.Spans.Add(winnerSpan);
            formattedString.Spans.Add(scoreSpan);

            winText.FormattedText = formattedString;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await this.FadeTo(1, 1000); 
        }
        public async void OnOkClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }


        public async void OnOkButtonClicked(object sender, EventArgs e)
        {

            await Navigation.PopModalAsync();

            await Shell.Current.GoToAsync(nameof(SidePeekPage));
        }
    }
    }


