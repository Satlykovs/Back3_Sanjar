var builder = WebApplication.CreateBuilder(args);

FileInfo fileInfo = new FileInfo("output.txt");
if (fileInfo.Exists && fileInfo.Length > 0)
{
    File.WriteAllText("output.txt", string.Empty);
}

builder.Services.AddControllers();


builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();

