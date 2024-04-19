using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class SeleccionarRegionCU : ISeleccionarRegionCU
    {
        private IUsuarioRepository usuarioRepository;

        public SeleccionarRegionCU(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public bool actualizarRegion(Usuario usuario)
        {
            if(usuarioRepository.actualizarRegion(usuario))
            {
                return true;
            }
            throw new ApplicationException("No se pudo actualizar la region");
        }
    }
}
