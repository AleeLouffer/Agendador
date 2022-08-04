using Dominio.Logica.Entidade.AgendadorDB;

namespace Dominio.Logica.Interface.Repositorio.AgendadorDB
{
    public interface IRepositorioUsuario
    {
        Usuario? ObterUsuarioPorID(int id);
    }
}
