using HexagonalTemplate.Adapters.SqliteAdapters;
using HexagonalTemplate.Cores;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using HexagonalTemplate.UseCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRegisterUseCase, RegisterUseCase>();
builder.Services.AddScoped<ILoginUseCase, LoginUseCase>();
builder.Services.AddScoped<ILogCore, LogCore>();
builder.Services.AddScoped<IUserCore, UserCore>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFindUseCase, FindUseCase>();

//builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<HexagonalDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

var secretKey = configuration.GetValue<string>("JwtSettings:SecretKey");
var expirationInMinutes = configuration.GetValue<double>("JwtSettings:ExpirationInMinutes");
builder.Services.AddScoped<IJwtCore>(x => new JwtCore(secretKey, expirationInMinutes));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
