using Aplicação.Arquitetura.Interface.ArquiteturaDB;
using Aplicação.Logica.ViewModel;
using Dominio.Logica.Interface.Servico;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class UsuarioController : Controller
    {
        private IUsuarioAplicacao _usuarioApp;
        public UsuarioController(IUsuarioAplicacao usuarioApp, IUsuarioServico usuarioServico)
        {
            _usuarioApp = usuarioApp;
        }
        
        [HttpGet]
        [Route("ObterUsuarioPorId")]
        public IActionResult ObterUsuarioPorId(int usuario_id)
        {
            try
            {
                var usuario = _usuarioApp.ObterUsuarioPorId(usuario_id);

                if (usuario != null)
                {
                    return Ok(usuario);
                }
                return BadRequest($"Usuario com a id {usuario_id} não foi encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Falha ao obter o usuario: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario(CadastroUsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (usuarioViewModel.Senha != usuarioViewModel.ConfirmaçãoSenha)
                {
                    return BadRequest("A Confirmação de senha não é igual a senha");
                }
                var usuario = await _usuarioApp.CadastrarUsuario(usuarioViewModel);

                if (!usuario.EstaValido) return BadRequest(usuario.ObterMensagens());

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest($"Falha ao cadastrar o usuario: {ex.Message}");
            }
        }
    }
}
