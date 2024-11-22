public class InMemoryRepository : INoteRepository
{
    private readonly List<Note> _notes = new List<Note>();

    public async Task AddNoteAsync(Note note)
    {
        
        
        await Task.Run(() => _notes.Add(note));
    }

    public async Task<IEnumerable<Note>> GetAllNotesAsync()
    {
        return await Task.Run(() => _notes.AsEnumerable());
    }
}