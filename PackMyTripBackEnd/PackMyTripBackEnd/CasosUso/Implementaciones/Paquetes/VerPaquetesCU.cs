using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class VerPaquetesCU : IVerPaquetesCU
    {
        private readonly IPaqueteTuristicoRepository paqueteTuristicoRepository;

        public VerPaquetesCU(IPaqueteTuristicoRepository paqueteTuristicoRepository)
        {
            this.paqueteTuristicoRepository = paqueteTuristicoRepository;
        }
        
        public List<PaqueteTuristico> verPaquetesTuristicos()
        {
            List<PaqueteTuristico> paquetes = paqueteTuristicoRepository.getPaquetesTuristicos();
            if (paquetes.Count > 0)
            {
                return paquetes;
            }
            throw new ApplicationException("No existen paquetes turisticos.");
        }

        public List<PaqueteTuristico> verPaquetesTuristicosPorIntermediario(string? correoIntermediario)
        {
            List<PaqueteTuristico> paquetes = paqueteTuristicoRepository.getPaquetesTuristicosPorIntermediario(correoIntermediario);
            if (paquetes.Count > 0)
            {
                return paquetes;
            }
            throw new ApplicationException($"No existen paquetes turisticos con el correo {correoIntermediario}.");
        }

        public PaqueteTuristico verPaqueteTuristico(int id)
        {
            PaqueteTuristico paquete = paqueteTuristicoRepository.getPaqueteTuristico(id);
            if (paquete != null)
            {
                return paquete;
            }
            throw new ApplicationException($"No existe un paquete turistico con el id {id}.");
        }
    }
}