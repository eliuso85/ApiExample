using Aplicacion.Interfaces;
using Aplicacion.Services;
using Infraestructura.Repository.Data;
using Infraestructura.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

//Se obtiene el Connection String de a BD.
var connectionString = builder.Configuration.GetConnectionString("DefaultConn");
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));

// Add services to the container.
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IUsersService, UsersService>();

builder.Services.AddControllers();
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
