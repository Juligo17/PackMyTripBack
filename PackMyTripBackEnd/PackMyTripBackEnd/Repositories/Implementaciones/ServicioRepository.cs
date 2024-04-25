using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;
using System.Text;
using Org.BouncyCastle.Operators;
using System.Data;

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
                    new { CorreoOperador = correoOperador }); //Hace el query
                servicios = serviciosObtenidos.ToList();
            }
            return servicios;
        }

        public List<Servicio> getAllServicios()
        {
            List<Servicio> servicios = new List<Servicio>() ;
            using (var connection = new MySqlConnection(connectionString)) 
            {
                string sql = $"SELECT * FROM Servicio";
                IEnumerable<Servicio> serviciosObtenidos = connection.Query<Servicio>(sql);
                servicios = serviciosObtenidos.ToList() ;
            }
            return servicios;
        }


        public bool insertServicio(Servicio servicio)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = @$"INSERT INTO Servicio (nombre, precio, limiteDiario, caracteristicas,
                    portada, fechaHora, correoOperador) VALUES (@Nombre,@Precio, 
                    @LimiteDiario, @Caracteristicas, @Portada,
                    @FechaHora, @CorreoOperador)";
                int filasAfectadas = connection.Execute(sql, new { Nombre = servicio.nombre,
                    Portada = servicio.portada, Precio = servicio.precio, LimiteDiario = servicio.limiteDiario,
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
                    $" caracteristicas = @Caracteristicas, fechaHora = @FechaHora, " +
                    $"portada = @Portada " +
                    $"WHERE id = @Id";
                int filasAfectadas = connection.Execute(sql, new { Precio = servicio.precio,
                    LimiteDiario = servicio.limiteDiario, Caracteristicas = servicio.caracteristicas,
                    FechaHora = servicio.fechaHora,
                    Portada = servicio.portada, Id = servicio.id });
                if (filasAfectadas == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Servicio> getServiciosMetricas(string? correoOperador)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = getSqlQueryServiciosMetricas();
                IEnumerable<Servicio> serviciosMetricas = connection.Query<Servicio>(sql,
                        new { CorreoOperador = correoOperador });
                return serviciosMetricas.ToList();
            }
        }

        private string getSqlQueryServiciosMetricas()
        {
            return getWithCantUsuariosRepetidosRepetidoMetricas() + "" +
                getWithCantUsuariosRepetidosXServicioXUsuarioMetricas() + "" +
                   getWithCantUsuariosRepetidosXServicioMetricas() + "" +
                   getSelectPrincipalMetricas();
        }

        private string getWithCantUsuariosRepetidosRepetidoMetricas()
        {
            return
                @"WITH CantUsuariosRepetidosRepetido AS(
	                    SELECT Servicio.id, UsuarioXPaqueteTuristico.correoUsuario, 
                        CASE
		                    WHEN COUNT(Servicio.id) OVER(PARTITION BY Servicio.id, UsuarioXPaqueteTuristico.correoUsuario) = 1 THEN 0 
		                    ELSE 1
	                    END
                        AS Conteo
                        FROM UsuarioXPaqueteTuristico
                        INNER JOIN PaqueteTuristicoXServicio ON PaqueteTuristicoXServicio.idPaquete = UsuarioXPaqueteTuristico.idPaquete
	                    INNER JOIN PaqueteTuristico ON PaqueteTuristico.id = PaqueteTuristicoXServicio.idPaquete
	                    INNER JOIN Servicio ON Servicio.id = PaqueteTuristicoXServicio.idServicio
                        WHERE Servicio.correoOperador = @CorreoOperador
	                    ORDER BY Servicio.id ASC
                    )";
        }

        private string getWithCantUsuariosRepetidosXServicioXUsuarioMetricas()
        {
            return
                @", CantUsuariosRepetidosXServicioXUsuario AS (
	                    SELECT id, correoUsuario, SUM(Conteo) AS CUsuariosRepServXUsuario
                        FROM CantUsuariosRepetidosRepetido
                        GROUP BY correoUsuario, id
                    )";
        }

        private string getWithCantUsuariosRepetidosXServicioMetricas()
        {
            return
                @", CantUsuariosRepetidosXServicio AS(
	                SELECT id, correoUsuario, SUM(CUsuariosRepServXUsuario) AS CUsuariosRepServ
                    FROM CantUsuariosRepetidosXServicioXUsuario
                    GROUP BY id
                 )";
        }

        private string getSelectPrincipalMetricas()
        {
            return
                @"SELECT Servicio.*, 
                        (COUNT(*)/Servicio.limiteDiario)*100 AS tasaOcupacion,
                        SEC_TO_TIME(SUM(TIME_TO_SEC(PaqueteTuristicoXServicio.tiempoEstancia))
                        /COUNT(Servicio.id)) AS horasPromedio, 
                        COUNT(Servicio.id)*Servicio.precio AS ingresos,
	                    (CantUsuariosRepetidosXServicio.CUsuariosRepServ/ 
                        COUNT(DISTINCT(UsuarioXPaqueteTuristico.correoUsuario)))*100 AS indiceRepeticion
                    FROM 
                    UsuarioXPaqueteTuristico 
                    INNER JOIN PaqueteTuristicoXServicio ON PaqueteTuristicoXServicio.idPaquete = UsuarioXPaqueteTuristico.idPaquete
                    INNER JOIN PaqueteTuristico ON PaqueteTuristico.id = PaqueteTuristicoXServicio.idPaquete
                    INNER JOIN Servicio ON Servicio.id = PaqueteTuristicoXServicio.idServicio
                    INNER JOIN CantUsuariosRepetidosXServicio ON CantUsuariosRepetidosXServicio.id = Servicio.id
                    WHERE Servicio.correoOperador = @CorreoOperador
                    GROUP BY Servicio.id
                    ORDER BY Servicio.id ASC";
        }

        
    }
}
