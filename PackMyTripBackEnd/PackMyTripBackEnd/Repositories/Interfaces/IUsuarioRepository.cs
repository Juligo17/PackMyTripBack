using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario getUsuario(string usuario, string contrasenha);
        bool crearUsuario(Usuario usuario);
        bool actualizarRegion(Usuario usuario);
        bool actualizarUsuario(Usuario usuario);
        List<PaqueteTuristico> getPaquetesTuristicosUsuario (string ?correoUsuario); // Sera útil tanto para turista cómo para intermediario
        public bool actualizarComentariosCalificacion(int idPaquete, string? correoUsuario, string? comentarios, int? calificacion);

    }
}
