using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class RegistrarUsuarioXPaqueteTuristicoCU : IRegistrarUsuarioXPaqueteTuristicoCU
    {
        IUsuarioXPaqueteTuristicoRepository usuarioXPaqueteTuristicoRepository = null!;

        public RegistrarUsuarioXPaqueteTuristicoCU(IUsuarioXPaqueteTuristicoRepository usuarioXPaqueteTuristicoRepository)
        {
            this.usuarioXPaqueteTuristicoRepository = usuarioXPaqueteTuristicoRepository;
        }
        public bool registrarUsuarioXPaqueteTuristico(UsuarioXPaqueteTuristico usuarioXPaqueteTuristico)
        {
            if (usuarioXPaqueteTuristicoRepository.insertUsuarioXPaqueteTuristico(usuarioXPaqueteTuristico))
            {
                return true;
            }
            throw new ApplicationException($"No se pudo registrar el usuario x paquete turistico.");
        }
    }
}