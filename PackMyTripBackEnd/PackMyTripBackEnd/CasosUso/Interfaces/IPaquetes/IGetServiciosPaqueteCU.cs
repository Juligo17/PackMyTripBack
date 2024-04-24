using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.CasosUso.Interfaces
{
    public interface IGetServiciosPaqueteCU
    {
        public List<Servicio> getServiciosPaquete(int idPaquete);
    }
}