namespace Practice6;

public class MultimediaPlayer
{
    private readonly IVideoPlayer _videoPlayer;

    private readonly IAudioPlayer _audioPlayer;

    public MultimediaPlayer(IAudioPlayer audioPlayer, IVideoPlayer videoPlayer)
    {
        _videoPlayer = videoPlayer;
        _audioPlayer = audioPlayer;

    }

    public void Play(string filename)
    {
        var ext = Path.GetExtension(filename).ToLower();
        switch (ext)
        {
            case ".mp3":
                _audioPlayer.PlayAudio(filename);
                break;
            case ".wav":
                _audioPlayer.PlayAudio(filename);
                break;
            case ".mp4":
                _videoPlayer.PlayVideo(filename);
                break;
            default:
                Console.WriteLine("Неподдерживаемый формат файла");
                break;
        }
    }
}

