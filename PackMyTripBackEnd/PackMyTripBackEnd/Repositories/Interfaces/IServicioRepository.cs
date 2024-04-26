using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Repositories.Interfaces
{
    public interface IServicioRepository
    {
        public List<Servicio> getServicios(string? correoOperador);
        public bool insertServicio(Servicio servicio);
        public bool updateServicio(Servicio servicio);
        public List<Servicio> getServiciosMetricas(string? correoOperador);
        public List<Servicio> getAllServicios();
        public Servicio getServicio(int? id);
    }
}
