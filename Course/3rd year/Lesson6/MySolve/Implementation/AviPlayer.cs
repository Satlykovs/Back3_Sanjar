namespace Practice6;
public class AviPlayer : IVideoPlayer
{
    public void PlayVideo(string fileName)
    {
        Console.WriteLine($"Playing video : {fileName}");
    }
}