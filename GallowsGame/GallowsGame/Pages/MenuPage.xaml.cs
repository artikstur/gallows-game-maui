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

        private void OnExitButtonClicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void OnResumeButtonClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnSoundButtonClicked(object sender, EventArgs e)
        {
            _isSoundOn = !_isSoundOn;

            if (_isSoundOn)
            {
              //  mediaPlayer.Play();
                SoundBttn.Text = "Звук: вкл";
            }
            else
            {
              //  mediaPlayer.Pause();
                SoundBttn.Text = "Звук: выкл";
            }
        }
    }
}
