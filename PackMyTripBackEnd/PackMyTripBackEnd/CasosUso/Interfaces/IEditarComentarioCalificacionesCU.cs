using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.CasosUso.Interfaces
{
    public interface IEditarComentarioCalificacionesCU
    {
        public bool actualizarComentarioCalificaciones(int idPaquete, string correoUsuario, string comentarios, int calificacion);
    }
}