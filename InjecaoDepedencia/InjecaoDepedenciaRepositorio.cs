using Dados.Logica.Repositorio.AgendadorDB;
using Dominio.Logica.Interface.Repositorio.AgendadorDB;
using Microsoft.Extensions.DependencyInjection;

namespace InjecaoDepedencia
{
    public partial class InicializadorInjecaoDepedencia
    {
        private static void IniciarRepositorios(IServiceCollection services)
        {
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
        }
    }
}
