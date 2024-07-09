using GallowsGame.Pages;
using GallowsGame.Utils;
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

        private async void OnKeepNamesCkicked(object sender, EventArgs e)
        {
            UserDataStorage.firstPlayerName = "Игрок 1";
            UserDataStorage.secondPlayerName = "Игрок 2";
            await Navigation.PopModalAsync();
            await Shell.Current.GoToAsync(nameof(EnterWordPage));
        }
    }
}
