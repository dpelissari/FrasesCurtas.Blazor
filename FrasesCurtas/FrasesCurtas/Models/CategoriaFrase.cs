using System.ComponentModel.DataAnnotations;

namespace FrasesCurtas.Models {
    public class CategoriaFrase {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(250)]
        public string Categoria { get; set; }

        [MaxLength(250)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo data de cadastro é obrigatório")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public ICollection<Frase> Frases { get; set; }

        public bool Ativo { get; set; } = true;
        public void GerarNovoId() {
            Id = Guid.NewGuid();
        }
    }
}
