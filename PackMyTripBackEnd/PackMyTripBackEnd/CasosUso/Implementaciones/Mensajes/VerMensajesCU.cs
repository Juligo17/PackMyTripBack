using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class VerMensajesCU : IVerMensajesCU
    {
        private readonly IMensajeRepository mensajeRepository;
        public VerMensajesCU(IMensajeRepository mensajeRepository)
        {
            this.mensajeRepository = mensajeRepository;
        }
        public Mensaje verMensaje(int id)
        {
            Mensaje mensaje = mensajeRepository.getMensaje(id);
            if (mensaje == null)
            {
                throw new System.Exception("Mensaje no encontrado");
            }
            return mensaje;
        }

        public List<Mensaje> verMensajesEntreUsuarios(string? correoUsuario1, string? correoUsuario2)
        {
            List<Mensaje> mensajes = mensajeRepository.getMensajesEntreUsuarios(correoUsuario1, correoUsuario2);
            if (mensajes == null)
            {
                throw new System.Exception("Mensajes no encontrados");
            }
            return mensajes;
        }

        public List<Mensaje> verMensajesEnviadosPorUsuarioEntreDos(string? correoUsuario1, string? correoUsuario2)
        {
            List<Mensaje> mensajes = mensajeRepository.getMensajesEnviadosPorUsuarioEntreDos(correoUsuario1, correoUsuario2);
            if (mensajes == null)
            {
                throw new System.Exception("Mensajes no encontrados");
            }
            return mensajes;
        }
    }

}