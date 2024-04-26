using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class RegistrarPaqueteUsuarioCU : IRegistrarPaqueteUsuarioCU
    {
        IUsuarioRepository usuarioRepository;

        public RegistrarPaqueteUsuarioCU(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public bool registrarPaqueteUsuario(string correoUsuario, int idPaquete)
        {
            if (usuarioRepository.registrarPaqueteUsuario(correoUsuario, idPaquete)) return true;
            throw new ApplicationException("No se pudo añadir el paquete al usuario");
        }
    }
}