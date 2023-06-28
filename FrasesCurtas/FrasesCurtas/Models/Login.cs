using System.ComponentModel.DataAnnotations;

namespace FrasesCurtas.Models {
    public class Login {

        [Required(ErrorMessage = "O campo login é obrigatório")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Senha { get; set; }
    }
}
