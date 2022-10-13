using Aplicação.Arquitetura.Interface.ArquiteturaDB;
using Aplicação.Logica.Aplicacao.ArquiteturaDB;
using Microsoft.Extensions.DependencyInjection;

namespace InjecaoDepedencia
{
    public partial class InicializadorInjecaoDepedencia
    {
        private static void InicializarAplicacao(IServiceCollection services)
        {
            services.AddScoped<IUsuarioAplicacao, UsuarioAplicacao>();
        }
    }
}
