using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.CasosUso.Interfaces
{
    public interface IVerUsuariosXPaqueteTuristico
    {
        public List<UsuarioXPaqueteTuristico> verUsuariosXPaqueteTuristicoPorCorreo(string? correoUsuario);
        public UsuarioXPaqueteTuristico verUsuarioXPaqueteTuristico(int id);
    }
}