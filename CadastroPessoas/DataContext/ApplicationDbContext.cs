using CadastroPessoas.Models;
using Microsoft.EntityFrameworkCore;
namespace CadastroPessoas.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CidadeModel> Cidades { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClienteModel>()
                .HasOne(c => c.Cidade)
                .WithMany(c => c.Clientes)
                .HasForeignKey(c => c.CidadeId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);


        }
    }
}

