using FrasesCurtas.Models;
using Microsoft.EntityFrameworkCore;

namespace FrasesCurtas.Data
{
    public class AplicacaoDbContexto : DbContext
    {
        public AplicacaoDbContexto(DbContextOptions<AplicacaoDbContexto> options) : base(options) { }

        public DbSet<Frase>? Frases { get; set; }
        public DbSet<Autor>? Autores { get; set; }
        public DbSet<CategoriaFrase>? Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // mapeia propriedades
            modelBuilder.Entity<Frase>().HasKey(m => m.Id);
            modelBuilder.Entity<Autor>().HasKey(m => m.Id);

            // configura a relação onde um autor pode ter varias frases e uma frase um unico autor
            modelBuilder.Entity<Autor>()
            .HasMany(g => g.Frases)
            .WithOne(s => s.Autor)
            .HasForeignKey(s => s.IdAutor)
            .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
