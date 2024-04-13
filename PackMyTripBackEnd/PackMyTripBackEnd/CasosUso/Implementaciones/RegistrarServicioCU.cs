using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class RegistrarServicioCU : IRegistrarServicioCU
    {
        IServicioRepository servicioRepository = null!;

        public RegistrarServicioCU(IServicioRepository servicioRepository)
        {
            this.servicioRepository = servicioRepository;
        }

        public bool registrarServicio(Servicio servicio)
        {
            if (servicioRepository.insertServicio(servicio))
            {
                return true;
            }
            throw new ApplicationException($"No se pudo registrar el servicio.");
        }
    }
}
