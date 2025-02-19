using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModestyRubis.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ModestyRubisContext>(options =>
 {
     options.UseSqlServer(builder.Configuration.GetConnectionString("Somee"));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
