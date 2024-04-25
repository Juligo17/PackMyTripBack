using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class EditarComentarioCalificacionCU : IEditarComentarioCalificacionesCU
    {
        IUsuarioRepository usuarioRepository;

        public EditarComentarioCalificacionCU(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public bool actualizarComentarioCalificaciones(int idPaquete, string correoUsuario, string comentarios, int calificacion)
        {
            if (usuarioRepository.actualizarComentariosCalificacion(idPaquete, correoUsuario, comentarios, calificacion))
            {
                return true;
            }
            throw new ApplicationException("No se pudo actualizar las calificaciones y comentarios");
        }
    }
}