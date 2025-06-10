using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModestyRubis.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ModestyRubisContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLSenai"));
});

// Adicionando CORS para aceitar requisições de qualquer origem
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodos", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// Ativando o CORS antes do mapeamento dos controllers
app.UseCors("PermitirTodos");

app.UseAuthorization();

app.MapControllers();

app.Run();
