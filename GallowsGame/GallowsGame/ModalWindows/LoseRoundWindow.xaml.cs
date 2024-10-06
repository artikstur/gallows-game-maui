using GallowsGame.Pages;

namespace GallowsGame
{
    public partial class LoseRoundWindow : ContentPage
    {
        public LoseRoundWindow(string guesser)
        {
            InitializeComponent();
            this.Opacity = 0;
            infoText.Text = guesser;

            var formattedString = new FormattedString();

            var guesserSpan = new Span
            {
                FontFamily = "Maki-Sans",
                Text = guesser,
                TextColor = Colors.Red
            };

            var remainingTextSpan = new Span
            {
                FontFamily = "Maki-Sans",
                Text = ", Вы проиграли раунд :(\n\n Загадывайте слово!",
                TextColor = Colors.Black
            };

            formattedString.Spans.Add(guesserSpan);
            formattedString.Spans.Add(remainingTextSpan);

            infoText.FormattedText = formattedString;

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
            await Shell.Current.GoToAsync(nameof(EnterWordPage));
        }
    }
}


