using Microsoft.AspNetCore.Mvc;
using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Controllers
{
    [ApiController]
    [Produces("application/json")] //Decimos que este controlador produce un formato .json
    [Route("api/[controller]")] //Define la URL que va a tener el controlador (en este caso api/controller)

    public class UsuarioXPaqueteTuristicoController : ControllerBase
    {
        private IVerUsuariosXPaqueteTuristicoCU verUsuariosXPaqueteTuristicoCU = null!;
        private IRegistrarUsuarioXPaqueteTuristicoCU registrarUsuarioXPaqueteTuristicoCU = null!;
        private IEditarUsuarioXPaqueteTuristicoCU editarUsuarioXPaqueteTuristicoCU = null!;

        public UsuarioXPaqueteTuristicoController(IVerUsuariosXPaqueteTuristicoCU verUsuariosXPaqueteTuristicoCU, IRegistrarUsuarioXPaqueteTuristicoCU registrarUsuarioXPaqueteTuristicoCU,
                                          IEditarUsuarioXPaqueteTuristicoCU editarUsuarioXPaqueteTuristicoCU)
        {
            this.verUsuariosXPaqueteTuristicoCU = verUsuariosXPaqueteTuristicoCU;
            this.registrarUsuarioXPaqueteTuristicoCU = registrarUsuarioXPaqueteTuristicoCU;
            this.editarUsuarioXPaqueteTuristicoCU = editarUsuarioXPaqueteTuristicoCU;
        }

        [HttpGet] //Indica que es un GET
        public IActionResult getUsuariosXPaqueteTuristico(string? correoUsuario)
        {
            try
            {
                var resultado = verUsuariosXPaqueteTuristicoCU.verUsuariosXPaqueteTuristicoPorCorreo(correoUsuario);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")] //Indica que es un GET con un parámetro
        public IActionResult getUsuarioXPaqueteTuristico(int id)
        {
            try
            {
                var resultado = verUsuariosXPaqueteTuristicoCU.verUsuarioXPaqueteTuristico(id);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult crearUsuarioXPaqueteTuristico(UsuarioXPaqueteTuristico usuarioXPaqueteTuristico)
        {
            try
            {
                var resultado = registrarUsuarioXPaqueteTuristicoCU.registrarUsuarioXPaqueteTuristico(usuarioXPaqueteTuristico);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult editarUsuarioXPaqueteTuristico(UsuarioXPaqueteTuristico usuarioXPaqueteTuristico)
        {
            try
            {
                var resultado = editarUsuarioXPaqueteTuristicoCU.editarUsuarioXPaqueteTuristico(usuarioXPaqueteTuristico);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}