using Domain.Dtos;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private IServicioLogin<LoginDto, LoginOutDto> _service;
        public LoginController(IServicioLogin<LoginDto, LoginOutDto> service)
        {
            _service = service;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Post([FromBody] LoginDto loginDto)
        {
            try
            {
                LoginOutDto usuario = _service.Login(loginDto);
                return Ok(usuario);
            }
            catch (ElementoNoExisteException le)
            {
                return Unauthorized(le.Message);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
