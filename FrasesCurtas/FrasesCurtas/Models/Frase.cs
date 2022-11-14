using System.ComponentModel.DataAnnotations;

namespace FrasesCurtas.Models {
    public class Frase {
        [Key]
        public Guid Id { get; set; }

        public Guid IdAutor { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Descricao { get; set; }

        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        public bool Arquivada { get; set; } = false;

        // metodo para geração do id em Guid
        public void GerarNovoId() {
            Id = Guid.NewGuid();
        }
    }
}
