using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.CasosUso.Interfaces
{
    public interface IVerUsuariosXPaqueteTuristicoCU
    {
        public List<UsuarioXPaqueteTuristico> verUsuariosXPaqueteTuristicoPorCorreo(string? correoUsuario);
        public UsuarioXPaqueteTuristico verUsuarioXPaqueteTuristico(int id);
    }
}