using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
            newCuenta.ClienteId = cuenta.ClienteId;

            _context.Cuentas.Add(newCuenta);
            _context.SaveChangesAsync();

            List<CuentaDto> list = new List<CuentaDto>();
            list.Add(cuenta);
            return list;
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

        public List<CuentaDto> UpdateCuenta(int id, CuentaDto cuenta)
        {
            cuenta.Id = id;
            var resultado = _context.Cuentas.Find(id);
            CuentaDto cuentaDto = _mapper.Map<CuentaDto>(resultado);
            var objectDto = _mapper.Map<CuentaDto, Cuenta>(cuenta, resultado);
            _context.Entry(resultado).State = EntityState.Modified;
            _context.SaveChanges();

            List<CuentaDto> listaDto = new List<CuentaDto>();
            listaDto.Add(cuenta);
            return listaDto;
        }
    }
}
