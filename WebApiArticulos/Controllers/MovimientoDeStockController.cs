using Domain.Dtos;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsesCases;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoDeStockController : Controller
    {
        private IServicioMovimientoDeStock _service;
        public MovimientoDeStockController(IServicioMovimientoDeStock service)
        {
            _service = service;
        }
        
        [Authorize]
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult Post([FromBody] MovimientoDeStockDto movimientoDto)
        {
            try
            {
                MovimientoDeStockDto movimientoDtoCreated = _service.Add(movimientoDto);
                return Ok(movimientoDtoCreated);
            }
            catch (ElementoInvalidoException exception)
            {
                return StatusCode(StatusCodes.Status409Conflict, exception.Message);
            }
            catch (ElementoNoExisteException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("articulos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetArticulos([FromQuery] DateTime fechaInicio, DateTime fechaFin, int skip = 0, int take = 5)
        {
            ArticuloResponseDto articulos = _service.GetArticuloConMovimientosEnRangoDeFechas(fechaInicio,fechaFin, skip, take);
            return Ok(articulos);
        }

        [Authorize]
        [HttpGet("movimientos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetMovimientos([FromQuery] int articuloId, int tipoDeMovimientoId, int skip = 0, int take = 5)
        {
            MovimientoDeStockResponseDto movimientos = _service.GetMovimientosPorArticuloYTipo(articuloId, tipoDeMovimientoId, skip, take);
            return Ok(movimientos);
        }

        [Authorize]
        [HttpGet("resumen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetResumen()
        {
            ResumenResponseDto resumen = _service.GetResumenMovimientos();
            return Ok(resumen);
        }

    }
}
