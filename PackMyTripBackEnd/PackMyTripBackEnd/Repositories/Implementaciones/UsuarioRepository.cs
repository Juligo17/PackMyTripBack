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

        public Usuario getUsuario(string usuario, string contrasenha)
        {
            Usuario? usuarioRtn = new Usuario();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT  *,  DATE_FORMAT(fechaNacimiento, '%Y-%m-%d') AS fechaNacimiento FROM Usuario WHERE usuario = @Usuario AND " +
                    $"Contrasenha = @contrasenha";
                var resultado = connection.Query(sql,
                    new { Usuario = usuario, Contrasenha = contrasenha }).FirstOrDefault();
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

        public bool crearUsuario(Usuario usuario)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string fechaConFormato = usuario.fechaNacimiento.ToString("yyyy-MM-dd");
                string sql = @$"INSERT INTO Usuario (correo, usuario, contrasenha, fechaNacimiento,
                    latitud, longitud, region, tipo, fotoPerfil) VALUES (@Correo, @Usuario, 
                    @Contrasenha, @FechaNacimiento, @Latitud,
                    @Longitud, @Region, @Tipo, @FotoPerfil)";
                int filasAfectadas = connection.Execute(sql, new
                {
                    Correo = usuario.correo,
                    Usuario = usuario.usuario,
                    Contrasenha = usuario.contrasenha,
                    FechaNacimiento = fechaConFormato,
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
    }
}
