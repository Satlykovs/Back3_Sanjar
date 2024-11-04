using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    private static readonly string filePath = "output.txt";
    private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(4);

    static async Task Main(string[] args)
    {
        string input;
        FileInfo fileInfo = new FileInfo(filePath);
        if (fileInfo.Exists && fileInfo.Length != 0)
        {
            File.WriteAllText(filePath, string.Empty);
        }

        Console.WriteLine("Введите строки текста (введите 'exit' для выхода):");

        while ((input = Console.ReadLine())?.ToLower() != "exit")
        {
            _ = WriteToFileAsync(input);
        }

        Console.WriteLine("Содержимое файла:");
        await ReadFromFileAsync();
    }

    private static async Task WriteToFileAsync(string text)
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
            Console.WriteLine($"Ошибка записи файла: {ex.Message}");
        }
        finally
        {
            semaphore.Release();
        }
    }

    private static async Task ReadFromFileAsync()
    {
        if (File.Exists(filePath))
        {
            using (var reader = new StreamReader(filePath, Encoding.UTF8))
            {
                string content = await reader.ReadToEndAsync();
                Console.WriteLine(content);
            }
        }
        else
        {
            Console.WriteLine("Файл не найден.");
        }
    }
}