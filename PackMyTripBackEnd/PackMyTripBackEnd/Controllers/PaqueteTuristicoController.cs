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

    public class PaqueteTuristicoController : ControllerBase
    {
        
    }
}