using Microsoft.EntityFrameworkCore;
using minhaapi.modulo;

namespace minhaapi.infraestrutura
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        
          => optionsBuilder.UseNpgsql(
           "Server=localhost;" +
           "port=5432;Database=employee;" +
           "User Id+postgres;" +
           "password=C@lebe10"
              ); 
        
    }
}
