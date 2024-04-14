using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;
using PackMyTripBackEnd.CasosUso.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class RegistrarPaqueteTuristicoXServicioCU : IRegistrarPaqueteTuristicoXServicioCU
    {
        IPaqueteTuristicoXServicioRepository paqueteTuristicoXServicioRepository = null!;

        public RegistrarPaqueteTuristicoXServicioCU(IPaqueteTuristicoXServicioRepository paqueteTuristicoXServicioRepository)
        {
            this.paqueteTuristicoXServicioRepository = paqueteTuristicoXServicioRepository;
        }
        public bool registrarPaqueteTuristicoXServicio(PaqueteTuristicoXServicio paqueteTuristicoXServicio)
        {
            if (paqueteTuristicoXServicioRepository.insertPaqueteTuristicoXServicio(paqueteTuristicoXServicio))
            {
                return true;
            }
            throw new ApplicationException($"No se pudo registrar el paquete turistico por servicio.");
        }
    }
}