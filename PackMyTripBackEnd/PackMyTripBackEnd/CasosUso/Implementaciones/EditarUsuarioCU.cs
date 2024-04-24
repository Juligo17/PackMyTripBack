using K4os.Hash.xxHash;
using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class EditarUsuarioCU : IEditarUsuarioCU
    {
        IUsuarioRepository usuarioRepository;

        public EditarUsuarioCU(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public bool actualizarUsuario(Usuario usuario)
        {
            if (usuarioRepository.actualizarUsuario(usuario))
            {
                return true;
            }
            throw new ApplicationException("No se pudo actualizar el usuario");
        }
    }
}
