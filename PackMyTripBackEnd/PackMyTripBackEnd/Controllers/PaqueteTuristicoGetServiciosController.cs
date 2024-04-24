using Microsoft.AspNetCore.Mvc;
using PackMyTripBackEnd.CasosUso.Interfaces;

namespace PackMyTripBackEnd.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class PaqueteTuristicoGetServiciosController : Controller
    {
        private IGetServiciosPaqueteCU getServiciosPaqueteCU;

        public PaqueteTuristicoGetServiciosController (IGetServiciosPaqueteCU getServiciosPaqueteCU)
        {
            this.getServiciosPaqueteCU = getServiciosPaqueteCU;
        }

        [HttpGet]
        public IActionResult getServiciosPaquete (int idPaquete)
        {
            try
            {
                var resultado = getServiciosPaqueteCU.getServiciosPaquete(idPaquete);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}