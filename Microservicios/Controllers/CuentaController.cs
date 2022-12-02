using Microservicios_bl;
using Microservicios_common.Common;
using Microservicios_dal;
using Microsoft.AspNetCore.Mvc;

namespace PruebaMicroservicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaBl _cuentaBl;

        public CuentaController(ICuentaBl cuentaBl)
        {
            _cuentaBl = cuentaBl;
        }

        [HttpGet]
        public IActionResult GetCuentas()
        {
            ResponseQuery<List<CuentaDto>> response = new ResponseQuery<List<CuentaDto>>();
            _cuentaBl.GetCuentas(response);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetCuentaId(int id)
        {
            ResponseQuery<List<CuentaDto>> response = new ResponseQuery<List<CuentaDto>>();
            _cuentaBl.GetCuentaId(id, response);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult PostCuenta(CuentaDto cuenta)
        {
            ResponseQuery<List<CuentaDto>> response = new ResponseQuery<List<CuentaDto>>();
            _cuentaBl.CreateCuenta(cuenta, response);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult PutCuenta(int id, CuentaDto cuenta)
        {
            ResponseQuery<List<CuentaDto>> response = new ResponseQuery<List<CuentaDto>>();
            _cuentaBl.UpdateCuenta(id, cuenta, response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCuenta(int id)
        {
            ResponseQuery<List<CuentaDto>> response = new ResponseQuery<List<CuentaDto>>();
            _cuentaBl.DeleteCuenta(id, response);
            return Ok(response);
        }
    }
}