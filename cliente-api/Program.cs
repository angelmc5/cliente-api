using cliente_api.Data;
using cliente_api.Repositorio.IRepositorio;
using cliente_api.Repositorio;
using Microsoft.EntityFrameworkCore;
using cliente_api.ClienteMappers;

var builder = WebApplication.CreateBuilder(args);

//Crear la conexión a la base de datos SQL
builder.Services.AddDbContext<ApplicationDbContext>(Opciones =>
{
    Opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL"));
});

//Agregamos las clase de repositorios
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();

//Agregarmos el automapper para la implementación de Dtos esquema repositorio paterm
builder.Services.AddAutoMapper(typeof(ClientesMapper));


// Add services to the container.

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

public partial class Program { }