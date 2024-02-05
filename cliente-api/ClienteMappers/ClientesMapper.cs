using AutoMapper;
using cliente_api.Modelos.Dtos;
using cliente_api.Modelos;

namespace cliente_api.ClienteMappers
{
    public class ClientesMapper : Profile
    {

        public ClientesMapper()
        {
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<Cliente, CrearClienteDto>().ReverseMap();
        }
    }
}
