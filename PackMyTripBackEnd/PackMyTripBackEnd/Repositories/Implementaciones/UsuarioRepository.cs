using Dapper;
using MySql.Data.MySqlClient;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.Repositories.Implementaciones
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string connectionString = null!;

        public UsuarioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Usuario getUsuario(string correo, string contrasenha)
        {
            Usuario? usuarioRtn = new Usuario();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT  *,  DATE_FORMAT(fechaNacimiento, '%Y-%m-%d') AS fechaNacimiento FROM Usuario WHERE correo = @Correo AND " +
                    $"Contrasenha = @contrasenha";
                var resultado = connection.Query(sql,
                    new { Correo = correo, Contrasenha = contrasenha }).FirstOrDefault();
                if(resultado != null)
                {
                    var fechaNacimientoStr = resultado.fechaNacimiento.ToString("yyyy-MM-dd");
                    usuarioRtn.correo = resultado.correo;
                    usuarioRtn.usuario = resultado.usuario;
                    usuarioRtn.contrasenha = resultado.contrasenha;
                    usuarioRtn.fechaNacimiento = DateOnly.Parse(fechaNacimientoStr);
                    usuarioRtn.latitud = resultado.latitud;
                    usuarioRtn.longitud = resultado.longitud;
                    usuarioRtn.region = resultado.region;
                    usuarioRtn.tipo = Char.Parse(resultado.tipo);
                    usuarioRtn.fotoPerfil = resultado.fotoPerfil;
                }
                return usuarioRtn!;
            }
        }

        public List<PaqueteTuristico> getPaquetesAgenda(string? correoIntermediario)
        {
            List<PaqueteTuristico> paquetesTuristicos = new List<PaqueteTuristico>();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = @"SELECT PT.* FROM PaqueteTuristico PT INNER JOIN UsuarioXPaqueteTuristico UP ON PT.id = UP.idPaquete WHERE PT.correoIntermediario = @CorreoUsuario";

                IEnumerable<PaqueteTuristico> paquetesObtenidos = connection.Query<PaqueteTuristico>(sql, new
                {
                    CorreoUsuario = correoIntermediario
                });
                paquetesTuristicos = paquetesObtenidos.ToList();

            }
            return paquetesTuristicos;
        }

        public List<PaqueteTuristico> getPaquetesTuristicosUsuario(string? correoUsuario)
    {
        List<PaqueteTuristico> paquetesTuristicos = new List<PaqueteTuristico>();
        using (var connection = new MySqlConnection(connectionString))
        {
            string sql = @"
        SELECT 
            PT.*, 
            S.* 
        FROM 
            PaqueteTuristico PT
            INNER JOIN UsuarioXPaqueteTuristico UP ON PT.id = UP.idPaquete
            INNER JOIN PaqueteTuristicoXServicio PS ON PT.id = PS.idPaquete
            INNER JOIN Servicio S ON PS.idServicio = S.id
        WHERE 
            UP.correoUsuario = @CorreoUsuario";

            var paquetesDictionary = new Dictionary<int, PaqueteTuristico>();
            connection.Query<PaqueteTuristico, Servicio, PaqueteTuristico>(sql,
                (paquete, servicio) =>
                {
                    PaqueteTuristico paqueteEntry;
                    if (!paquetesDictionary.TryGetValue(paquete.id, out paqueteEntry))
                    {
                        paqueteEntry = paquete;
                        paqueteEntry.listaServicios = new List<Servicio>();
                        paquetesDictionary.Add(paqueteEntry.id, paqueteEntry);
                    }
                    paqueteEntry.listaServicios.Add(servicio);
                    return paqueteEntry;
                },
                new { CorreoUsuario = correoUsuario },
                splitOn: "id");

            paquetesTuristicos = paquetesDictionary.Values.ToList();
        }
        return paquetesTuristicos;
    }


        





        public bool crearUsuario(Usuario usuario)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                //string fechaConFormato = usuario.fechaNacimiento.ToString("yyyy-MM-dd");
                string sql = $"INSERT INTO Usuario (correo, usuario, contrasenha, fechaNacimiento, " +
                    $"latitud, longitud, region, tipo, fotoPerfil) VALUES (@Correo, @Usuario, " +
                    $"@Contrasenha, @FechaNacimiento, @Latitud, " +
                    $"@Longitud, @Region, @Tipo, @FotoPerfil)";
                int filasAfectadas = connection.Execute(sql, new
                {
                    Correo = usuario.correo,
                    Usuario = usuario.usuario,
                    Contrasenha = usuario.contrasenha,
                    FechaNacimiento = usuario.fechaNacimiento,
                    Latitud = usuario.latitud,
                    Longitud = usuario.longitud,
                    Region = usuario.region,
                    Tipo = usuario.tipo,
                    FotoPerfil = usuario.fotoPerfil
                }); //Default puesto a que este si puede retornar nulo first primer registro
                if (filasAfectadas == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool registrarPaqueteUsuario(string? correoUsuario, int idPaquete)
        {
            using (var connection = new MySqlConnection(
                connectionString))
            {
                string sql = "INSERT INTO UsuarioXPaqueteTuristico(correoUsuario, idPaquete) VALUES (@CorreoUsuario, @IDPaquete)";
                int filasAfectadas = connection.Execute(sql,
                    new
                    {
                        CorreoUsuario = correoUsuario,
                        IDPaquete = idPaquete
                    });
                if (filasAfectadas == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool actualizarRegion(Usuario usuario)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE Usuario SET latitud = @Latitud, " +
                    $"longitud = @Longitud," +
                    $" region = @Region " +
                    $"WHERE correo = @Correo";
                int filasAfectadas = connection.Execute(sql, new
                {
                    Latitud = usuario.latitud,
                    Longitud = usuario.longitud,
                    Region = usuario.region,
                    Correo = usuario.correo
                });
                if (filasAfectadas == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool actualizarUsuario(Usuario usuario)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"UPDATE Usuario SET usuario = @Usuario, " +
                    $"contrasenha = @Contrasenha," +
                    $" fotoPerfil = @FotoPerfil " +
                    $"WHERE correo = @Correo";
                int filasAfectadas = connection.Execute(sql, new
                {
                    Usuario = usuario.usuario,
                    Contrasenha = usuario.contrasenha,
                    FotoPerfil = usuario.fotoPerfil,
                    Correo = usuario.correo
                });
                if (filasAfectadas == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool actualizarComentariosCalificacion(int idPaquete, string correoUsuario, string comentarios, int calificacion)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = @"UPDATE UsuarioXPaqueteTuristico
                       SET comentarios = @Comentarios, calificacion = @Calificacion
                       WHERE idPaquete = @IdPaquete AND correoUsuario = @CorreoUsuario";

                int rowsAffected = connection.Execute(sql, new { Comentarios = comentarios, Calificacion = calificacion, IdPaquete = idPaquete, CorreoUsuario = correoUsuario });

                return rowsAffected > 0;
            }
        }

    }
}
