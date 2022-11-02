using FrasesCurtas.Models;
using Microsoft.EntityFrameworkCore;

namespace FrasesCurtas.Data {
    public class AplicacaoDbContexto : DbContext {

        public DbSet<Frase> Frases { get; set; }

        public AplicacaoDbContexto(DbContextOptions<AplicacaoDbContexto> options) : base(options) {

        }
    }
}
