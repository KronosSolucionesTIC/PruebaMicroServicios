using AutoMapper;

namespace Microservicios_dal
{
    public class MovimientoDal : IMovimientoDal
    {
        protected readonly DataContext _context;

        private readonly IMapper _mapper;

        public MovimientoDal(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MovimientoDto> CreateMovimiento(MovimientoDto movimiento)
        {
            var newMovimiento = new Movimiento();
            newMovimiento.FechaMovimiento = movimiento.FechaMovimiento;
            newMovimiento.TipoMovimiento = movimiento.TipoMovimiento;
            newMovimiento.ValorMovimiento = movimiento.ValorMovimiento;
            newMovimiento.SaldoMovimiento = movimiento.SaldoMovimiento;

            _context.Movimientos.Add(newMovimiento);
            _context.SaveChangesAsync();

            List<MovimientoDto> list = new List<MovimientoDto>();
            list.Add(movimiento);
            return list;
        }

        public List<MovimientoDto> DeleteMovimiento(int id)
        {
            List<MovimientoDto> listaDto = new List<MovimientoDto>();
            var movimiento = _context.Movimientos.Find(id);
            if (movimiento == null)
            {
                return listaDto;
            }
            _context.Movimientos.Remove(movimiento);
            _context.SaveChangesAsync();

            return listaDto;
        }

        public List<MovimientoDto> GetMovimientoId(int id)
        {
            var listaDto = new List<MovimientoDto>();
            var resultado = _context.Movimientos.Where(x => x.Id == id).ToList();
            if (resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    listaDto.Add(new MovimientoDto
                    {
                        Id = item.Id,
                        FechaMovimiento = item.FechaMovimiento,
                        TipoMovimiento = item.TipoMovimiento,
                        ValorMovimiento = item.ValorMovimiento,
                        SaldoMovimiento = item.SaldoMovimiento
                    });
                }
            }
            return listaDto;
        }

        public List<MovimientoDto> GetMovimientos()
        {
            var listaDto = new List<MovimientoDto>();
            var resultado = _context.Movimientos.ToList();
            if(resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    listaDto.Add(new MovimientoDto { 
                        Id = item.Id,
                        FechaMovimiento = item.FechaMovimiento,
                        TipoMovimiento = item.TipoMovimiento,
                        ValorMovimiento = item.ValorMovimiento,
                        SaldoMovimiento = item.SaldoMovimiento
                    });
                }
            }
            return listaDto;
        }

        public List<MovimientoDto> UpdateMovimiento(MovimientoDto movimiento)
        {
            var resultado = _context.Movimientos.Find(movimiento.Id);
            MovimientoDto movimientoDto = new MovimientoDto();
            movimientoDto.Id = resultado.Id;
            movimientoDto.FechaMovimiento = resultado.FechaMovimiento;
            movimientoDto.TipoMovimiento = resultado.TipoMovimiento;
            movimientoDto.ValorMovimiento = resultado.ValorMovimiento;
            movimientoDto.SaldoMovimiento = resultado.SaldoMovimiento;
            _context.SaveChanges();

            List<MovimientoDto> listaDto = new List<MovimientoDto>();
            listaDto.Add(movimientoDto);
            return listaDto;
        }
    }
}
