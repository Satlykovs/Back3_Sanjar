using Microsoft.AspNetCore.Identity;
using UserManagment.Interfaces;
using UserManagment.Managers;
using UserManagment.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IEmailManager, EmailManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUserRepository, InMemoryUserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();