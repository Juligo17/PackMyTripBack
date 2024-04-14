using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class EditarUsuarioXPaqueteTuristicoCU : IEditarUsuarioXPaqueteTuristicoCU
    {
        IUsuarioXPaqueteTuristicoRepository usuarioXPaqueteTuristicoRepository = null!;

        public EditarUsuarioXPaqueteTuristicoCU(IUsuarioXPaqueteTuristicoRepository usuarioXPaqueteTuristicoRepository)
        {
            this.usuarioXPaqueteTuristicoRepository = usuarioXPaqueteTuristicoRepository;
        }

        public bool editarUsuarioXPaqueteTuristico(UsuarioXPaqueteTuristico usuarioXPaqueteTuristico)
        {
            if (usuarioXPaqueteTuristicoRepository.updateUsuarioXPaqueteTuristico(usuarioXPaqueteTuristico))
            {
                return true;
            }
            throw new ApplicationException($"No se pudo editar el usuario x paquete turistico.");
        }
    }
}