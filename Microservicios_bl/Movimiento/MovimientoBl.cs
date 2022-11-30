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
                if (!validarMovimento(movimiento))
                {
                    response.Mensaje = "Saldo no disponible";
                    response.CodigoResultado = null;
                    response.Exitoso = false;
                }
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

        public ResponseQuery<List<MovimientoDto>> UpdateMovimiento(int id, MovimientoDto movimiento, ResponseQuery<List<MovimientoDto>> response)
        {
            try
            {
                response.ObjetoResultado = _movimientoDal.UpdateMovimiento(id, movimiento);
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

        public bool validarMovimento(MovimientoDto movimiento)
        {
            if(movimiento.TipoMovimiento == "Debito" && movimiento.SaldoMovimiento <= 0)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public ResponseQuery<List<MovimientoDto>> GetReporteFecha(string fecha, string cliente, ResponseQuery<List<MovimientoDto>> response)
        {
            try
            {
                response.ObjetoResultado = _movimientoDal.GetReporteFecha(fecha, cliente);
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
