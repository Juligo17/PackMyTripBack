using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.CasosUso.Interfaces
{
    public interface IVerServiciosCU
    {
        List<Servicio> getServicios(string? correoOperador);
    }
}
