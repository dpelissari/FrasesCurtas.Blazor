using System.ComponentModel.DataAnnotations;

namespace FrasesCurtas.Models {
    public class Frase {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo autor é obrigatório")]
        public Guid IdAutor { get; set; }


        [Required(ErrorMessage = "O campo categoria é obrigatório")]
        public Guid IdCategoriaFrase { get; set; }
    

        public Autor Autor { get; set; }


        public CategoriaFrase Categoria { get; set; }


        [Required(ErrorMessage = "O campo frase é obrigatório")]
        public string? Descricao { get; set; }

        public DateTime? DataCadastro { get; set; } = DateTime.Now;

        public bool Arquivada { get; set; } = false;

        // metodo para geração do id em Guid
        public void GerarNovoId() {
            Id = Guid.NewGuid();
        }
    }
}
