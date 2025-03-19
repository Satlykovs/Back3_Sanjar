using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExController  : ControllerBase
{
    [HttpGet("trigger-error")]
    public IActionResult TriggerError(string errorType)
    {

        return errorType switch
        {
            "400" => throw new ArgumentNullException("Параметр не может быть пустым"),
            "404" => throw new KeyNotFoundException("Ресурс не найден"),
                _ => throw new Exception("Общая ошибка сервера")
        };

        
    }
}