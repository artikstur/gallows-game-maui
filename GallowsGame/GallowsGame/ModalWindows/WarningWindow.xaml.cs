using GallowsGame.Pages;
using GallowsGame.Utils;
using GallowsGame.Utils.UserData;
using Microsoft.Maui.Controls;

namespace GallowsGame
{
    public partial class WarningWindow : ContentPage
    {
        public WarningWindow(string errorMessage)
        {
            InitializeComponent();
            ErrorMessage.Text = errorMessage;
        }
        private async void OnOkClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }

        private async void OnChangeNamesClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void OnKeepNamesClicked(object sender, EventArgs e)
        {
            var firstPlayer = new PersonData("Игрок 1");
            var secondPlayer = new PersonData("Игрок 2");

            UserDataStorage.FirstPlayer = firstPlayer;
            UserDataStorage.SecondPlayer = secondPlayer;

            await Navigation.PopModalAsync();
            await Shell.Current.GoToAsync(nameof(EnterWordPage));
        }
    }
}
