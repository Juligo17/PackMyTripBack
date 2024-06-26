using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;

namespace PackMyTripBackEnd.Repositories.Implementaciones
{
    public class PaqueteTuristicoXServicioRepository : IPaqueteTuristicoXServicioRepository
    {
        private string connectionString = null!;
        private IServicioRepository servicioRepository;

        public PaqueteTuristicoXServicioRepository(string connectionString, IServicioRepository servicioRepository)
        {
            this.connectionString = connectionString;
            this.servicioRepository = servicioRepository;
        }
        public List<PaqueteTuristicoXServicio> getPaquetesTuristicosXServicioPorPaquete(int idPaquete)
        {
            List<PaqueteTuristicoXServicio> paquetesTuristicosXServicio = new List<PaqueteTuristicoXServicio>();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM PaqueteTuristicoXServicio WHERE idPaquete = @IdPaquete";
                IEnumerable<PaqueteTuristicoXServicio> paquetesTuristicosXServicioObtenidos = connection.Query<PaqueteTuristicoXServicio>(sql,
                    new { IdPaquete = idPaquete }); //Hace el query
                paquetesTuristicosXServicio = paquetesTuristicosXServicioObtenidos.ToList();
            }
            return paquetesTuristicosXServicio;
        }

        public List<Servicio> getServiciosPorPaquete(int idPaquete)
        {
            List<PaqueteTuristicoXServicio> paquetesTuristicosXServicio = new List<PaqueteTuristicoXServicio>();
            List<Servicio> servicios = new List<Servicio>();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM PaqueteTuristicoXServicio WHERE idPaquete = @IdPaquete";
                IEnumerable<PaqueteTuristicoXServicio> paquetesTuristicosXServicioObtenidos = connection.Query<PaqueteTuristicoXServicio>(sql,
                    new { IdPaquete = idPaquete }); //Hace el query
                foreach(var paqueteXServ in paquetesTuristicosXServicioObtenidos.ToList())
                {
                    servicios.Add(servicioRepository.getServicio(paqueteXServ.idServicio));
                }
                paquetesTuristicosXServicio = paquetesTuristicosXServicioObtenidos.ToList();
            }
            return servicios;
        }

        public PaqueteTuristicoXServicio getPaqueteTuristicoXServicio(int id)
        {
            PaqueteTuristicoXServicio paqueteTuristicoXServicio = new PaqueteTuristicoXServicio();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM PaqueteTuristicoXServicio WHERE id = @Id";
                IEnumerable<PaqueteTuristicoXServicio> paqueteTuristicoXServicioObtenido = connection.Query<PaqueteTuristicoXServicio>(sql,
                    new { Id = id }); //Hace el query
                paqueteTuristicoXServicio = paqueteTuristicoXServicioObtenido.First(); //Default puesto a que este si puede retornar nulo first primer registro
            }
            return paqueteTuristicoXServicio;
        }

        public bool insertPaqueteTuristicoXServicio(PaqueteTuristicoXServicio paqueteTuristicoXServicio)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = @$"INSERT INTO PaqueteTuristicoXServicio (idPaquete, idServicio, tiempoEstancia) 
                VALUES (@IdPaquete, @IdServicio, @TiempoEstancia)";
                int filasAfectadas = connection.Execute(sql, new
                {
                    IdPaquete = paqueteTuristicoXServicio.idPaquete,
                    IdServicio = paqueteTuristicoXServicio.idServicio,
                    TiempoEstancia = paqueteTuristicoXServicio.tiempoEstancia
                }); ;
                if (filasAfectadas == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool updatePaqueteTuristicoXServicio(PaqueteTuristicoXServicio paqueteTuristicoXServicio)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = @$"UPDATE PaqueteTuristicoXServicio SET idPaquete = @IdPaquete, idServicio = @IdServicio  WHERE id = @Id";
                int filasAfectadas = connection.Execute(sql, new
                {
                    Id = paqueteTuristicoXServicio.id,
                    IdPaquete = paqueteTuristicoXServicio.idPaquete,
                    IdServicio = paqueteTuristicoXServicio.idServicio
                });
                if (filasAfectadas == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool deletePaqueteTuristicoXServicio(int? id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = @$"DELETE FROM PaqueteTuristicoXServicio WHERE id = @Id";
                int filasAfectadas = connection.Execute(sql, new
                {
                    Id = id
                });
                if (filasAfectadas == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}