using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Repositories.Interfaces
{
    public interface IMensajeRepository
    {
        public Mensaje getMensaje(int id);
        public List<Mensaje> getMensajesEntreUsuarios(string? correoUsuario1, string? correoUsuario2);
        public List<Mensaje> getMensajesEnviadosPorUsuarioEntreDos(string? correoUsuario1, string? correoUsuario2);
        public bool insertMensaje(Mensaje mensaje);
    }
}