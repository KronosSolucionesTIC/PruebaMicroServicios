using Microservicios_bl;
using Microservicios_common.Common;
using Microservicios_dal;
using Microsoft.AspNetCore.Mvc;

namespace PruebaMicroservicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoBl _movimientoBl;

        public MovimientoController(IMovimientoBl movimientoBl)
        {
            _movimientoBl = movimientoBl;
        }

        [HttpGet]
        public IActionResult GetMovimientos()
        {
            ResponseQuery<List<MovimientoDto>> response = new ResponseQuery<List<MovimientoDto>>();
            _movimientoBl.GetMovimientos(response);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovimientoId(int id)
        {
            ResponseQuery<List<MovimientoDto>> response = new ResponseQuery<List<MovimientoDto>>();
            _movimientoBl.GetMovimientoId(id, response);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult PostMovimiento(MovimientoDto movimiento)
        {
            ResponseQuery<List<MovimientoDto>> response = new ResponseQuery<List<MovimientoDto>>();
            _movimientoBl.CreateMovimiento(movimiento, response);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult PutMovimiento(MovimientoDto movimiento)
        {
            ResponseQuery<List<MovimientoDto>> response = new ResponseQuery<List<MovimientoDto>>();
            _movimientoBl.UpdateMovimiento(movimiento, response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovimiento(int id)
        {
            ResponseQuery<List<MovimientoDto>> response = new ResponseQuery<List<MovimientoDto>>();
            _movimientoBl.DeleteMovimiento(id, response);
            return Ok(response);
        }
    }
}