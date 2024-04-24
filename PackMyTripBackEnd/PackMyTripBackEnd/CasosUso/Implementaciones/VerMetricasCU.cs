using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;
using System.Reflection.Metadata;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class VerMetricasCU : IVerMetricasCU
    {
        IServicioRepository servicioRepository = null!;
        public VerMetricasCU(IServicioRepository servicioRepository)
        {
            this.servicioRepository = servicioRepository;
        }

        public List<Servicio> obtenerMetricas(string? correoOperador)
        {
            var result = servicioRepository.getServiciosMetricas(correoOperador);
            if (result != null)
            {
                return result;
            }
            throw new ApplicationException($"No se pudo obtener las metricas de servicio.");
        }
    }
}
