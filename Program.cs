using WebApplication1.Infrastructure;
using WebApplication1.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Interfaces.Repositories;
using WebApplication1.Interfaces.Services;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IChildAssistedRepository, ChildAssistedRepository>();
builder.Services.AddTransient<IResponsibleRepository, ResponsibleRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IResponsibleService, ResponsibleService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IChildAssistedService, ChildAssistedService>();


// Add services to the container.

builder.Services.AddSingleton<JwtService>(provider =>
{
    var secretKey = builder.Configuration["Jwt:SecretKey"];
    return new JwtService(secretKey);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<ConnectionContext>(options =>
    options.UseNpgsql("Server=localhost;Port=5432;Database=teatechdatabase;User Id=postgres;Password=ARROZDOCE;"));

//builder.Services.AddEntityFrameworkNpgsql()
//    .AddDbContext<ConnectionContextResponsible>(options =>
//    options.UseNpgsql("Server=localhost;Port=5432;Database=teatechdatabase;User Id=postgres;Password=ARROZDOCE;"));

//builder.Services.AddEntityFrameworkNpgsql()
//    .AddDbContext<ConnectionContextUser>(options =>
//    options.UseNpgsql("Server=localhost;Port=5432;Database=teatechdatabase;User Id=postgres;Password=ARROZDOCE;"));

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
