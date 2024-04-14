using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class EditarPaqueteTuristicoXServicioCU : IEditarPaqueteTuristicoXServicioCU
    {
        IPaqueteTuristicoXServicioRepository paqueteTuristicoXServicioRepository = null!;

        public EditarPaqueteTuristicoXServicioCU(IPaqueteTuristicoXServicioRepository paqueteTuristicoXServicioRepository)
        {
            this.paqueteTuristicoXServicioRepository = paqueteTuristicoXServicioRepository;
        }

        public bool editarPaqueteTuristicoXServicio(PaqueteTuristicoXServicio paqueteTuristicoXServicio)
        {
            if (paqueteTuristicoXServicioRepository.updatePaqueteTuristicoXServicio(paqueteTuristicoXServicio))
            {
                return true;
            }
            throw new ApplicationException($"No se pudo editar el paquete turistico por servicio.");
        }
    }
}