using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class VerUsuariosXPaqueteTuristicoCU : IVerUsuariosXPaqueteTuristicoCU
    {
        IUsuarioXPaqueteTuristicoRepository usuarioXPaqueteTuristicoRepository = null!;

        public List<UsuarioXPaqueteTuristico> verUsuariosXPaqueteTuristicoPorCorreo(string? correoUsuario)
        {
            List<UsuarioXPaqueteTuristico> usuariosXPaqueteTuristico = usuarioXPaqueteTuristicoRepository.getUsuariosXPaqueteTuristicoPorCorreo(correoUsuario);
            if (usuariosXPaqueteTuristico.Count > 0)
            {
                return usuariosXPaqueteTuristico;
            }
            throw new Exception("No se encontraron usuarios con el correo proporcionado");
        }

        public UsuarioXPaqueteTuristico verUsuarioXPaqueteTuristico(int id)
        {
            UsuarioXPaqueteTuristico usuarioXPaqueteTuristico = usuarioXPaqueteTuristicoRepository.getUsuarioXPaqueteTuristico(id);
            if (usuarioXPaqueteTuristico != null)
            {
                return usuarioXPaqueteTuristico;
            }
            throw new Exception("No se encontró un usuario con el id proporcionado");
        }
    }
}