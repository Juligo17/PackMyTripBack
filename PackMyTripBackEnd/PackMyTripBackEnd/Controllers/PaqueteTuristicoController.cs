using Microsoft.AspNetCore.Mvc;
using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Controllers
{
    [ApiController]
    [Produces("application/json")] //Decimos que este controlador produce un formato .json
    [Route("api/[controller]")] //Define la URL que va a tener el controlador (en este caso api/controller)

    public class PaqueteTuristicoController : ControllerBase
    {
        private IVerPaquetesCU verPaquetesTuristicosCU = null!;
        private IRegistrarPaqueteCU registrarPaqueteTuristicoCU = null!;
        private IEditarPaquetesCU editarPaqueteTuristicoCU = null!;

        public PaqueteTuristicoController(IVerPaquetesCU verPaquetesTuristicosCU, IRegistrarPaqueteCU registrarPaqueteTuristicoCU,
                                          IEditarPaquetesCU editarPaqueteTuristicoCU)
        {
            this.verPaquetesTuristicosCU = verPaquetesTuristicosCU;
            this.registrarPaqueteTuristicoCU = registrarPaqueteTuristicoCU;
            this.editarPaqueteTuristicoCU = editarPaqueteTuristicoCU;
        }

        [HttpGet("Lista")] // Get con parametro del correo del intermediario
        public IActionResult getPaquetesTuristicos(string? correoIntermediario)
        {
            try
            {
                var resultado = verPaquetesTuristicosCU.verPaquetesTuristicosPorIntermediario(correoIntermediario);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")] //Indica que es un GET con un parámetro
        public IActionResult getPaqueteTuristico(int id)
        {
            try
            {
                var resultado = verPaquetesTuristicosCU.verPaqueteTuristico(id);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet] //Indica que es un GET
        public IActionResult getPaquetesTuristicos()
        {
            try
            {
                var resultado = verPaquetesTuristicosCU.verPaquetesTuristicos();
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost] //Indica que es un POST
        public IActionResult crearPaqueteTuristico(PaqueteTuristico paqueteTuristico)
        {
            try
            {
                var resultado = registrarPaqueteTuristicoCU.registrarPaqueteTuristico(paqueteTuristico);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut] //Indica que es un PUT
        public IActionResult editarPaqueteTuristico(PaqueteTuristico paqueteTuristico)
        {
            try
            {
                var resultado = editarPaqueteTuristicoCU.editarPaqueteTuristico(paqueteTuristico);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}