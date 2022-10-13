using Dominio.Logica.Interface.Servico;
using Dominio.Logica.Servico.AgendadorDB;
using Microsoft.Extensions.DependencyInjection;

namespace InjecaoDepedencia
{
    public partial class InicializadorInjecaoDepedencia
    {
        private static void IniciarServicos(IServiceCollection services)
        {
            services.AddScoped<IUsuarioServico, UsuarioServico>();
        }
    }
}
