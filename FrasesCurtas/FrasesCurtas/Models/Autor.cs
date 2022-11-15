using System.ComponentModel.DataAnnotations;

namespace FrasesCurtas.Models
{
    public class Autor
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;



        public ICollection<Frase> Frases { get; set; }

        // metodo para geração do id em Guid
        public void GerarNovoId()
        {
            Id = Guid.NewGuid();
        }
    }
}
