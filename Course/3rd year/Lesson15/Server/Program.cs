using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NoteContext>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("ConnectionString")));


builder.Services.AddScoped<INoteRepository, DatabaseRepostiory>();

builder.Services.AddMvc();

using (var serviceScope = builder.Services.BuildServiceProvider().CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<NoteContext>();
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

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();

app.UseHttpsRedirection();
app.MapControllers();
app.MapRazorPages();

app.Run();
