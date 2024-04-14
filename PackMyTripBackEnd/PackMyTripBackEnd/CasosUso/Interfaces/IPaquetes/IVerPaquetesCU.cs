using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.CasosUso.Interfaces
{
    public interface IVerPaquetesTuristicosCU
    {
        public List<PaqueteTuristico> verPaquetesTuristicos();
        public PaqueteTuristico verPaqueteTuristico(int id);
        public List<PaqueteTuristico> verPaquetesTuristicosPorIntermediario(string? correoIntermediario);
    }
}