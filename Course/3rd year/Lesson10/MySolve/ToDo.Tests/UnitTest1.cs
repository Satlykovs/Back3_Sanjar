using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Xunit;

namespace ToDo.Tests;

public class ToDoControllerTests
{
    private ITaskRepository GetRepo()
    {
        var options = new DbContextOptionsBuilder<TaskContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        var context = new TaskContext(options);


        return new TaskRepository(context);
    }

    private async Task PlaceData(ITaskRepository repo, int count)
    {
        List<Task> tasks = new List<Task>();
        for (int i = 0; i < count; ++i)
        {;
            var t = repo.AddAsync(new MyTask { Title = $"Test Task {i}", Author = $"Test Author {i}"});
            tasks.Add(t);
        }
        await Task.WhenAll(tasks);
    }

    [Fact]
    public async Task CheckAllAdded()
    {
        //Arrange
        var repo = GetRepo();
        await PlaceData(repo, 5000);
        
        var controller = new TaskController(repo);

        //Act
        var result = await controller.GetAllTasks();
        
        //Assert
        var okResult = Assert.IsType<OkObjectResult>(result);

        var tasks = Assert.IsAssignableFrom<IEnumerable<MyTask>>(okResult.Value);

        Assert.Equal(5000, tasks.Count());
    }

    [Fact]
    public async Task CheckDelete()
    {
        //Arrange
        var repo  = GetRepo();
        await PlaceData(repo, 100);

        var controller = new TaskController(repo);        
        
        //Act
        List<Task> tasks = new List<Task>();
        for (int i = 1; i < 101; ++i)
        {
            tasks.Add(controller.Delete(i));
        }
        await Task.WhenAll(tasks);
        
        var result = await controller.GetAllTasks();

        //Assert
        Assert.Empty(((List<MyTask>)((OkObjectResult) result).Value)); // не получилось сделать, как ты писал в прошлой практике :(

    }

}