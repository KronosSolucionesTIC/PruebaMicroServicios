using AutoMapper;

namespace Microservicios_dal
{
    public class CuentaDal : ICuentaDal
    {
        protected readonly DataContext _context;

        private readonly IMapper _mapper;

        public CuentaDal(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CuentaDto> CreateCuenta(CuentaDto cuenta)
        {
            var newCuenta = new Cuenta();
            newCuenta.EstadoCuenta = cuenta.EstadoCuenta;
            newCuenta.TipoCuenta = cuenta.TipoCuenta;
            newCuenta.NumeroCuenta = cuenta.NumeroCuenta;
            newCuenta.SaldoInicial = cuenta.SaldoInicial;

            _context.Cuentas.Add(newCuenta);
            _context.SaveChangesAsync();

            var Resultado = GetCuentaId(cuenta.Id);

            return Resultado;
        }

        public List<CuentaDto> DeleteCuenta(int id)
        {
            List<CuentaDto> listaDto = new List<CuentaDto>();
            var cuenta = _context.Cuentas.Find(id);
            if (cuenta == null)
            {
                return listaDto;
            }
            _context.Cuentas.Remove(cuenta);
            _context.SaveChangesAsync();

            return listaDto;
        }

        public List<CuentaDto> GetCuentaId(int id)
        {
            var listaDto = new List<CuentaDto>();
            var resultado = _context.Cuentas.Where(x => x.Id == id).ToList();
            if (resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    listaDto.Add(new CuentaDto
                    {
                        Id = item.Id,
                        EstadoCuenta = item.EstadoCuenta,
                        NumeroCuenta = item.NumeroCuenta,
                        TipoCuenta = item.TipoCuenta,
                        SaldoInicial = item.SaldoInicial
                    });
                }
            }
            return listaDto;
        }

        public List<CuentaDto> GetCuentas()
        {
            var listaDto = new List<CuentaDto>();
            var resultado = _context.Cuentas.ToList();
            if(resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    listaDto.Add(new CuentaDto { 
                        Id = item.Id,
                        EstadoCuenta = item.EstadoCuenta,
                        NumeroCuenta = item.NumeroCuenta,
                        TipoCuenta = item.TipoCuenta,
                        SaldoInicial = item.SaldoInicial
                    });
                }
            }
            return listaDto;
        }

        public List<CuentaDto> UpdateCuenta(CuentaDto cuenta)
        {
            var resultado = _context.Cuentas.Find(cuenta.Id);
            CuentaDto cuentaDto = new CuentaDto();
            cuentaDto.Id = resultado.Id;
            cuentaDto.EstadoCuenta = resultado.EstadoCuenta;
            cuentaDto.NumeroCuenta = resultado.NumeroCuenta;
            cuentaDto.TipoCuenta = resultado.TipoCuenta;
            cuentaDto.SaldoInicial = resultado.SaldoInicial;
            _context.SaveChanges();

            List<CuentaDto> listaDto = new List<CuentaDto>();
            listaDto.Add(cuentaDto);
            return listaDto;
        }
    }
}
