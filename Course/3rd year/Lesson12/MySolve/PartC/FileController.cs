using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private static readonly string filePath = "output.txt";
    private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(4);

    [HttpPost]
    [Route("write")]
    public async Task<IActionResult> ProcessFile([FromBody] string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            return BadRequest("Содержимое не может быть пустым.");
        }

        await WriteToFileAsync(content);
        return Ok(await ReadFromFileAsync());
    }

    private async Task WriteToFileAsync(string text)
    {
        await semaphore.WaitAsync();

        try
        {
            using (var writer = new StreamWriter(filePath, true, Encoding.UTF8))
            {
                await writer.WriteLineAsync(text);
            }
        }
        catch (IOException ex)
        {
            throw new Exception("Ошибка записи файла: " + ex.Message);
        }
        finally
        {
            semaphore.Release();
        }
    }

    private async Task<string> ReadFromFileAsync()
    {
        if (System.IO.File.Exists(filePath))
        {
            using (var reader = new StreamReader(filePath, Encoding.UTF8))
            {
                return await reader.ReadToEndAsync();
            }
        }
        else
        {
            return "Файл не найден.";
        }
    }
}