using Microservicios_common.Common;
using Microservicios_dal;

namespace Microservicios_bl
{
    public class ClienteBl : IClienteBl
    {
        private readonly IClienteDal _clienteDal;
        public ClienteBl(IClienteDal clienteDal)
        {
            _clienteDal = clienteDal;
        }

        public ResponseQuery<List<ClienteDto>> CreateCliente(ClienteDto cliente, ResponseQuery<List<ClienteDto>> response)
        {
            try
            {
                response.ObjetoResultado = _clienteDal.CreateCliente(cliente);
                response.Exitoso = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.CodigoResultado = null;
                response.Exitoso = false;
            }
            return response;
        }

        public ResponseQuery<List<ClienteDto>> GetClienteId(int id, ResponseQuery<List<ClienteDto>> response)
        {
            try
            {
                response.ObjetoResultado = _clienteDal.GetClienteId(id);
                response.Exitoso = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.CodigoResultado = null;
                response.Exitoso = false;
            }
            return response;
        }

        public ResponseQuery<List<ClienteDto>> GetClientes(ResponseQuery<List<ClienteDto>> response)
        {
            try
            {
                response.ObjetoResultado = _clienteDal.GetClientes();
                response.Exitoso = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.CodigoResultado = null;
                response.Exitoso = false;
            }
            return response;
        }

        public ResponseQuery<List<ClienteDto>> UpdateCliente(int id, ClienteDto cliente, ResponseQuery<List<ClienteDto>> response)
        {
            try
            {
                response.ObjetoResultado = _clienteDal.UpdateCliente(id, cliente);
                response.Exitoso = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.CodigoResultado = null;
                response.Exitoso = false;
            }
            return response;
        }

        public ResponseQuery<List<ClienteDto>> DeleteCliente(int id, ResponseQuery<List<ClienteDto>> response)
        {
            try
            {
                response.ObjetoResultado = _clienteDal.DeleteCliente(id);
                response.Exitoso = true;
            }
            catch (Exception e)
            {
                response.Mensaje = e.Message;
                response.CodigoResultado = null;
                response.Exitoso = false;
            }
            return response;
        }
    }
}
