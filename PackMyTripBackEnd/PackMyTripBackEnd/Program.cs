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
var dataBaseConnectionString = builder.Configuration.GetConnectionString("HostedDataBaseConnectionString");

//Inyecci�n de dependencias de servicios de casos de uso
builder.Services.AddScoped<IVerServiciosCU, VerServiciosCU>();  //Crea automaticamente el objeto sin el new a trav�s de la interfaz
builder.Services.AddScoped<IRegistrarServicioCU, RegistrarServicioCU>();
builder.Services.AddScoped<IEditarServicioCU, EditarServicioCU>();
builder.Services.AddScoped<IVerPaquetesCU, VerPaquetesCU>();
builder.Services.AddScoped<IRegistrarPaqueteCU, RegistrarPaqueteCU>();
builder.Services.AddScoped<IEditarPaquetesCU, EditarPaqueteCU>();
builder.Services.AddScoped<IVerUsuariosXPaqueteTuristicoCU, VerUsuariosXPaqueteTuristicoCU>();
builder.Services.AddScoped<IRegistrarUsuarioXPaqueteTuristicoCU, RegistrarUsuarioXPaqueteTuristicoCU>();
builder.Services.AddScoped<IEditarUsuarioXPaqueteTuristicoCU, EditarUsuarioXPaqueteTuristicoCU>();
builder.Services.AddScoped<IVerMensajesCU, VerMensajesCU>();
builder.Services.AddScoped<IRegistrarMensajeCU, RegistrarMensajeCU>();
builder.Services.AddScoped<IVerPaqueteTuristicoXServicioCU, VerPaqueteTuristicoXServicioCU>();
builder.Services.AddScoped<IRegistrarPaqueteTuristicoXServicioCU, RegistrarPaqueteTuristicoXServicioCU>();
builder.Services.AddScoped<IEditarPaqueteTuristicoXServicioCU, EditarPaqueteTuristicoXServicioCU>();
builder.Services.AddScoped<ICrearPerfilesCU, CrearPerfilesCU>();
builder.Services.AddScoped<ISeleccionarRegionCU, SeleccionarRegionCU>();
builder.Services.AddScoped<IEditarUsuarioCU, EditarUsuarioCU>();
builder.Services.AddScoped<IGetPaquetesUsuarioCU, GetPaquetesUsuarioCU>();
builder.Services.AddScoped<IGetServiciosPaqueteCU, GetServiciosPaqueteCU>();
builder.Services.AddScoped<IEditarComentarioCalificacionesCU, EditarComentarioCalificacionCU>();
builder.Services.AddScoped<IVerAllServiciosCU, VerAllServiciosCU>();
builder.Services.AddScoped<IVerMetricasCU, VerMetricasCU>();
builder.Services.AddScoped<ICrearPaqueteCU, CrearPaqueteCU>();
builder.Services.AddScoped<IRegistrarPaqueteUsuarioCU, RegistrarPaqueteUsuarioCU>();
builder.Services.AddScoped<IGetAgendaCU, GetAgendaInterCU>();


//Inyecci�n de dependencias de repositorios
builder.Services.AddScoped<IServicioRepository>(opt => new ServicioRepository(dataBaseConnectionString)); //Para pasar un par�metro al constructor
builder.Services.AddScoped<IPaqueteTuristicoRepository>(opt => new PaqueteTuristicoRepository(dataBaseConnectionString, new PaqueteTuristicoXServicioRepository(dataBaseConnectionString, new ServicioRepository(dataBaseConnectionString))));
builder.Services.AddScoped<IUsuarioXPaqueteTuristicoRepository>(opt => new UsuarioXPaqueteTuristicoRepository(dataBaseConnectionString));
builder.Services.AddScoped<IMensajeRepository>(opt => new MensajeRepository(dataBaseConnectionString));
builder.Services.AddScoped<IPaqueteTuristicoXServicioRepository>(opt => new PaqueteTuristicoXServicioRepository(dataBaseConnectionString, new ServicioRepository(dataBaseConnectionString)));
builder.Services.AddScoped<IUsuarioRepository>(opt => new UsuarioRepository(dataBaseConnectionString));

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
