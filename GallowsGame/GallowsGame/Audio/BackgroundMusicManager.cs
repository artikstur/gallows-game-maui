using Plugin.Maui.Audio;

public static class BackgroundMusicManager
{
    private static readonly IAudioManager _audioManager = new AudioManager();
    private static IAudioPlayer _player;
    public static async Task LoadAndPlayMusicAsync(string fileName)
    {
        var file = await FileSystem.OpenAppPackageFileAsync(fileName); _player = _audioManager.CreatePlayer(file);
        _player.Loop = true; _player.Play();
    }
    public static void StopMusic()
    {
        _player?.Stop();
    }
    public static void PauseMusic()
    {
        _player?.Pause();
    }
    public static void PlayMusic()
    {
        _player?.Play();
    }
}
