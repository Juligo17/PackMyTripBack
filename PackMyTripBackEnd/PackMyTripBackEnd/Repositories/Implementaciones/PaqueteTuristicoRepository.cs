using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;

namespace PackMyTripBackEnd.Repositories.Implementaciones
{
    public class PaqueteTuristicoRepository : IPaqueteTuristicoRepository
    {
        private string connectionString = null!;
        private PaqueteTuristicoXServicioRepository paqueteTuristicoXServicioRepository;

        public PaqueteTuristicoRepository(string connectionString, PaqueteTuristicoXServicioRepository paqueteTuristicoXServicioRepository)
        {
            this.connectionString = connectionString;
            this.paqueteTuristicoXServicioRepository = paqueteTuristicoXServicioRepository;
        }


        public List<PaqueteTuristico> getPaquetesTuristicos()
        {
            List<PaqueteTuristico> paquetesTuristicos = new List<PaqueteTuristico>();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM PaqueteTuristico";
                IEnumerable<PaqueteTuristico> paquetesTuristicosObtenidos = connection.Query<PaqueteTuristico>(sql); //Hace el query
                paquetesTuristicos = paquetesTuristicosObtenidos.ToList();
                foreach (var paquete in paquetesTuristicosObtenidos)
                {
                    List<Servicio> servicios = paqueteTuristicoXServicioRepository.getServiciosPorPaquete(paquete.id);
                    paquete.listaServicios = servicios;
                }
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
                foreach(var paquete in paquetesTuristicosObtenidos)
                {
                    List<Servicio> servicios = paqueteTuristicoXServicioRepository.getServiciosPorPaquete(paquete.id);
                    paquete.listaServicios = servicios;
                }
                paquetesTuristicos = paquetesTuristicosObtenidos.ToList();
            }
            return paquetesTuristicos;
        }

        public List<Servicio> getServiciosPaquete(int idPaquete)
        {
            List<Servicio> serviciosObtenidos = new List<Servicio>();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = @"SELECT S.*
                       FROM Servicio S
                       INNER JOIN PaqueteTuristicoXServicio PS ON S.id = PS.idServicio
                       WHERE PS.idPaquete = @IdPaquete";

                serviciosObtenidos = connection.Query<Servicio>(sql, new { IdPaquete = idPaquete }).ToList();
            }
            return serviciosObtenidos;
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

        public bool insertPaqueteTuristico(PaqueteTuristico paqueteTuristico)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = @$"INSERT INTO PaqueteTuristico (nombre, fechaHora, precioDolares, correoIntermediario, imagen) 
                    VALUES (@Nombre, @FechaHora, @PrecioDolares, @CorreoIntermediario, @Imagen);
                    SELECT LAST_INSERT_ID();";
                int idGenerado = connection.QuerySingle<int>(sql, new
                {
                    Nombre = paqueteTuristico.nombre,
                    FechaHora = paqueteTuristico.fechaHora,
                    PrecioDolares = paqueteTuristico.precioDolares,
                    CorreoIntermediario = paqueteTuristico.correoIntermediario,
                    Imagen = paqueteTuristico.imagen
                }); //Default puesto a que este si puede retornar nulo first primer registro
                if (idGenerado != 0)
                {
                    var servicios = paqueteTuristico.listaServicios;
                    if(servicios == null)
                    {
                        return false;
                    }
                    foreach (var servicio in servicios)
                    {
                        PaqueteTuristicoXServicio paqueteTuristicoXServicio = new PaqueteTuristicoXServicio ();
                        paqueteTuristicoXServicio.id = 0;
                        paqueteTuristicoXServicio.idPaquete = idGenerado;
                        paqueteTuristicoXServicio.idServicio = servicio.id;
                        paqueteTuristicoXServicioRepository.insertPaqueteTuristicoXServicio(paqueteTuristicoXServicio);
                    }
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
                    $"fechaHora = @FechaHora, precioDolares = @PrecioDolares, correoIntermediario = @CorreoIntermediario, imagen = @Imagen " +
                    $"WHERE id = @Id";
                int filasAfectadas = connection.Execute(sql, new
                {
                    Nombre = paqueteTuristico.nombre,
                    FechaHora = paqueteTuristico.fechaHora,
                    PrecioDolares = paqueteTuristico.precioDolares,
                    CorreoIntermediario = paqueteTuristico.correoIntermediario,
                    Imagen = paqueteTuristico.imagen,
                    Id = paqueteTuristico.id
                });
                if (filasAfectadas == 1)
                {
                    var servicios = paqueteTuristico.listaServicios;
                    if (servicios == null)
                    {
                        return false;
                    }
                    List<PaqueteTuristicoXServicio> paqueteTuristicoXServicios = paqueteTuristicoXServicioRepository.getPaquetesTuristicosXServicioPorPaquete(paqueteTuristico.id);
                    foreach (var paqueteTuristicoXServicio in paqueteTuristicoXServicios)
                    {
                        paqueteTuristicoXServicioRepository.deletePaqueteTuristicoXServicio(paqueteTuristicoXServicio.id);
                    }
                    foreach (var servicio in servicios)
                    {
                        PaqueteTuristicoXServicio paqueteTuristicoXServicio = new PaqueteTuristicoXServicio();
                        paqueteTuristicoXServicio.id = 0;
                        paqueteTuristicoXServicio.idPaquete = paqueteTuristico.id;
                        paqueteTuristicoXServicio.idServicio = servicio.id;
                        paqueteTuristicoXServicioRepository.insertPaqueteTuristicoXServicio(paqueteTuristicoXServicio);
                    }
                    return true;
                }
            }
            return false;
        }
    }
}