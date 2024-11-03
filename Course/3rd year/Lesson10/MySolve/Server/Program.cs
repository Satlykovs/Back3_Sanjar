using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddCors(options =>
   {
       options.AddPolicy("AllowAll",
           builder => builder.AllowAnyOrigin()
                             .AllowAnyMethod()
                             .AllowAnyHeader());
   });



builder.Services.AddDbContext<TaskContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString")));



builder.Services.AddScoped<ITaskRepository, TaskRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();



using (var serviceScope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<TaskContext>();
    var retryCount = 5;
    var delay = TimeSpan.FromSeconds(5);
    bool dbCreated = false;

    for (var i = 0; i < retryCount; i++)
    {
        try
        {
            dbContext.Database.EnsureCreated();
            dbCreated = true;
            break;
        }
        catch (Exception ex)
        {
            Thread.Sleep(delay);
        }
    }

    if (!dbCreated)
    {
        throw new Exception("Не удалось подключиться к базе данных после нескольких попыток.");
    }
}


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseCors("AllowAll");
app.Run();