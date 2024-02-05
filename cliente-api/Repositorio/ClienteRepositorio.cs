using cliente_api.Data;
using cliente_api.Modelos;
using cliente_api.Repositorio.IRepositorio;

namespace cliente_api.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly ApplicationDbContext _bdd;
        public ClienteRepositorio( ApplicationDbContext bdd)
        {
            _bdd = bdd;
        }
        public bool CrearCliente(Cliente cliente)
        {
            cliente.Nombre = cliente.Nombre.Trim().ToString();
            _bdd.Cliente.Add(cliente);
            return Guardar();
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            _bdd.Cliente.Update(cliente);
            return Guardar();
        }

        public bool BorrarCliente(Cliente cliente)
        {
            _bdd.Cliente.Remove(cliente);
            return Guardar();
        }

       

        public bool ExisteCliente(string identificacion)
        {
            bool valor = _bdd.Cliente.Any(c => c.Identificacion.ToLower().Trim() == identificacion.ToLower().Trim());
            return valor;
        }

        public bool ExisteCliente(int id)
        {
            return _bdd.Cliente.Any(c => c.Id == id);
        }

        public Cliente GetCliente(int id)
        {
            return _bdd.Cliente.FirstOrDefault(c => c.Id == id);
        }

        public ICollection<Cliente> GetClientes()
        {
            return _bdd.Cliente.OrderBy(c => c.Identificacion).ToList();
        }

        public bool Guardar()
        {
            try
            {
                return _bdd.SaveChanges() >= 0 ? true : false;
            }
            catch (Exception ex)
            {
                //guardar excepcion en logs
                return false;    
            }
            
        }
    }
}
