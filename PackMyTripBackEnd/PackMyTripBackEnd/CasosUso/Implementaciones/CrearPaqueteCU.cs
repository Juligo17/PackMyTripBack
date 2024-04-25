using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class CrearPaqueteCU : ICrearPaqueteCU
    {
        IServicioRepository servicioRepository = null;

        public CrearPaqueteCU(IServicioRepository servicioRepository)
        {
            this.servicioRepository = servicioRepository;
        }

        public List<Servicio> getAllServicios()
        {
            return this.servicioRepository.getAllServicios();
        }
    }
}
