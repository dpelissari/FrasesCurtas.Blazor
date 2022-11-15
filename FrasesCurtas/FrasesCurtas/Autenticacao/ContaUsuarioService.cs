namespace FrasesCurtas.Autenticacao
{
    public class ContaUsuarioService
    {
        private List<ContaUsuario> _usuarios;

        public ContaUsuarioService()
        {
            _usuarios = new List<ContaUsuario>
            {
                new ContaUsuario{ Nome = "admin", Senha = "admin", NivelAcesso = "Administrador"},
                new ContaUsuario{ Nome = "user", Senha = "user", NivelAcesso = "User"}
            };
        }

        public ContaUsuario? BuscarPorNome(string nomeUsuario) {
            return _usuarios.FirstOrDefault(x => x.Nome == nomeUsuario);
        }
    }
}
