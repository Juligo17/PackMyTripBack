using Microsoft.AspNetCore.Mvc;
using PackMyTripBackEnd.CasosUso.Interfaces;

namespace PackMyTripBackEnd.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class RegistrarPaqueteUsuarioController : Controller
    {
        private IRegistrarPaqueteUsuarioCU registrarPaqueteUsuarioCU;

        public RegistrarPaqueteUsuarioController(IRegistrarPaqueteUsuarioCU registrarPaqueteUsuarioCU)
        {
            this.registrarPaqueteUsuarioCU = registrarPaqueteUsuarioCU;
        }

        [HttpPost()]
        public IActionResult registrarPaqueteUsuario (string correoUsuario, int idPaquete)
        {
            try
            {
                var resultado = registrarPaqueteUsuarioCU.registrarPaqueteUsuario(correoUsuario, idPaquete);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}