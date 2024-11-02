using Microsoft.AspNetCore.Mvc;
[Route("api")]
public class TaskController : ControllerBase
{
    private readonly ITaskRepository  _taskRepository;

    public TaskController(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] MyTask task)
    {
        await _taskRepository.AddAsync(task);
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> Update([FromBody] MyTask task)
    {
        await _taskRepository.UpdateAsync(task);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var t = await _taskRepository.GetByIdAsync(id);
        if (t != null)
        {
            return Ok(t);
        }
        return NotFound();
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _taskRepository.GetAllAsync();
        return Ok(tasks);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _taskRepository.DeleteAsync(id);
        return Ok();
    }
}