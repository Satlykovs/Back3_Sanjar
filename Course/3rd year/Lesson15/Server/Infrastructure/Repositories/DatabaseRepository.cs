using Microsoft.EntityFrameworkCore;

public class DatabaseRepostiory : INoteRepository
{
    private readonly NoteContext _noteContext;

    public DatabaseRepostiory(NoteContext noteContext)
    {
        _noteContext = noteContext;
    }

    public async Task AddNoteAsync(Note note)
    {
        
        await _noteContext.AddAsync(note);

        await _noteContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Note>> GetAllNotesAsync()
    {
        return (await _noteContext.Notes.ToListAsync()).AsEnumerable();
    }
}