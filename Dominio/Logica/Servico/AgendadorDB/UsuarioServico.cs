using Dominio.Logica.Entidade.AgendadorDB;
using Dominio.Logica.Interface.Repositorio.AgendadorDB;
using Dominio.Logica.Interface.Servico;

namespace Dominio.Logica.Servico.AgendadorDB
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IRepositorioUsuario _repoUsuario;
        public UsuarioServico(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }
        public async Task<Usuario>? AlterarSenhaDoUsuario(Usuario usuario, string novaSenha, string confirmacaoNovaSenha)
        {
            usuario.AlterarSenha(novaSenha, confirmacaoNovaSenha);
            if (!usuario.EstaValido) return usuario;
            
            if(!await _repoUsuario.Atualizar(usuario))
            {
                usuario.AdicionarMensagemErro("Falha ao alterar senha do usuario");
            }
            usuario.AdicionarMensagemSucesso("Senha atualizadao com sucesso");

            return usuario;
        }

        public async Task<Usuario>? CadastrarUsuario(Usuario usuario)
        {
            usuario.EstadoValido();

            if (!usuario.EstaValido) return usuario;

            if (await _repoUsuario.Inserir(usuario))
                usuario.AdicionarMensagemErro("Dados do usuario criados com sucesso!");
            else
                usuario.AdicionarMensagemErro("Falha ao criar usuario");

            return usuario;
        }

        public Usuario? ObterPorId(int id)
        {
            return _repoUsuario.ObterUsuarioPorID(id);
        }
    }
}
