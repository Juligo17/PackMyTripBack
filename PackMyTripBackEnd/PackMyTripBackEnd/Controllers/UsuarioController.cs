using Microsoft.AspNetCore.Mvc;
using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Controllers
{
    [ApiController]
    [Produces("application/json")] //Decimos que este controlador produce un formato .json
    [Route("api/[controller]")] //Define la URL que va a tener el controlador (en este caso api/controller)
    public class UsuarioController : Controller
    {
        private ICrearPerfilesCU crearPerfilesCU;
        private ISeleccionarRegionCU seleccionarRegionCU;
        private IEditarUsuarioCU editarUsuarioCU;

        public UsuarioController(ICrearPerfilesCU crearPerfilesCU, 
            ISeleccionarRegionCU seleccionarRegionCU, IEditarUsuarioCU editarUsuarioCU)
        {
            this.crearPerfilesCU = crearPerfilesCU;
            this.seleccionarRegionCU = seleccionarRegionCU;
            this.editarUsuarioCU = editarUsuarioCU;

        }

        [HttpGet] //Indica que es un GET
        public IActionResult getUsuario(string? usuario, string? contrasenha)
        {
            try
            {
                var resultado = crearPerfilesCU.getUsuario(usuario!, contrasenha!);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost] //Indica que es un Post
        public IActionResult crearUsuario(Usuario usuario)
        {
            try
            {
                var resultado = crearPerfilesCU.crearUsuario(usuario);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut] //Indica que es un Put
        public IActionResult actualizarRegion(Usuario usuario)
        {
            try
            {
                var resultado = seleccionarRegionCU.actualizarRegion(usuario);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch] //Indica que es un Patch
        public IActionResult actualizarUsuario(Usuario usuario)
        {
            try
            {
                var resultado = editarUsuarioCU.actualizarUsuario(usuario);
                return Ok(resultado);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
