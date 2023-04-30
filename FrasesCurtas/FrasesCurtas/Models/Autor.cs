using System.ComponentModel.DataAnnotations;

namespace FrasesCurtas.Models
{
    public class Autor
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MaxLength(250)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo data de cadastro é obrigatório")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;

        //[Required(ErrorMessage = "O campo imagem é obrigatório")]
        public string CaminhoImagem { get; set; }

        public ICollection<Frase> Frases { get; set; }
        // metodo para geração do id em Guid
        public void GerarNovoId()
        {
            Id = Guid.NewGuid();
        }
    }
}
