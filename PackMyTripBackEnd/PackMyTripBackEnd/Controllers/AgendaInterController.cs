using Microsoft.AspNetCore.Mvc;
using PackMyTripBackEnd.CasosUso.Interfaces;

namespace PackMyTripBackEnd.Controllers
{
    [ApiController]
    [Produces("application/json")] //Decimos que este controlador produce un formato .json
    [Route("api/[controller]")]

    public class AgendaInterController : ControllerBase
    {
        private IGetAgendaCU getAgendaCU;

        public AgendaInterController(IGetAgendaCU getAgendaCU)
        {
            this.getAgendaCU = getAgendaCU;
        }

        [HttpGet()]
        public IActionResult getAgendaInter (string? correoInter)
        {
            try
            {
                var resultado = getAgendaCU.getAgendaInter(correoInter);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}