using Microservicios_common.Common;
using Microservicios_dal;

namespace Microservicios_bl
{
    public class MovimientoBl : IMovimientoBl
    {
        private readonly IMovimientoDal _movimientoDal;
        public MovimientoBl(IMovimientoDal movimientoDal)
        {
            _movimientoDal = movimientoDal;
        }

        public ResponseQuery<List<MovimientoDto>> CreateMovimiento(MovimientoDto movimiento, ResponseQuery<List<MovimientoDto>> response)
        {
            try
            {
                response.ObjetoResultado = _movimientoDal.CreateMovimiento(movimiento);
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

        public ResponseQuery<List<MovimientoDto>> GetMovimientoId(int id, ResponseQuery<List<MovimientoDto>> response)
        {
            try
            {
                response.ObjetoResultado = _movimientoDal.GetMovimientoId(id);
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

        public ResponseQuery<List<MovimientoDto>> GetMovimientos(ResponseQuery<List<MovimientoDto>> response)
        {
            try
            {
                response.ObjetoResultado = _movimientoDal.GetMovimientos();
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

        public ResponseQuery<List<MovimientoDto>> UpdateMovimiento(MovimientoDto movimiento, ResponseQuery<List<MovimientoDto>> response)
        {
            try
            {
                response.ObjetoResultado = _movimientoDal.UpdateMovimiento(movimiento);
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

        public ResponseQuery<List<MovimientoDto>> DeleteMovimiento(int id, ResponseQuery<List<MovimientoDto>> response)
        {
            try
            {
                response.ObjetoResultado = _movimientoDal.DeleteMovimiento(id);
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
