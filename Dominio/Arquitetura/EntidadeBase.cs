namespace Dominio.Arquitetura
{
    using Comuns.Logica;
    using Comuns.Logica.Enums;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class EntidadeBase
    {
        [NotMapped]
        private readonly List<Mensagem> _mensagens = new();

        [NotMapped]
        public bool EstaValido { get; private set; }

        protected EntidadeBase()
        {
            EstaValido = true;
        }

        public void AdicionarMensagens(List<Mensagem> mensagens)
        {
            mensagens.ForEach(mensagem => AdicionarMensagem(mensagem));
        }

        public void AdicionarMensagem(Mensagem mensagem)
        {
            if (ETipoMensagem.ERRO == mensagem.Tipo)
                EstaValido = false;

            _mensagens.Add(mensagem);
        }

        public void AdicionarMensagemErro(string mensagem)
        {
            AdicionarMensagem(new Mensagem(mensagem, ETipoMensagem.ERRO));
        }

        public void AdicionarMensagemSucesso(string mensagem)
        {
            AdicionarMensagem(new Mensagem(mensagem, ETipoMensagem.SUCESSO));
        }

        public List<Mensagem> ObterMensagens()
        {
            return _mensagens;
        }

        public List<Mensagem> ObterMensagensPorTipo(ETipoMensagem tipo)
        {
            return _mensagens.Where(m => m.Tipo == tipo).ToList();
        }

        public string ObterMensagensPorExtenso()
        {
            return String.Join(" | ", _mensagens.Select(m => m.Texto));
        }

        public abstract void EstadoValido();
    }
}