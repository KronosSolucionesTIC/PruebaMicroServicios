using Microservicios_common.Common;
using Microservicios_dal;
using Microsoft.EntityFrameworkCore;

namespace Microservicios_bl
{
    public interface IMovimientoBl
    {
        public ResponseQuery<List<MovimientoDto>> GetMovimientos(ResponseQuery<List<MovimientoDto>> response);

        public ResponseQuery<List<MovimientoDto>> GetMovimientoId(int id, ResponseQuery<List<MovimientoDto>> response);

        public ResponseQuery<List<MovimientoDto>> CreateMovimiento(MovimientoDto movimiento, ResponseQuery<List<MovimientoDto>> response);
        
        public ResponseQuery<List<MovimientoDto>> UpdateMovimiento(MovimientoDto movimiento, ResponseQuery<List<MovimientoDto>> response);

        public ResponseQuery<List<MovimientoDto>> DeleteMovimiento(int id, ResponseQuery<List<MovimientoDto>> response);
    }
}
