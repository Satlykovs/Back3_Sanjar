namespace Practice6;


public class WavPlayer : IAudioPlayer
{
    public void PlayAudio(string fileName)
    {
        Console.WriteLine($"Wav file playing : {fileName}");
    }
}