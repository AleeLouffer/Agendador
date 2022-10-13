using Dados.Logica.Contexto;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InjecaoDepedencia
{
    public partial class InicializadorInjecaoDepedencia
    {
        public static void Iniciar(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<AgendadorDbContexto>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration.GetConnectionString("AgendadorDB"), 
                    b => b.MigrationsAssembly("API"));
            });

            InicializarAplicacao(services);
            IniciarServicos(services);
            IniciarRepositorios(services);
        }
    }
}
