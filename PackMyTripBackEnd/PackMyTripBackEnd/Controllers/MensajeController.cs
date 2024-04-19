using Microsoft.AspNetCore.Mvc;
using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Controllers
{
    [ApiController]
    [Produces("application/json")] //Decimos que este controlador produce un formato .json
    [Route("api/[controller]")] //Define la URL que va a tener el controlador (en este caso api/controller)

    public class MensajeController : ControllerBase
    {
        private IRegistrarMensajeCU registrarMensajeCU = null!;
        private IVerMensajesCU verMensajesCU = null!;

        public MensajeController(IRegistrarMensajeCU registrarMensajeCU, IVerMensajesCU verMensajesCU)
        {
            this.registrarMensajeCU = registrarMensajeCU;
            this.verMensajesCU = verMensajesCU;
        }

        [HttpGet("{id}")] //Indica que es un GET con un parámetro
        public IActionResult getMensaje(int id)
        {
            try
            {
                var resultado = verMensajesCU.verMensaje(id);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/me/{correoUsuario1}/{correoUsuario2}")]
        public IActionResult getMensajesEntreUsuarios(string? correoUsuario1, string? correoUsuario2)
        {
            try
            {
                var resultado = verMensajesCU.verMensajesEntreUsuarios(correoUsuario1, correoUsuario2);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{correoUsuario1}/{correoUsuario2}")]
        public IActionResult getMensajesEnviadosPorUsuarioEntreDos(string? correoUsuario1, string? correoUsuario2)
        {
            try
            {
                var resultado = verMensajesCU.verMensajesEnviadosPorUsuarioEntreDos(correoUsuario1, correoUsuario2);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost] //Indica que es un POST
        public IActionResult postMensaje(Mensaje mensaje)
        {
            try
            {
                if (registrarMensajeCU.registrarMensaje(mensaje))
                {
                    return Ok("Mensaje registrado correctamente.");
                }
                return BadRequest("No se pudo registrar el mensaje.");
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}