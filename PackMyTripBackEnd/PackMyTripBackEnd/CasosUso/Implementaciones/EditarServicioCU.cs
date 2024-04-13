using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class EditarServicioCU : IEditarServicioCU
    {
        IServicioRepository servicioRepository = null!;

        public EditarServicioCU(IServicioRepository servicioRepository)
        {
            this.servicioRepository = servicioRepository;
        }

        public bool editarServicio(Servicio servicio)
        {
            if (servicioRepository.updateServicio(servicio))
            {
                return true;
            }
            throw new ApplicationException($"No se pudo editar el servicio.");
        }
    }
}
