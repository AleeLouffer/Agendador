using Aplicação.Logica.ViewModel;
using AutoMapper;
using Dominio.Logica.Entidade.AgendadorDB;

namespace Aplicação.Logica.Mapeamentos
{
    public class UsuarioMapeamento : Profile
    {
        public UsuarioMapeamento()
        {
            CreateMap<Usuario, CadastroUsuarioViewModel>();
        }
    }
}
