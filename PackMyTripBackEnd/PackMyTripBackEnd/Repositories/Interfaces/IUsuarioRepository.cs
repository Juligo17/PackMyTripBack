using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario getUsuario(string usuario, string contrasenha);
        bool crearUsuario(Usuario usuario);
        bool actualizarRegion(Usuario usuario);
        bool actualizarUsuario(Usuario usuario);
    }
}
