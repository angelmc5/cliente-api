using cliente_api.Data;
using cliente_api.Modelos;
using cliente_api.Repositorio.IRepositorio;
using System.Linq.Expressions;

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
            try
            {
                cliente.Nombre = cliente.Nombre.Trim().ToString();
                _bdd.Cliente.Add(cliente);
                return Guardar();
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"An error occurred while retrieving the entity: {ex.Message}");
            }
        }

        public bool ActualizarCliente(Cliente cliente)
        {
            try
            {
                _bdd.Cliente.Update(cliente);
            return Guardar();
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"An error occurred while retrieving the entity: {ex.Message}");
            }
        }

        public bool BorrarCliente(Cliente cliente)
        {
            try
            {
                _bdd.Cliente.Remove(cliente);
                return Guardar();
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"An error occurred while retrieving the entity: {ex.Message}");
            }
        }

       

        public bool ExisteCliente(string identificacion)
        {
            try
            {
                bool valor = _bdd.Cliente.Any(c => c.Identificacion.ToLower().Trim() == identificacion.ToLower().Trim());
                return valor;
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"An error occurred while retrieving the entity: {ex.Message}");
            }
        }

        public bool ExisteCliente(int id)
        {
            try
            {
                return _bdd.Cliente.Any(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"An error occurred while retrieving the entity: {ex.Message}");
            }
        }

        public Cliente GetCliente(int id)
        {
            try
            {
                return _bdd.Cliente.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"An error occurred while retrieving the entity: {ex.Message}");
            }
        }

        public ICollection<Cliente> GetClientes()
        {
            try
            {
                return _bdd.Cliente.OrderBy(c => c.Identificacion).ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"An error occurred while retrieving the entity: {ex.Message}");
            }
        }

        public bool Guardar()
        {
            try
            {
                return _bdd.SaveChanges() >= 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new RepositoryException($"An error occurred while retrieving the entity: {ex.Message}");  
            }
            
        }
    }
}
