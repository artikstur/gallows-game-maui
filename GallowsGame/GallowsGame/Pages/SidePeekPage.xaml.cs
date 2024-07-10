
using GallowsGame.Utils;
using GallowsGame.Utils.UserData;
namespace GallowsGame.Pages
{
    public partial class SidePeekPage : ContentPage
    {
        public SidePeekPage()
        {
            InitializeComponent();
        }

        private async void OnChooseNamesButton(object sender, EventArgs e)
        {
            var firstPlayer = new PersonData(firstNameEntry.Text);
            var secondPlayer = new PersonData(secondNameEntry.Text);

            UserDataStorage.FirstPlayer = firstPlayer;
            UserDataStorage.SecondPlayer = secondPlayer;

            if (firstNameEntry.Text == "" || secondNameEntry.Text == "")
            {
                WarningWindow warning = new WarningWindow("Впишите свои имена в поля ниже, иначе будут выбраны базовые названия");
                await Navigation.PushModalAsync(warning);
            }
            else
            {
                await Navigation.PushAsync(new EnterWordPage());
            }
        }

        private async void OnPauseButtonClicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            button.IsEnabled = false;
            try
            {
                await button.ScaleTo(1.2, 100, Easing.Linear);
                await button.ScaleTo(1, 100, Easing.Linear);

                await Navigation.PushAsync(new MenuPage());
            }
            finally
            {
                button.IsEnabled = true;
            }
        }
    }

}