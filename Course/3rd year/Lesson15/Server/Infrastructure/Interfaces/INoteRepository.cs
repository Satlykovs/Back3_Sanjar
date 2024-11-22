public interface INoteRepository
{
    Task AddNoteAsync(Note note);
    Task<IEnumerable<Note>> GetAllNotesAsync();
}