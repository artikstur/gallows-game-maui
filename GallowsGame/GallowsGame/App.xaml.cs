namespace GallowsGame
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            StartBackgroundMusic();
        }

        private async void StartBackgroundMusic()
        {
            await BackgroundMusicManager.LoadAndPlayMusicAsync("fonGame.wav");
        }
        protected override void OnSleep()
        {
            BackgroundMusicManager.StopMusic(); base.OnSleep();
        }
    }
}
