using Backend_TeaTech.Infrastructure;
using Backend_TeaTech.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Services;
using Backend_TeaTech.Interfaces.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddTransient<IChildAssistedRepository, ChildAssistedRepository>();
builder.Services.AddTransient<IResponsibleRepository, ResponsibleRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IResponsibleService, ResponsibleService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IChildAssistedService, ChildAssistedService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IPreAnalysisRepository, PreAnalysisRepository>();
builder.Services.AddTransient<IPreAnalysisService, PreAnalysisService>();

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

builder.Services.AddDbContext<ConnectionContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

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
