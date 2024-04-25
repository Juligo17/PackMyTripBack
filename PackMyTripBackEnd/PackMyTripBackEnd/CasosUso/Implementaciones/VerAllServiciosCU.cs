using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class VerAllServiciosCU : IVerAllServiciosCU
    {
        IServicioRepository servicioRepository;

        public VerAllServiciosCU (IServicioRepository servicioRepository)
        {
            this.servicioRepository = servicioRepository;
        }

        public List<Servicio> verAllServicios()
        {
            List<Servicio> servicios = servicioRepository.getAllServicios();
            if (servicios.Count > 0)
            {
                return servicios;
            }
            throw new ApplicationException("No existen servicios.");
        }
    }
}