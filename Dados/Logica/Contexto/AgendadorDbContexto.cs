using Dados.Logica.Configuracao.AgendadorDB;
using Microsoft.EntityFrameworkCore;

namespace Dados.Logica.Contexto
{
    public class AgendadorDbContexto : DbContext
    {
        public AgendadorDbContexto(DbContextOptions<AgendadorDbContexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracao());
        }
    }
}
