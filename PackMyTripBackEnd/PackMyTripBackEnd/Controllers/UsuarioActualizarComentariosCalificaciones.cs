using Microsoft.AspNetCore.Mvc;
using PackMyTripBackEnd.CasosUso.Interfaces;
using PackMyTripBackEnd.Entidades;

namespace PackMyTripBackEnd.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class UsuarioActualizarComentariosCalificacionesController : Controller
    {
        private IEditarComentarioCalificacionesCU editarComentarioCalificacionesCU;

        public UsuarioActualizarComentariosCalificacionesController(IEditarComentarioCalificacionesCU editarComentarioCalificacionesCU)
        {
            this.editarComentarioCalificacionesCU = editarComentarioCalificacionesCU;
        }

        [HttpPut()]
        public IActionResult editarComentariosCalificacion(int idPaquete, string? correoUsuario, string? comentarios, int calificacion)
        {
            try
            {
                var resultado = editarComentarioCalificacionesCU.actualizarComentarioCalificaciones(idPaquete, correoUsuario, comentarios, calificacion);
                return Ok(resultado); // Devuelve una respuesta HTTP 200 OK con el resultado
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message); // Devuelve una respuesta HTTP 400 Bad Request con el mensaje de error
            }
        }
    }
}