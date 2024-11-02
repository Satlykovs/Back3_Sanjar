using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("chat")]
public class ChatController : ControllerBase
{
    private static Dictionary<string, WebSocket> _clients = new();

    [HttpGet("websocket")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            string? userName = HttpContext.Request.Query["name"]; 
            Console.WriteLine($"Соединение с {userName} установлено");
            _clients.Add(userName, webSocket);
            await SendAllUsers($"User {userName} connected.");
            await GetMessages(webSocket, userName);
        }
    }


    private async Task SendAllUsers(string message)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(message);
        foreach (var client in _clients.Values)
        {
            if (client.State == WebSocketState.Open)
            {
                await client.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }

    private async Task GetMessages(WebSocket websocket, string username)
    {
        while (websocket.State == WebSocketState.Open)
        {
            byte[] buffer = new byte[Convert.ToInt32(1e5)];

            var result = await websocket.ReceiveAsync(buffer, CancellationToken.None);
            if (result.CloseStatus.HasValue)
            {
                await websocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                _clients.Remove(username);
                await SendAllUsers($"User {username} disconnected");
                break;
            }
            string message = $"{username} : {Encoding.UTF8.GetString(buffer, 0, result.Count)}";
            Console.WriteLine(message);
            await SendAllUsers(message);
        }
    }
}