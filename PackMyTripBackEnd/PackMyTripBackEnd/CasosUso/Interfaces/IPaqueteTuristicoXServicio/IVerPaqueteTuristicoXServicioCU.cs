using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.CasosUso.Interfaces
{
    public interface IVerPaqueteTuristicoXServicioCU
    {
        public PaqueteTuristicoXServicio verPaqueteTuristicoXServicio(int id);
        public List<PaqueteTuristicoXServicio> verPaquetesTuristicosXServicioPorPaquete(int idPaquete);
    }
}