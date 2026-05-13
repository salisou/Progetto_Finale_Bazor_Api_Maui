
using Microsoft.EntityFrameworkCore;
using ProgettoFinale.Models;

namespace ProgettoFinale.Services
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Clienti> Clienti { get; set; } 
    }
}
