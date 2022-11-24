namespace Microservicios_dal
{
    public interface IClienteDal
    {
        public List<ClienteDto> GetClientes();

        public List<ClienteDto> GetClienteId(int id);

        public List<ClienteDto> CreateCliente(ClienteDto cliente);

        public List<ClienteDto> UpdateCliente(ClienteDto cliente);

        public List<ClienteDto> DeleteCliente(int id);

    }
}
