using HexagonalTemplate.Adapters.SqliteAdapters;
using HexagonalTemplate.Cores;
using HexagonalTemplate.Ports.Ins;
using HexagonalTemplate.Ports.Outs;
using HexagonalTemplate.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRegisterUseCase, RegisterUseCase>();
builder.Services.AddScoped<ILoginUseCase, LoginUseCase>();
builder.Services.AddScoped<IJwtCore, JwtCore>();
builder.Services.AddScoped<ILogCore, LogCore>();
builder.Services.AddScoped<IUserCore, UserCore>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
