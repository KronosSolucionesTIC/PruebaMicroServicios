using Microservicios_bl;
using Microservicios_common.Common;
using Microservicios_dal;
using Microsoft.AspNetCore.Mvc;

namespace PruebaMicroservicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IMovimientoBl _reporteBl;

        public ReporteController(IMovimientoBl reporteBl)
        {
            _reporteBl = reporteBl;
        }

        [HttpGet("{fecha}")]
        public IActionResult GetReporteFecha(string fecha, string cliente)
        {
            ResponseQuery<List<MovimientoDto>> response = new ResponseQuery<List<MovimientoDto>>();
            _reporteBl.GetReporteFecha(fecha, cliente, response);
            return Ok(response);
        }
    }
}