using GallowsGame.Pages;

namespace GallowsGame
{
    public partial class MenuPage: ContentPage
    {
        private bool _isSoundOn = true;
        public MenuPage()
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

        private async void OnResumeButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await button.ScaleTo(1.2, 100, Easing.Linear);
            await button.ScaleTo(1, 100, Easing.Linear);
            
            await Navigation.PopAsync();
        }

        private async void OnSoundButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            await button.ScaleTo(1.2, 100, Easing.Linear);
            await button.ScaleTo(1, 100, Easing.Linear);

            _isSoundOn = !_isSoundOn;
            
            if (_isSoundOn)
            {
              //  mediaPlayer.Play();
                SoundBttn.Text = "Звук: вкл";
                BackgroundMusicManager.PlayMusic();
            }
            else
            {
              //  mediaPlayer.Pause();
                SoundBttn.Text = "Звук: выкл";
                BackgroundMusicManager.PauseMusic();
            }
        }
    }
}
