using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class VerServiciosCU : IVerServiciosCU
    {
        IServicioRepository servicioRepository = null!;

        public VerServiciosCU(IServicioRepository servicioRepository)
        {
            this.servicioRepository = servicioRepository;  
        }

        public List<Servicio> getServicios(string? correoOperador)
        {
            List<Servicio> servicios = servicioRepository.getServicios(correoOperador);
            if(servicios.Count == 0)
            {
                throw new ApplicationException($"No existen usuarios con servicios con el correo {correoOperador}.");
            }
            return servicios;
        }
    }
}
