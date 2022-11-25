using Microservicios_common.Common;
using Microservicios_dal;
using Microsoft.EntityFrameworkCore;

namespace Microservicios_bl
{
    public interface IClienteBl
    {
        public ResponseQuery<List<ClienteDto>> GetClientes(ResponseQuery<List<ClienteDto>> response);

        public ResponseQuery<List<ClienteDto>> GetClienteId(int id, ResponseQuery<List<ClienteDto>> response);

        public ResponseQuery<List<ClienteDto>> CreateCliente(ClienteDto cliente, ResponseQuery<List<ClienteDto>> response);
        
        public ResponseQuery<List<ClienteDto>> UpdateCliente(int id, ClienteDto cliente, ResponseQuery<List<ClienteDto>> response);

        public ResponseQuery<List<ClienteDto>> DeleteCliente(int id, ResponseQuery<List<ClienteDto>> response);
    }
}
