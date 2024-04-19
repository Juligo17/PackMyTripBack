using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.CasosUso.Interfaces
{
    public interface ICrearPerfilesCU
    {
        Usuario getUsuario(string usuario, string contrasenha);
        bool crearUsuario(Usuario usuario);
    }
}
