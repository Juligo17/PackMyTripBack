using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class EditarPaqueteCU : IEditarPaquetesCU
    {
        IPaqueteTuristicoRepository paqueteRepository = null!;

        public EditarPaqueteCU(IPaqueteTuristicoRepository paqueteRepository)
        {
            this.paqueteRepository = paqueteRepository;
        }

        public bool editarPaqueteTuristico(PaqueteTuristico paqueteTuristico)
        {
            if (paqueteRepository.updatePaqueteTuristico(paqueteTuristico))
            {
                return true;
            }
            throw new ApplicationException($"No se pudo editar el paquete turistico.");
        }
    }
}