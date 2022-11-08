using Microsoft.EntityFrameworkCore;

namespace WebAppGlobal.Models
{
    public class WebAppGlobalDbContext : DbContext
    {
        public WebAppGlobalDbContext(DbContextOptions<WebAppGlobalDbContext> options) : base(options)
        {

        }

        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
    }
}
