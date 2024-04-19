using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class CrearPerfilesCU : ICrearPerfilesCU
    {
        private IUsuarioRepository usuarioRepository;

        public CrearPerfilesCU(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public bool crearUsuario(Usuario usuario)
        {
            if (usuarioRepository.crearUsuario(usuario))
            {
                return true;
            }
            throw new ApplicationException("No se pudo crear el usuario");
        }

        public Usuario getUsuario(string usuario, string contrasenha)
        {
            return usuarioRepository.getUsuario(usuario, contrasenha);
        }
    }
}
