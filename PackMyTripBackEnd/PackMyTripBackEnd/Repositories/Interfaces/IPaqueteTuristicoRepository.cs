using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Repositories.Interfaces
{
    public interface IPaqueteTuristicoRepository
    {
        public List<PaqueteTuristico> getPaquetesTuristicos();
        public PaqueteTuristico getPaqueteTuristico(int id);
        public List<PaqueteTuristico> getPaquetesTuristicosPorIntermediario(string? correoIntermediario);
        public bool insertPaqueteTuristico(PaqueteTuristico paqueteTuristico);
        public bool updatePaqueteTuristico(PaqueteTuristico paqueteTuristico);
    }
}