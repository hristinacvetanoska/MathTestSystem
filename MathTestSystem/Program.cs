using MathTestSystem.Application.Interfaces;
using MathTestSystem.Infrasturcture.Data;
using MathTestSystem.Infrasturcture.Services;
using MathTestSystem.MathProcessor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlite("Data Source=MathTestSystem.db"));

builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IMathService, MathService>();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMathTestSysteUI",
        builder => builder
            .WithOrigins("https://localhost:7299")
            .AllowAnyMethod()
            .AllowAnyHeader());
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });

app.UseCors("AllowMathTestSysteUI");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
