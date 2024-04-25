using Microsoft.AspNetCore.Mvc;
using PackMyTripBackEnd.CasosUso.Interfaces;

namespace PackMyTripBackEnd.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class UsuarioGetPaqueteController : Controller
    {
        private IGetPaquetesUsuarioCU getPaquetesTuristaCU;

        public UsuarioGetPaqueteController (IGetPaquetesUsuarioCU getPaquetesTuristaCU)
        {
            this.getPaquetesTuristaCU = getPaquetesTuristaCU;
        }

        [HttpGet]
        public IActionResult getPaquetesTurista(string? correoUsuario)
        {
            try
            {
                var resultado = getPaquetesTuristaCU.getPaquetesTuristicosUsuario(correoUsuario);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}