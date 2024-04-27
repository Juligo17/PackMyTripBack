using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class GetAgendaInterCU : IGetAgendaCU
    {
        private readonly IUsuarioRepository usuarioRepository;

        public GetAgendaInterCU(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public List<PaqueteTuristico> getAgendaInter(string? correoInter)
        {
            List<PaqueteTuristico> paquetes = usuarioRepository.getPaquetesAgenda(correoInter);

            if (paquetes.Count > 0) return paquetes;
            throw new ApplicationException("No existen paquetes turisticos registrados a nombre del inter");

        }
    }
}