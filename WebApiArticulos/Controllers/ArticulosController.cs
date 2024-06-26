using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace WebApiArticulos.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : Controller
    {
        private IServicioArticulo _servicioArticulo;

        public ArticulosController(IServicioArticulo servicioArticulo)
        {
            _servicioArticulo = servicioArticulo;
        }
        
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            ArticuloResponseDto articulos = _servicioArticulo.GetAll();
            return Ok(articulos);
        }
    }
}
