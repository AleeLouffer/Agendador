using Aplicação.Logica.ViewModel;
using Dominio.Logica.Entidade.AgendadorDB;

namespace Aplicação.Arquitetura.Interface.ArquiteturaDB
{
    public interface IUsuarioAplicacao
    {
        Usuario? ObterUsuarioPorId(int id);
        Task<Usuario> CadastrarUsuario(CadastroUsuarioViewModel usuarioViewModel);
    }
}
