using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.CasosUso.Interfaces
{
    public interface IVerMensajesCU
    {
        public Mensaje verMensaje(int id);
        public List<Mensaje> verMensajesEntreUsuarios(string? correoUsuario1, string? correoUsuario2);
        public List<Mensaje> verMensajesEnviadosPorUsuarioEntreDos(string? correoUsuario1, string? correoUsuario2);
    }
}