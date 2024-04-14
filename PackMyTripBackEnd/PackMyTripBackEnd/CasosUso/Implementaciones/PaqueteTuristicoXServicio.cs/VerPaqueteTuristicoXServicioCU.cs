using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class VerPaqueteTuristicoXServicioCU : IVerPaqueteTuristicoXServicioCU
    {
        private readonly IPaqueteTuristicoXServicioRepository paqueteTuristicoXServicioRepository;

        public VerPaqueteTuristicoXServicioCU(IPaqueteTuristicoXServicioRepository paqueteTuristicoXServicioRepository)
        {
            this.paqueteTuristicoXServicioRepository = paqueteTuristicoXServicioRepository;
        }
        public List<PaqueteTuristicoXServicio> verPaquetesTuristicosXServicioPorPaquete(int idPaquete)
        {
            List<PaqueteTuristicoXServicio> paquetes = paqueteTuristicoXServicioRepository.getPaquetesTuristicosXServicioPorPaquete(idPaquete);
            if (paquetes.Count > 0)
            {
                return paquetes;
            }
            throw new ApplicationException("No existen paquetes turisticos por servicio.");
        }

        public PaqueteTuristicoXServicio verPaqueteTuristicoXServicio(int id)
        {
            PaqueteTuristicoXServicio paquete = paqueteTuristicoXServicioRepository.getPaqueteTuristicoXServicio(id);
            if (paquete != null)
            {
                return paquete;
            }
            throw new ApplicationException($"No existe un paquete turistico por servicio con el id {id}.");
        }
    }
}