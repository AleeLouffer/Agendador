using Dominio.Logica.Entidade.AgendadorDB;

namespace Dominio.Logica.Interface.Repositorio.AgendadorDB
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario>
    {
        Usuario? ObterUsuarioPorID(int id);
    }
}
