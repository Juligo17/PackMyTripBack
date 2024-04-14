using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;
using Dapper;
using MySql.Data.MySqlClient;

namespace PackMyTripBackEnd.Repositories.Implementaciones
{
    public class MensajeRepository : IMensajeRepository
    {
        private string connectionString = null!;
        public MensajeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public Mensaje getMensaje(int id)
        {
            Mensaje mensaje = new Mensaje();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Mensaje WHERE id = @Id";
                IEnumerable<Mensaje> mensajeObtenido = connection.Query<Mensaje>(sql,
                    new { Id = id }); //Hace el query
                mensaje = mensajeObtenido.First(); //Default puesto a que este si puede retornar nulo first primer registro
            }
            return mensaje;
        }

        public List<Mensaje> getMensajesEntreUsuarios(string? correoUsuario1, string? correoUsuario2)
        {
            List<Mensaje> mensajes = new List<Mensaje>();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Mensaje WHERE correoUsuario1 = @CorreoUsuario1 AND correoUsuario2 = @CorreoUsuario2";
                IEnumerable<Mensaje> mensajesObtenidos = connection.Query<Mensaje>(sql,
                    new { CorreoUsuario1 = correoUsuario1, CorreoUsuario2 = correoUsuario2 }); //Hace el query
                mensajes = mensajesObtenidos.ToList();
            }
            return mensajes;
        }

        public List<Mensaje> getMensajesEnviadosPorUsuarioEntreDos(string? correoUsuario1, string? correoUsuario2)
        {
            List<Mensaje> mensajes = new List<Mensaje>();
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM Mensaje WHERE correoUsuario1 = @CorreoUsuario1 AND correoUsuario2 = @CorreoUsuario2 AND enviado = @Enviado";
                IEnumerable<Mensaje> mensajesObtenidos = connection.Query<Mensaje>(sql,
                    new { CorreoUsuario1 = correoUsuario1, CorreoUsuario2 = correoUsuario2, Enviado = true }); //Hace el query
                mensajes = mensajesObtenidos.ToList();
            }
            return mensajes;
        }

        public bool insertMensaje(Mensaje mensaje)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string sql = @$"INSERT INTO Mensaje (correoUsuario1, correoUsuario2, mensaje, enviado, hora) 
                VALUES (@CorreoUsuario1, @CorreoUsuario2, @Mensaje, @Enviado, @Hora)";
                connection.Execute(sql, new
                {
                    CorreoUsuario1 = mensaje.correoUsuario1,
                    CorreoUsuario2 = mensaje.correoUsuario2,
                    Mensaje = mensaje.mensaje,
                    Enviado = mensaje.enviado,
                    Hora = mensaje.hora
                });
            }
            return true;
        }
    }
}