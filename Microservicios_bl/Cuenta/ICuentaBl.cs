using Microservicios_common.Common;
using Microservicios_dal;
using Microsoft.EntityFrameworkCore;

namespace Microservicios_bl
{
    public interface ICuentaBl
    {
        public ResponseQuery<List<CuentaDto>> GetCuentas(ResponseQuery<List<CuentaDto>> response);

        public ResponseQuery<List<CuentaDto>> GetCuentaId(int id, ResponseQuery<List<CuentaDto>> response);

        public ResponseQuery<List<CuentaDto>> CreateCuenta(CuentaDto cuenta, ResponseQuery<List<CuentaDto>> response);
        
        public ResponseQuery<List<CuentaDto>> UpdateCuenta(int id, CuentaDto cuenta, ResponseQuery<List<CuentaDto>> response);

        public ResponseQuery<List<CuentaDto>> DeleteCuenta(int id, ResponseQuery<List<CuentaDto>> response);
    }
}
