using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
public class NoteController : Controller
{
    private readonly INoteRepository _noteRepository;

    private readonly ILogger _logger;

    public NoteController(INoteRepository noteRepository, ILogger logger)
    {
        _noteRepository = noteRepository;
        _logger = logger;
    }


    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return Ok(await _noteRepository.GetAllNotesAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] Note note)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _noteRepository.AddNoteAsync(note);
        return Ok();
    }
}