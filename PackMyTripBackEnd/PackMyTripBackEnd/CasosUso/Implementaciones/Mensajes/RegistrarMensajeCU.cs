using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class RegistrarMensajeCU : IRegistrarMensajeCU
    {
        IMensajeRepository mensajeRepository = null!;

        public RegistrarMensajeCU(IMensajeRepository mensajeRepository)
        {
            this.mensajeRepository = mensajeRepository;
        }

        public bool registrarMensaje(Mensaje mensaje)
        {
            if (mensajeRepository.insertMensaje(mensaje))
            {
                return true;
            }
            throw new ApplicationException($"No se pudo registrar el mensaje.");
        }
    }
}