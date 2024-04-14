using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class RegistrarPaqueteCU : IRegistrarPaqueteCU
    {
        IPaqueteTuristicoRepository paqueteRepository = null!;

        public RegistrarPaqueteCU(IPaqueteTuristicoRepository paqueteRepository)
        {
            this.paqueteRepository = paqueteRepository;
        }

        public bool registrarPaqueteTuristico(PaqueteTuristico paqueteTuristico)
        {
            if (paqueteRepository.insertPaqueteTuristico(paqueteTuristico))
            {
                return true;
            }
            throw new ApplicationException($"No se pudo registrar el paquete turistico.");
        }
    }
}