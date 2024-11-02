using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Net.WebSockets;

class Program
{
    private static ClientWebSocket _clientWebSocket = new ClientWebSocket();
    public async static Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Write("Введите имя пользователя: ");
        string username = Console.ReadLine();

        Uri serverUri = new Uri($"ws://localhost:5218/chat/websocket?name={username}");
        await _clientWebSocket.ConnectAsync(serverUri, CancellationToken.None);
        var getMessagesTask = GetMessages();
        while (true)
        {
            string? message = Console.ReadLine();
            if (message == "/exit")
            {
                await _clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client disconnecting", CancellationToken.None);
                break;
            }
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            await _clientWebSocket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
        await getMessagesTask;
    }

    private static async Task GetMessages()
        {
            byte[] buffer = new byte[Convert.ToInt32(1e5)];
            while (_clientWebSocket.State == WebSocketState.Open)
            {
                var result = await _clientWebSocket.ReceiveAsync(buffer, CancellationToken.None);
                Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, result.Count));
            }
        }
}