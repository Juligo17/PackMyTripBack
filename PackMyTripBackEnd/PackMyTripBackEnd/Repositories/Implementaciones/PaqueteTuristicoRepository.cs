using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;

namespace PackMyTripBackEnd.Repositories.Implementaciones
{
    public class PaqueteTuristicoRepository : IPaqueteTuristicoRepository
    {
        private string connectionString = null!;

        public PaqueteTuristicoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public List<PaqueteTuristico> getPaquetesTuristicos()
        {
            List<PaqueteTuristico> paquetesTuristicos = new List<PaqueteTuristico>();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM PaqueteTuristico";
                IEnumerable<PaqueteTuristico> paquetesTuristicosObtenidos = connection.Query<PaqueteTuristico>(sql); //Hace el query
                paquetesTuristicos = paquetesTuristicosObtenidos.ToList();
            }
            return paquetesTuristicos;
        }

        public List<PaqueteTuristico> getPaquetesTuristicosPorIntermediario(string? correoIntermediario)
        {
            List<PaqueteTuristico> paquetesTuristicos = new List<PaqueteTuristico>();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM PaqueteTuristico WHERE correoIntermediario = @CorreoIntermediario";
                IEnumerable<PaqueteTuristico> paquetesTuristicosObtenidos = connection.Query<PaqueteTuristico>(sql,
                    new { CorreoIntermediario = correoIntermediario }); //Hace el query
                paquetesTuristicos = paquetesTuristicosObtenidos.ToList();
            }
            return paquetesTuristicos;
        }

        public PaqueteTuristico getPaqueteTuristico(int id)
        {
            PaqueteTuristico paqueteTuristico = new PaqueteTuristico();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM PaqueteTuristico WHERE id = @Id";
                IEnumerable<PaqueteTuristico> paqueteTuristicoObtenido = connection.Query<PaqueteTuristico>(sql,
                    new { Id = id }); //Hace el query
                paqueteTuristico = paqueteTuristicoObtenido.First(); //Default puesto a que este si puede retornar nulo first primer registro
            }
            return paqueteTuristico;
        }

        public List<Servicio> getServiciosPaquete(int id)
        {
            List<Servicio> servicios = new List<Servicio>();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT S.* FROM Servicio S " +
                             $"INNER JOIN PaqueteTuristicoXServicio PS ON S.id = PS.idServicio " +
                             $"WHERE PS.idPaquete = @IdPaquete";

                IEnumerable<Servicio> serviciosObtenidos = connection.Query<Servicio>(sql, new { IdPaquete = id });
                servicios = serviciosObtenidos.ToList();
            }
            return servicios;
        }

        public bool insertPaqueteTuristico(PaqueteTuristico paqueteTuristico)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = @$"INSERT INTO PaqueteTuristico (nombre, fechaHora, precioDolares, imagen) 
                    VALUES (@Nombre, @FechaHora, @PrecioDolares, @Imagen, @CorreoIntermediario)";
                int filasAfectadas = connection.Execute(sql, new
                {
                    Nombre = paqueteTuristico.nombre,
                    FechaHora = paqueteTuristico.fechaHora,
                    PrecioDolares = paqueteTuristico.precioDolares,
                    Imagen = paqueteTuristico.imagen,
                    CorreoIntermediario = paqueteTuristico.correoIntermediario
                }); //Default puesto a que este si puede retornar nulo first primer registro
                if (filasAfectadas == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool updatePaqueteTuristico(PaqueteTuristico paqueteTuristico)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE PaqueteTuristico SET nombre = @Nombre, " +
                    $"fechaHora = @FechaHora, precioDolares = @PrecioDolares, imagen = @Imagen , correoIntermediario + @CorreoIntermediario" +
                    $"WHERE id = @Id";
                int filasAfectadas = connection.Execute(sql, new
                {
                    Nombre = paqueteTuristico.nombre,
                    FechaHora = paqueteTuristico.fechaHora,
                    PrecioDolares = paqueteTuristico.precioDolares,
                    Imagen = paqueteTuristico.imagen,
                    Id = paqueteTuristico.id,
                    CorreoIntermediario = paqueteTuristico.correoIntermediario
                }) ;
                if (filasAfectadas == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}