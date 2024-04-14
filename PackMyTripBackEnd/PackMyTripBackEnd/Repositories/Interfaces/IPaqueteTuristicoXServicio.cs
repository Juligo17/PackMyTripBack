using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Repositories.Interfaces
{
    public interface IPaqueteTuristicoXServicioRepository
    {
        public PaqueteTuristicoXServicio getPaqueteTuristicoXServicio(int id);
        public List<PaqueteTuristicoXServicio> getPaquetesTuristicosXServicioPorPaquete(int idPaquete);
        public bool insertPaqueteTuristicoXServicio(PaqueteTuristicoXServicio paqueteTuristicoXServicio);
        public bool updatePaqueteTuristicoXServicio(PaqueteTuristicoXServicio paqueteTuristicoXServicio);
    }
}