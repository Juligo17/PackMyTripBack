using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.CasosUso.Interfaces
{
    public interface IGetAgendaCU
    {
        List<PaqueteTuristico> getAgendaInter(string? correoInter);
    }
}