using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskAdministrator.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaskDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("taskDB"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolitic", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader().
        AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("NewPolitic");

app.UseAuthorization();

app.MapControllers();

app.Run();
