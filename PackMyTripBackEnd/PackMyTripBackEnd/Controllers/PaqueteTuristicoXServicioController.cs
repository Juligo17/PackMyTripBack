using Microsoft.AspNetCore.Mvc;
using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class PaqueteTuristicoXServicioController : ControllerBase
    {
        private IVerPaqueteTuristicoXServicioCU verPaqueteTuristicoXServicioCU = null!;
        private IRegistrarPaqueteTuristicoXServicioCU registrarPaqueteTuristicoXServicioCU = null!;
        private IEditarPaqueteTuristicoXServicioCU editarPaqueteTuristicoXServicioCU = null!;

        public PaqueteTuristicoXServicioController(IVerPaqueteTuristicoXServicioCU verPaqueteTuristicoXServicioCU, IRegistrarPaqueteTuristicoXServicioCU registrarPaqueteTuristicoXServicioCU,
                                          IEditarPaqueteTuristicoXServicioCU editarPaqueteTuristicoXServicioCU)
        {
            this.verPaqueteTuristicoXServicioCU = verPaqueteTuristicoXServicioCU;
            this.registrarPaqueteTuristicoXServicioCU = registrarPaqueteTuristicoXServicioCU;
            this.editarPaqueteTuristicoXServicioCU = editarPaqueteTuristicoXServicioCU;
        }

        [HttpGet("{id}")]
        public IActionResult getPaqueteTuristicoXServicio(int id)
        {
            try
            {
                var resultado = verPaqueteTuristicoXServicioCU.verPaqueteTuristicoXServicio(id);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{idPaquete}")]
        public IActionResult getPaquetesTuristicosXServicioPorPaquete(int idPaquete)
        {
            try
            {
                var resultado = verPaqueteTuristicoXServicioCU.verPaquetesTuristicosXServicioPorPaquete(idPaquete);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult postPaqueteTuristicoXServicio([FromBody] PaqueteTuristicoXServicio paqueteTuristicoXServicio)
        {
            try
            {
                var resultado = registrarPaqueteTuristicoXServicioCU.registrarPaqueteTuristicoXServicio(paqueteTuristicoXServicio);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult putPaqueteTuristicoXServicio([FromBody] PaqueteTuristicoXServicio paqueteTuristicoXServicio)
        {
            try
            {
                var resultado = editarPaqueteTuristicoXServicioCU.editarPaqueteTuristicoXServicio(paqueteTuristicoXServicio);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}