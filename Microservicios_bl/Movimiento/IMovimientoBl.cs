using Microservicios_common.Common;
using Microservicios_dal;

namespace Microservicios_bl
{
    public interface IMovimientoBl
    {
        public ResponseQuery<List<MovimientoDto>> GetMovimientos(ResponseQuery<List<MovimientoDto>> response);
        public ResponseQuery<List<MovimientoDto>> GetMovimientoId(int id, ResponseQuery<List<MovimientoDto>> response);
        public ResponseQuery<List<MovimientoDto>> CreateMovimiento(MovimientoDto movimiento, ResponseQuery<List<MovimientoDto>> response);
        public ResponseQuery<List<MovimientoDto>> UpdateMovimiento(int id, MovimientoDto movimiento, ResponseQuery<List<MovimientoDto>> response);
        public ResponseQuery<List<MovimientoDto>> DeleteMovimiento(int id, ResponseQuery<List<MovimientoDto>> response);
        public ResponseQuery<List<MovimientoDto>> GetReporteFecha(string fecha, string cliente, ResponseQuery<List<MovimientoDto>> response);
    }
}
