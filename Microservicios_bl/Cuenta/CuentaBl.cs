using Microservicios_common.Common;
using Microservicios_dal;

namespace Microservicios_bl
{
    public class CuentaBl : ICuentaBl
    {
        private readonly ICuentaDal _cuentaDal;
        public CuentaBl(ICuentaDal cuentaDal)
        {
            _cuentaDal = cuentaDal;
        }

        public ResponseQuery<List<CuentaDto>> CreateCuenta(CuentaDto cuenta, ResponseQuery<List<CuentaDto>> response)
        {
            try
            {
                response.ObjetoResultado = _cuentaDal.CreateCuenta(cuenta);
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

        public ResponseQuery<List<CuentaDto>> GetCuentaId(int id, ResponseQuery<List<CuentaDto>> response)
        {
            try
            {
                response.ObjetoResultado = _cuentaDal.GetCuentaId(id);
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

        public ResponseQuery<List<CuentaDto>> GetCuentas(ResponseQuery<List<CuentaDto>> response)
        {
            try
            {
                response.ObjetoResultado = _cuentaDal.GetCuentas();
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

        public ResponseQuery<List<CuentaDto>> UpdateCuenta(CuentaDto cuenta, ResponseQuery<List<CuentaDto>> response)
        {
            try
            {
                response.ObjetoResultado = _cuentaDal.UpdateCuenta(cuenta);
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

        public ResponseQuery<List<CuentaDto>> DeleteCuenta(int id, ResponseQuery<List<CuentaDto>> response)
        {
            try
            {
                response.ObjetoResultado = _cuentaDal.DeleteCuenta(id);
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
