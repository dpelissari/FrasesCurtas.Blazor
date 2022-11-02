using System.ComponentModel.DataAnnotations;

namespace FrasesCurtas.Models {
    public class Frase {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }

        public string DataCadastro { get; set; }

        public string Arquivada { get; set; } = "Falso";

        // metodo para geração do id em Guid
        public void GerarNovoId() {
            Id = Guid.NewGuid();
        }
    }
}
