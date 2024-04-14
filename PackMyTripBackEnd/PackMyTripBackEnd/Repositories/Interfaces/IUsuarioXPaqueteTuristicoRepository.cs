using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Repositories.Interfaces
{
    public interface IUsuarioXPaqueteTuristicoRepository
    {
        public UsuarioXPaqueteTuristico getUsuarioXPaqueteTuristico(int id);
        public List<UsuarioXPaqueteTuristico> getUsuariosXPaqueteTuristicoPorCorreo(string? correoUsuario);
        public bool insertUsuarioXPaqueteTuristico(UsuarioXPaqueteTuristico usuarioXPaqueteTuristico);
        public bool updateUsuarioXPaqueteTuristico(UsuarioXPaqueteTuristico usuarioXPaqueteTuristico);
    }
}