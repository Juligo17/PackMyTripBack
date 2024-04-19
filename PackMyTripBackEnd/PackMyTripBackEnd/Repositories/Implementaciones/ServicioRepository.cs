using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;

namespace PackMyTripBackEnd.Repositories.Implementaciones
{
    public class ServicioRepository : IServicioRepository
    {
        private string connectionString = null!;

        public ServicioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Servicio> getServicios(string? correoOperador)
        {
            List<Servicio> servicios = new List<Servicio>();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Servicio WHERE correoOperador = @CorreoOperador";
                IEnumerable<Servicio> serviciosObtenidos = connection.Query<Servicio>(sql, 
                    new{ CorreoOperador = correoOperador}); //Hace el query
                servicios = serviciosObtenidos.ToList();
            }
            return servicios;
        }

        public bool insertServicio(Servicio servicio)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = @$"INSERT INTO Servicio (nombre, precio, limiteDiario, caracteristicas,
                    portada, fechaHora, correoOperador) VALUES (@Nombre,@Precio, 
                    @LimiteDiario, @Caracteristicas, @DatosBlob,
                    @FechaHora, @CorreoOperador)";
                int filasAfectadas = connection.Execute(sql, new { Nombre = servicio.nombre,
                    DatosBlob = servicio.portada, Precio = servicio.precio, LimiteDiario = servicio.limiteDiario,
                    Caracteristicas = servicio.caracteristicas, FechaHora = servicio.fechaHora, 
                    CorreoOperador = servicio.correoOperador
                }); //Default puesto a que este si puede retornar nulo first primer registro
                if (filasAfectadas == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool updateServicio(Servicio servicio)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE Servicio SET precio = @Precio, " +
                    $"limiteDiario = @LimiteDiario," +
                    $" caracteristicas = @Caracteristicas, fechaHora = @FechaHora " +
                    $"WHERE id = @Id";
                int filasAfectadas = connection.Execute(sql, new {Precio = servicio.precio, 
                    LimiteDiario = servicio.limiteDiario, Caracteristicas = servicio.caracteristicas,
                    FechaHora = servicio.fechaHora, Id = servicio.id});
                if (filasAfectadas == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
