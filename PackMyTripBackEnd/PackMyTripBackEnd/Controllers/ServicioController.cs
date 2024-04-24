using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PackMyTripBackEnd.CasosUso.Implementaciones;
using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Controllers
{
    [ApiController]
    [Produces("application/json")] //Decimos que este controlador produce un formato .json
    [Route("api/[controller]")] //Define la URL que va a tener el controlador (en este caso api/controller)
    public class ServicioController : ControllerBase
    {
        private IVerServiciosCU verServiciosCU = null!;
        private IRegistrarServicioCU registrarServicioCU = null!;
        private IEditarServicioCU editarServicioCU = null!;
        private IVerMetricasCU verMetricasCU = null!;

        public ServicioController(IVerServiciosCU verServiciosCU, IRegistrarServicioCU registrarServicioCU, 
                                  IEditarServicioCU editarServicioCU, IVerMetricasCU verMetricasCU)
        {
            this.verServiciosCU = verServiciosCU;
            this.registrarServicioCU = registrarServicioCU;
            this.editarServicioCU = editarServicioCU;
            this.verMetricasCU = verMetricasCU;
        }

        [HttpGet] //Indica que es un GET
        public IActionResult getServicios(string? correoOperador)
        {
            try
            {
                var resultado = verServiciosCU.getServicios(correoOperador);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("metricas")] //Indica que es un GET
        public IActionResult getServiciosMetricas(string? correoOperador)
        {
            try
            {
                var resultado = verMetricasCU.obtenerMetricas(correoOperador);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost] //Indica que es un POST
        public IActionResult crearServicio(Servicio servicio)
        {
            try
            {
                var resultado = registrarServicioCU.registrarServicio(servicio);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut] //Indica que es un PUT
        public IActionResult editarServicio(Servicio servicio)
        {
            try
            {
                var resultado = editarServicioCU.editarServicio(servicio);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
