using WebApplication1.Interfaces;
using WebApplication1.Infrastructure;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IChildAssisted, ChildAssistedRepository>();
builder.Services.AddTransient<IResponsible, ResponsibleRepository>();
builder.Services.AddTransient<IUser, UserRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<ConnectionContext>(options =>
    options.UseNpgsql("Server=localhost;Port=5432;Database=teatechdatabase;User Id=postgres;Password=ARROZDOCE;"));

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<ConnectionContextResponsible>(options =>
    options.UseNpgsql("Server=localhost;Port=5432;Database=teatechdatabase;User Id=postgres;Password=ARROZDOCE;"));

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<ConnectionContextUser>(options =>
    options.UseNpgsql("Server=localhost;Port=5432;Database=teatechdatabase;User Id=postgres;Password=ARROZDOCE;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
