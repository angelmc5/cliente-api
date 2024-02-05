using cliente_api.Modelos;

namespace cliente_api.Repositorio.IRepositorio
{
    public interface IClienteRepositorio
    {
        ICollection<Cliente> GetClientes();
        Cliente GetCliente(int id);
        bool ExisteCliente(string identificacion);
        bool ExisteCliente(int id);
        bool CrearCliente(Cliente cliente);
        bool ActualizarCliente(Cliente cliente);
        bool BorrarCliente(Cliente cliente);
        bool Guardar();
    }
}
