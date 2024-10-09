using Microsoft.EntityFrameworkCore;
using MySolve.Application.Contexts;
using MySolve.Application.Interfaces;
using MySolve.Infrastructure.Repositories;
using MySolve.Infrastructure.Services;
using MySolve.Domain;
using MySolve.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddSingleton<IUserService>(provider =>
{
    var options = new DbContextOptionsBuilder<UserContext>();
    options.UseSqlite("Data Source=UserDatabase.db");
    var context = new UserContext(options.Options);
    context.Database.EnsureCreated();
    IUserRepository userRepository = new UserRepository(context);
    IUserService userService = new UserService(userRepository);
    return userService;
    
});

builder.Services.AddSingleton<IBookService>(provider =>
{
    var options = new DbContextOptionsBuilder<LibraryContext>();
    options.UseSqlite("Data Source=BookDatabase.db");
    var context = new LibraryContext(options.Options);
    context.Database.EnsureCreated();
    IBookRepository bookRepository = new BookRepository(context);
    IBookService bookService = new BookService(bookRepository);
    return bookService;
    
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseCors();
app.Run();