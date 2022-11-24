using AutoMapper;

namespace Microservicios_dal
{
    public class ClienteDal : IClienteDal
    {
        protected readonly DataContext _context;

        private readonly IMapper _mapper;

        public ClienteDal(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ClienteDto> CreateCliente(ClienteDto cliente)
        {
            var newCliente = new Cliente();
            newCliente.EstadoCliente = cliente.EstadoCliente;
            newCliente.PassCliente = cliente.PassCliente;
            newCliente.EdadPersona = cliente.EdadPersona;
            newCliente.IdentificacionPersona = cliente.IdentificacionPersona;
            newCliente.DireccionPersona = cliente.DireccionPersona;
            newCliente.TelefonoPersona = cliente.TelefonoPersona;
            newCliente.GeneroPersona = cliente.GeneroPersona;

            _context.Clientes.Add(newCliente);
            _context.SaveChangesAsync();

            var Resultado = GetClienteId(cliente.Id);

            return Resultado;
        }

        public List<ClienteDto> DeleteCliente(int id)
        {
            List<ClienteDto> listaDto = new List<ClienteDto>();
            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return listaDto;
            }
            _context.Clientes.Remove(cliente);
            _context.SaveChangesAsync();

            return listaDto;
        }

        public List<ClienteDto> GetClienteId(int id)
        {
            var listaDto = new List<ClienteDto>();
            var resultado = _context.Clientes.Where(x => x.Id == id).ToList();
            if (resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    listaDto.Add(new ClienteDto
                    {
                        Id = item.Id,
                        NombrePersona = item.NombrePersona,
                        DireccionPersona = item.DireccionPersona,
                        GeneroPersona = item.GeneroPersona,
                        EdadPersona = item.EdadPersona,
                        EstadoCliente = item.EstadoCliente,
                        IdentificacionPersona = item.IdentificacionPersona,
                        TelefonoPersona = item.TelefonoPersona,
                        PassCliente = item.PassCliente
                    });
                }
            }
            return listaDto;
        }

        public List<ClienteDto> GetClientes()
        {
            var listaDto = new List<ClienteDto>();
            var resultado = _context.Clientes.ToList();
            if(resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    listaDto.Add(new ClienteDto { 
                        Id = item.Id,
                        NombrePersona = item.NombrePersona,
                        DireccionPersona = item.DireccionPersona,
                        GeneroPersona = item.GeneroPersona,
                        EdadPersona = item.EdadPersona,
                        EstadoCliente = item.EstadoCliente,
                        IdentificacionPersona = item.IdentificacionPersona,
                        TelefonoPersona = item.TelefonoPersona,
                        PassCliente = item.PassCliente
                    });
                }
            }
            return listaDto;
        }

        public List<ClienteDto> UpdateCliente(ClienteDto cliente)
        {
            var resultado = _context.Clientes.Find(cliente.Id);
            ClienteDto clienteDto = new ClienteDto();
            clienteDto.Id = resultado.Id;
            clienteDto.EstadoCliente = resultado.EstadoCliente;
            clienteDto.PassCliente = resultado.PassCliente;
            clienteDto.DireccionPersona = resultado.DireccionPersona;
            clienteDto.TelefonoPersona= resultado.TelefonoPersona ;
            clienteDto.GeneroPersona= resultado.GeneroPersona ;
            _context.SaveChanges();

            List<ClienteDto> listaDto = new List<ClienteDto>();
            listaDto.Add(clienteDto);
            return listaDto;
        }
    }
}
