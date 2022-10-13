using Dominio.Logica.Entidade.AgendadorDB;

namespace Dominio.Logica.Interface.Servico
{
    public interface IUsuarioServico
    {
        Task<Usuario>? AlterarSenhaDoUsuario(Usuario usuario, string novaSenha, string confirmacaoNovaSenha);
        Task<Usuario>? CadastrarUsuario(Usuario usuario);
        Usuario? ObterPorId(int id);
    }
}
