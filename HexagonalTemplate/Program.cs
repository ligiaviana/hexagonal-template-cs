using HexagonalTemplate.Adapters.SqliteAdapters;
using HexagonalTemplate.Cores;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using HexagonalTemplate.UseCases;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
builder.Services.AddScoped<ILoginUserUseCase, LoginUserUseCase>();
builder.Services.AddScoped<IFindUserUseCase, FindUserUseCase>();
builder.Services.AddScoped<IFindAppUseCase, FindAppUseCase>();
builder.Services.AddScoped<IGenerateAppUseCase, GenerateAppUseCase>();
builder.Services.AddScoped<ICreateTeamsAppUserUseCase, CreateTeamsAppUserUseCase>();
builder.Services.AddScoped<IFindTeamsAppUserUseCase, FindTeamsAppUserUseCase>();
builder.Services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
builder.Services.AddScoped<IDeleteAppUseCase, DeleteAppUseCase>();
builder.Services.AddScoped<IDeleteTeamsAppUserUseCase, DeleteTeamsAppUserUseCase>();
builder.Services.AddScoped<ILogCore, LogCore>();
builder.Services.AddScoped<IUserCore, UserCore>();
builder.Services.AddScoped<IGenerateAppCore, GenerateAppCore>();
builder.Services.AddScoped<ICreateTeamsAppUserCore, CreateTeamsAppUserCore>();
builder.Services.AddScoped<IFindTeamsAppUserCore, FindTeamsAppUserCore>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAppRepository, AppRepository>();

// Load configuration
IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

var key = configuration.GetValue<string>("Jwt:Key");
var issuer = configuration.GetValue<string>("Jwt:Issuer");

var jwtCore = new JwtCore(configuration);
builder.Services.AddScoped<IJwtCore>(_ => jwtCore); 

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });

// Add DbContext
builder.Services.AddDbContext<HexagonalDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AppRepositoryDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.MapControllers();

app.UseAuthentication();

app.UseAuthorization();

app.Run();
