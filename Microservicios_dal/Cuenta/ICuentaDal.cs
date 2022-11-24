namespace Microservicios_dal
{
    public interface ICuentaDal
    {
        public List<CuentaDto> GetCuentas();

        public List<CuentaDto> GetCuentaId(int id);

        public List<CuentaDto> CreateCuenta(CuentaDto cuenta);

        public List<CuentaDto> UpdateCuenta(CuentaDto cuenta);

        public List<CuentaDto> DeleteCuenta(int id);

    }
}
