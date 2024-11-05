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
dbContext.Database.EnsureCreated();
}


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.UseCors("AllowAll");
app.Run();