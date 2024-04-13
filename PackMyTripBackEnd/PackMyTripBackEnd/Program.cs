using PackMyTripBackEnd.CasosUso.Implementaciones;
using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Repositories.Implementaciones;
using PackMyTripBackEnd.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Obtiene el string para conectarse a la base de datos de heroku
var dataBaseConnectionString = builder.Configuration.GetConnectionString("DataBaseConnectionString");

//Inyección de dependencias de servicios de casos de uso
builder.Services.AddScoped<IVerServiciosCU, VerServiciosCU>();  //Crea automaticamente el objeto sin el new a través de la interfaz
builder.Services.AddScoped<IRegistrarServicioCU, RegistrarServicioCU>();
builder.Services.AddScoped<IEditarServicioCU, EditarServicioCU>();

//Inyección de dependencias de repositorios
builder.Services.AddScoped<IServicioRepository>(opt => new ServicioRepository(dataBaseConnectionString)); //Para pasar un parámetro al constructor

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
