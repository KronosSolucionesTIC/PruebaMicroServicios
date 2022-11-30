using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            newMovimiento.NumeroCuenta = movimiento.NumeroCuenta;
            newMovimiento.TipoCuenta = movimiento.TipoCuenta;
            newMovimiento.EstadoCuenta = movimiento.EstadoCuenta;
            newMovimiento.SaldoInicial = movimiento.SaldoInicial;
      
            newMovimiento.SaldoMovimiento = calcularSaldo(movimiento.TipoMovimiento, movimiento.SaldoInicial, movimiento.ValorMovimiento);

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

        public List<MovimientoDto> UpdateMovimiento(int id,MovimientoDto movimiento)
        {
            movimiento.Id = id;
            var resultado = _context.Movimientos.Find(id);
            MovimientoDto movimientoDto = _mapper.Map<MovimientoDto>(resultado);
            var objectDto = _mapper.Map<MovimientoDto, Movimiento>(movimiento, resultado);
            _context.Entry(resultado).State = EntityState.Modified;
            _context.SaveChanges();

            List<MovimientoDto> listaDto = new List<MovimientoDto>();
            listaDto.Add(movimiento);
            return listaDto;
        }

        public int? calcularSaldo(string tipoMovimiento, int? saldoInicial, int? valorMovimiento)
        {
            int? saldoFinal = null;
            switch (tipoMovimiento)
            {
                case "Retiro":
                    saldoFinal = saldoInicial - valorMovimiento;
                    return saldoFinal;
                case "Deposito":
                    saldoFinal = saldoInicial + valorMovimiento;
                    return saldoFinal;
                default:
                    return saldoFinal;
            }
        }

        public List<MovimientoDto> GetReporteFecha(string fecha, string cliente)
        {
            var listaDto = new List<MovimientoDto>();
            if (string.IsNullOrEmpty(fecha))
            {
                return listaDto;
            }
            var listaCliente = _context.Clientes.Where(x => x.NombrePersona == cliente).ToList();

            if(listaCliente.Count == 0)
            {
                return listaDto;
            }
            var clienteId = 0;
            foreach (var item in listaCliente)
            {
                clienteId = item.Id;
            }
            var listaCuentas = _context.Cuentas.Where(x => x.ClienteId == clienteId).ToList();

            if (string.IsNullOrEmpty(fecha))
            {
                return listaDto;
            }
                var fechaQuery = Convert.ToDateTime(fecha);
                foreach (var item in listaCuentas)
                {
                    var resultado = _context.Movimientos.Where(x => x.FechaMovimiento == fechaQuery && x.NumeroCuenta == item.NumeroCuenta).ToList();
                    if (resultado.Count > 0)
                    {
                        foreach (var row in resultado)
                        {
                            listaDto.Add(new MovimientoDto
                            {
                                Id = row.Id,
                                FechaMovimiento = row.FechaMovimiento,
                                NumeroCuenta = row.NumeroCuenta,
                                TipoCuenta = row.TipoCuenta,
                                SaldoInicial = row.SaldoInicial,
                                EstadoCuenta = row.EstadoCuenta,
                                ValorMovimiento = row.ValorMovimiento,
                                SaldoMovimiento = row.SaldoMovimiento,
                                TipoMovimiento = row.TipoMovimiento,
                                NombreCliente = cliente
                            });
                        }
                    }
                }
            return listaDto;
        }
    }
}
