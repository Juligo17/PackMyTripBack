using Microsoft.AspNetCore.Mvc;
using PackMyTripBackEnd.CasosUso.Interfaces;

namespace PackMyTripBackEnd.Controllers
{
    [ApiController]
    [Produces("application/json")] 
    [Route("api/[controller]")] 

    public class ServicioGetAllController : Controller
    {
        private IVerAllServiciosCU verAllServiciosCU;

        public ServicioGetAllController(IVerAllServiciosCU verAllServiciosCU)
        {
            this.verAllServiciosCU = verAllServiciosCU;
        }

        [HttpGet]
        public IActionResult getAllServicios ()
        {
            try
            {
                var resultado = verAllServiciosCU.verAllServicios();
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}