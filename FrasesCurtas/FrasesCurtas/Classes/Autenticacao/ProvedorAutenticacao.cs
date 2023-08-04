using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;

namespace FrasesCurtas.Classes.Autenticacao
{
    public class ProvedorAutenticacao : AuthenticationStateProvider
    {
        protected readonly ProtectedSessionStorage _sessionStorage;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public ProvedorAutenticacao(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                var resultadoAmarzenamentoSessaoUsuario = await _sessionStorage.GetAsync<UsuarioSessao>("UsuarioSessao");
                var usuarioSessao = resultadoAmarzenamentoSessaoUsuario.Success ? resultadoAmarzenamentoSessaoUsuario.Value : null;

                if (usuarioSessao == null) return await Task.FromResult(new AuthenticationState(_anonymous));

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuarioSessao.Nome),
                new Claim(ClaimTypes.Role, usuarioSessao.NivelAcesso),
            }, "AutenticacaoCustomizada"));
                return await Task.FromResult(new AuthenticationState(claimsPrincipal));
            }
            catch
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public async Task AtualizarEstadoAutenticao(UsuarioSessao usuarioSessao)
        {
            ClaimsPrincipal claimsPrincipal;

            if (usuarioSessao != null)
            {
                await _sessionStorage.SetAsync("UsuarioSessao", usuarioSessao);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                     new Claim(ClaimTypes.Name, usuarioSessao.Nome),
                    new Claim(ClaimTypes.Role, usuarioSessao.NivelAcesso),
                }));
            }
            else
            {
                await _sessionStorage.DeleteAsync("UsuarioSessao");
                claimsPrincipal = _anonymous;
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}
