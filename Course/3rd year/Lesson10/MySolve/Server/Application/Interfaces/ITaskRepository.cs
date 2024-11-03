public interface ITaskRepository
{
    Task AddAsync(MyTask task);
    Task<MyTask> GetByIdAsync(int id);
    Task<List<MyTask>> GetAllAsync();
    Task UpdateAsync(MyTask task);
    Task DeleteAsync(int id);
}