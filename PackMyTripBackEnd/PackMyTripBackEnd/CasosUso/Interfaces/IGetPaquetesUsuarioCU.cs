using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.CasosUso.Interfaces
{
    public interface IGetPaquetesUsuarioCU
    {
        public List<PaqueteTuristico> getPaquetesTuristicosUsuario(string? correoTurista);
    }
}