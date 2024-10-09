namespace Practice6;


public class Mp3Player : IAudioPlayer
{
    public void PlayAudio(string fileName)
    {
        Console.WriteLine($"Mp3 file playing : {fileName}");
    }
}