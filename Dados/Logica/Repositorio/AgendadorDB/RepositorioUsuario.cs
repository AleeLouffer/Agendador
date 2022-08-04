using Dados.Arquitetura;
using Dados.Logica.Contexto;
using Dominio.Logica.Entidade.AgendadorDB;
using Dominio.Logica.Interface.Repositorio.AgendadorDB;
using Microsoft.Extensions.Logging;

namespace Dados.Logica.Repositorio.AgendadorDB
{

    public class RepositorioUsuario : RepositorioBase<Usuario, AgendadorDbContexto>, IRepositorioUsuario
    {
        public RepositorioUsuario(AgendadorDbContexto contexto, ILogger<RepositorioUsuario> logger) : base(contexto, logger)
        {
        }

        public Usuario? ObterUsuarioPorID(int id)
        {
            return ObterSomente(x => x.Id == id && x.Situacao == "A")?
                .FirstOrDefault();
        }
    }
}
