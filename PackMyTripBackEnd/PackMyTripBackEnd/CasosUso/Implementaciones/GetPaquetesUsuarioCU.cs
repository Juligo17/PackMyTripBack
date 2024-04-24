using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;
using PackMyTripBackEnd.Repositories.Implementaciones;
using PackMyTripBackEnd.Repositories.Interfaces;

namespace PackMyTripBackEnd.CasosUso.Implementaciones
{
    public class GetPaquetesUsuarioCU : IGetPaquetesUsuarioCU
    {
        private readonly IUsuarioRepository usuarioRepository;

        public GetPaquetesUsuarioCU(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public List<PaqueteTuristico> getPaquetesTuristicosUsuario(string? correoTurista)
        {
            List<PaqueteTuristico> paquetes = usuarioRepository.getPaquetesTuristicosUsuario(correoTurista);

            if (paquetes.Count > 0)
            {
                return paquetes;
            }
            throw new ApplicationException("No existen paquetes turisticos para el usuario");
        }
    }
}