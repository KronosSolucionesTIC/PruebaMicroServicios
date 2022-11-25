using AutoMapper;
using Microservicios_dal;

namespace PruebaMicroservicios.Automapper
{
    public class MappingProfileMasterModule : Profile
    {
        public MappingProfileMasterModule()
        {
            #region Creacion de mapeo de las entidades
            //Clientes
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            //Cuentas
            CreateMap<Cuenta, CuentaDto>().ReverseMap();
            //Movimiento
            CreateMap<Movimiento, MovimientoDto>().ReverseMap();
            #endregion
        }
    }
}
