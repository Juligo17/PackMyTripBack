using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class GetServiciosPaqueteCU : IGetServiciosPaqueteCU
    {
        private readonly IPaqueteTuristicoRepository paqueteTuristicoRepository;

        public GetServiciosPaqueteCU(IPaqueteTuristicoRepository paqueteTuristicoRepository)
        {
            this.paqueteTuristicoRepository = paqueteTuristicoRepository;
        }

        public List<Servicio> getServiciosPaquete(int idPaquete)
        {
            List<Servicio> servicios = paqueteTuristicoRepository.getServiciosPaquete(idPaquete);

            if (servicios.Count > 0)
            {
                return servicios;
            }
            throw new ApplicationException("No existen servicios para el paquete turistico");
        }
    }
}