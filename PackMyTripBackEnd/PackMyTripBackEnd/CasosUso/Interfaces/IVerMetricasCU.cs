using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.CasosUso.Interfaces
{
    public interface IVerMetricasCU
    {
        public List<Servicio> obtenerMetricas(string? correoOperador);
    }
}
