using Microservicios_bl;
using Microservicios_common.Common;
using Microservicios_dal;
using Microsoft.AspNetCore.Mvc;

namespace PruebaMicroservicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteBl _clienteBl; 

        public ClienteController(IClienteBl clienteBl)
        {
            _clienteBl = clienteBl;
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            ResponseQuery<List<ClienteDto>> response = new ResponseQuery<List<ClienteDto>>();
            _clienteBl.GetClientes(response);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteId(int id)
        {
            ResponseQuery<List<ClienteDto>> response = new ResponseQuery<List<ClienteDto>>();
            _clienteBl.GetClienteId(id,response);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult PostCliente(ClienteDto cliente)
        {
            ResponseQuery<List<ClienteDto>> response = new ResponseQuery<List<ClienteDto>>();
            _clienteBl.CreateCliente(cliente, response);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult PutCliente(int id, ClienteDto cliente)
        {
            ResponseQuery<List<ClienteDto>> response = new ResponseQuery<List<ClienteDto>>();
            _clienteBl.UpdateCliente(id, cliente, response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            ResponseQuery<List<ClienteDto>> response = new ResponseQuery<List<ClienteDto>>();
            _clienteBl.DeleteCliente(id, response);
            return Ok(response);
        }
    }
}