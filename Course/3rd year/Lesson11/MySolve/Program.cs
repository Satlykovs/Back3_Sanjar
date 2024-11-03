using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var urls = new[]
        {
            "https://v2.jokeapi.dev/joke/Programming",
            "https://api.adviceslip.com/advice",
            "https://catfact.ninja/fact"
        };

        await FetchDataFromApisAsync(urls);
    }

    static async Task FetchDataFromApisAsync(string[] urls)
    {
        using var httpClient = new HttpClient();
        var tasks = new Task<string>[urls.Length];

        for (int i = 0; i < urls.Length; i++)
        {
            tasks[i] = httpClient.GetStringAsync(urls[i]);
        }

        var results = await Task.WhenAll(tasks);

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }
}