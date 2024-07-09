
using GallowsGame.Utils;
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
            UserDataStorage.firstPlayerName = firstNameEntry.Text;
            UserDataStorage.secondPlayerName = secondNameEntry.Text;

            if (UserDataStorage.firstPlayerName == "" || UserDataStorage.secondPlayerName == "")
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
            await button.ScaleTo(1.2, 100, Easing.Linear);
            await button.ScaleTo(1, 100, Easing.Linear);

            await Navigation.PushAsync(new MenuPage());
        }
    }

}