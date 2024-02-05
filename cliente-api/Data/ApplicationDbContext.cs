using cliente_api.Modelos;
using Microsoft.EntityFrameworkCore;

namespace cliente_api.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //Agregar los modelos del api, a fin de..
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
    }
}
