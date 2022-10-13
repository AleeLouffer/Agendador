using Aplicação.Arquitetura.Interface.ArquiteturaDB;
using Aplicação.Logica.ViewModel;
using AutoMapper;
using Dominio.Logica.Entidade.AgendadorDB;
using Dominio.Logica.Interface.Repositorio.AgendadorDB;
using Dominio.Logica.Interface.Servico;

namespace Aplicação.Logica.Aplicacao.ArquiteturaDB
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioServico _usuarioServico;

        public UsuarioAplicacao(IRepositorioUsuario repositorioUsuario, IMapper mapper, IUsuarioServico usuarioServico)
        {
            _mapper = mapper;
            _usuarioServico = usuarioServico;
        }
        public Usuario? ObterUsuarioPorId(int id)
        {
            return _usuarioServico.ObterPorId(id);
        }

        public async Task<Usuario> CadastrarUsuario(CadastroUsuarioViewModel usuarioViewModel)
        {
            return await _usuarioServico.CadastrarUsuario(new Usuario(usuarioViewModel.Nome, usuarioViewModel.CPF, 
                usuarioViewModel.Email, usuarioViewModel.Senha))!;
        }
    }
}
