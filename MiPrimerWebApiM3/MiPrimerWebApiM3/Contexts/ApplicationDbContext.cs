namespace MiPrimerWebApiM3.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using MiPrimerWebApiM3.Entities;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

        public DbSet<HostedServiceLog> HostedServiceLogs { get; set; }
    }
}