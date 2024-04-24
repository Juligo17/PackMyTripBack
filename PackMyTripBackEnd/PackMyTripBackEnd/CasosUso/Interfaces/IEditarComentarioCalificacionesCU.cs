using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.CasosUso.Interfaces
{
    public interface IEditarComentarioCalificacionesCU
    {
        bool actualizarComentarioCalificaciones(int idPaquete, string? correoUsuario, string? comentarios, int? calificacion);
    }
}