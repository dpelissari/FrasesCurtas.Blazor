using System.ComponentModel.DataAnnotations;

namespace FrasesCurtas.Models
{
    public class CategoriaFrase
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo categoria é obrigatório")]
        [MaxLength(250)]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        [MaxLength(250)]
        public string Descricao { get; set; }
        public bool Ativa { get; set; } = true;

        public ICollection<Frase> Frases { get; set; }

        public void GerarIdCategoria()
        {
            Id = Guid.NewGuid();
        }
    }
}
