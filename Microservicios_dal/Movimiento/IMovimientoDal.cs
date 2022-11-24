namespace Microservicios_dal
{
    public interface IMovimientoDal
    {
        public List<MovimientoDto> GetMovimientos();

        public List<MovimientoDto> GetMovimientoId(int id);

        public List<MovimientoDto> CreateMovimiento(MovimientoDto movimiento);

        public List<MovimientoDto> UpdateMovimiento(MovimientoDto movimiento);

        public List<MovimientoDto> DeleteMovimiento(int id);

    }
}
