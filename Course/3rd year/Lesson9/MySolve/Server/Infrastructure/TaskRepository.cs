using Microsoft.EntityFrameworkCore;

public class TaskRepository : ITaskRepository
{
    private readonly TaskContext _taskContext;

    public TaskRepository(TaskContext taskContext)
    {
        _taskContext = taskContext;
    }

    public async Task AddAsync(MyTask task)
    {
        task.dateTime = DateTime.UtcNow;
        await _taskContext.Tasks.AddAsync(task);
        await _taskContext.SaveChangesAsync();
    }
    public async Task<MyTask> GetByIdAsync(int id)
    {
        return await _taskContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        
    }

    public async Task<List<MyTask>> GetAllAsync()
    {
        return await _taskContext.Tasks.ToListAsync();
    }

    public async Task UpdateAsync(MyTask task)
    {
        var t = await _taskContext.Tasks.FirstOrDefaultAsync(t => t.Id == task.Id);
        if (t != null)
        {
            t.Author = task.Author;
            t.dateTime = task.dateTime;
            t.Title = task.Title;

           await _taskContext.SaveChangesAsync();
        }

    }

    public async Task DeleteAsync(int id)
    {
        var t = await _taskContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (t != null)
        {
            _taskContext.Remove(t);
        }
        await _taskContext.SaveChangesAsync();
    }
}