using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;

namespace PackMyTripBackEnd.Repositories.Implementaciones
{
    public class UsuarioXPaqueteTuristicoRepository : IUsuarioXPaqueteTuristicoRepository
    {
        private string connectionString = null!;

        public UsuarioXPaqueteTuristicoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<UsuarioXPaqueteTuristico> getUsuariosXPaqueteTuristicoPorCorreo(string? correoUsuario)
        {
            List<UsuarioXPaqueteTuristico> paquetesUsuario = new List<UsuarioXPaqueteTuristico>();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM UsuarioXPaqueteTuristico WHERE correoUsuario = @CorreoUsuario";
                IEnumerable<UsuarioXPaqueteTuristico> paquetesUsuarioObtenidos = connection.Query<UsuarioXPaqueteTuristico>(sql,
                    new { CorreoUsuario = correoUsuario }); //Hace el query
                paquetesUsuario = paquetesUsuarioObtenidos.ToList();
            }
            return paquetesUsuario;
        }

        public UsuarioXPaqueteTuristico getUsuarioXPaqueteTuristico(int id)
        {
            UsuarioXPaqueteTuristico usuarioXPaqueteTuristico = new UsuarioXPaqueteTuristico();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM UsuarioXPaqueteTuristico WHERE id = @Id";
                IEnumerable<UsuarioXPaqueteTuristico> usuarioXPaqueteTuristicoObtenido = connection.Query<UsuarioXPaqueteTuristico>(sql,
                    new { Id = id }); //Hace el query
                usuarioXPaqueteTuristico = usuarioXPaqueteTuristicoObtenido.First(); //Default puesto a que este si puede retornar nulo first primer registro
            }
            return usuarioXPaqueteTuristico;
        }

        public bool insertUsuarioXPaqueteTuristico(UsuarioXPaqueteTuristico usuarioXPaqueteTuristico)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = @$"INSERT INTO UsuarioXPaqueteTuristico (correoUsuario, idPaquete, calificacion, comentarios, comprobante) 
                VALUES (@CorreoUsuario, @IdPaquete, @Calificacion, @Comentarios, @Comprobante)";
                int filasAfectadas = connection.Execute(sql, new
                {
                    CorreoUsuario = usuarioXPaqueteTuristico.correoUsuario,
                    IdPaquete = usuarioXPaqueteTuristico.idPaquete,
                    Calificacion = usuarioXPaqueteTuristico.calificacion,
                    Comentarios = usuarioXPaqueteTuristico.comentarios,
                    Comprobante = usuarioXPaqueteTuristico.comprobante
                });
                if (filasAfectadas == 1)
                {
                    return true;
                }
            }
            return false;
        }

        public bool updateUsuarioXPaqueteTuristico(UsuarioXPaqueteTuristico usuarioXPaqueteTuristico)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = @$"UPDATE UsuarioXPaqueteTuristico SET correoUsuario = @CorreoUsuario, idPaquete = @IdPaquete, calificacion = @Calificacion, comentarios = @Comentarios, comprobante = @Comprobante WHERE id = @Id";
                int filasAfectadas = connection.Execute(sql, new
                {
                    Id = usuarioXPaqueteTuristico.id,
                    CorreoUsuario = usuarioXPaqueteTuristico.correoUsuario,
                    IdPaquete = usuarioXPaqueteTuristico.idPaquete,
                    Calificacion = usuarioXPaqueteTuristico.calificacion,
                    Comentarios = usuarioXPaqueteTuristico.comentarios,
                    Comprobante = usuarioXPaqueteTuristico.comprobante
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