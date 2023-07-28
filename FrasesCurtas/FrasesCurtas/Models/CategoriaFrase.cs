using System.ComponentModel.DataAnnotations;

namespace FrasesCurtas.Models {
    public class CategoriaFrase {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(250)]

        [Required(ErrorMessage = "O campo categoria é obrigatório")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
        public string Descricao { get; set; }
   

        [Required(ErrorMessage = "O campo data de cadastro é obrigatório")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        public ICollection<Frase> Frases { get; set; }

        [Required(ErrorMessage = "O campo ativo é obrigatório")]
        public bool Ativo { get; set; } = true;

        public void GerarNovoId() {
            Id = Guid.NewGuid();
        }
    }
}
