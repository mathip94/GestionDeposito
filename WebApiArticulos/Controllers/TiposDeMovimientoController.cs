using Domain.Dtos;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace WebApi.Controllers
{
    [ApiController] //TODAVIA FALTA CHEQUEAR SI ESTAN UTILIZANDO EL MOVIMIENTO PARA NO DEJAR BORRARLO
    [Route("api/[controller]")]
    public class TiposDeMovimientoController : Controller
    {

        private IServicioTipoDeMovimiento _service;

        public TiposDeMovimientoController(IServicioTipoDeMovimiento service)
        {
            _service = service;
        }

        [Authorize] //Authorize es lo que se encarga del token
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get([FromQuery] string? name = "", int skip = 0, int take = 10)
        {
            TipoDeMovimientoResponseDto tipo = _service.GetByName(name, skip, take);
            return Ok(tipo);
        }

        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            try
            {
                TipoDeMovimientoDto tiposDto = _service.Get(id);
                return Ok(tiposDto);
            }
            catch (ElementoNoExisteException exception)
            {
                return NotFound(exception.Message);
            }

        }

        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            
            try
            {
                _service.Remove(id);
                return Ok("Eliminado con exito");
            }
            catch (ElementoNoExisteException exception)
            {
                return NotFound(exception.Message);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Put(int id, [FromBody] TipoDeMovimientoDto tipoDto)
        {
            try
            {
                _service.Update(id, tipoDto);
                return Ok("Modificado con exito");
            }
            catch (ElementoNoExisteException exception)
            {
                return NotFound(exception.Message);
            }
            catch (ElementoInvalidoException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (ElementoEnConflictoException exception) 
            {
                return Conflict(exception.Message);
            }
            catch (InvalidOperationException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [Authorize]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Post([FromBody] TipoDeMovimientoDto tipoDto)
        {
            try
            {
                TipoDeMovimientoDto tipoDtoCreated = _service.Add(tipoDto);
                return Ok(tipoDtoCreated);
            }
            catch (YaExisteElementoException exception) 
            {
                return StatusCode(StatusCodes.Status409Conflict, exception.Message);
            }
            catch (ElementoInvalidoException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [Authorize]
        [HttpGet("todos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            TipoDeMovimientoResponseDto tipo = _service.GetAll();
            return Ok(tipo);
        }

    }
}
