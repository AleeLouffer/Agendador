using Dominio.Arquitetura;

namespace Dominio.Logica.Entidade.AgendadorDB
{
    public class Usuario : EntidadeBase
    {
        public Usuario() { }

        public Usuario(string nome, string cpf, string email, string senha)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            Senha = senha;
            DataDeAcesso = DateTime.Now;
            Situacao = "A";
        }

        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string CPF { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Senha { get; private set; } = string.Empty;
        public DateTime DataDeAcesso { get; private set; }
        public string Situacao { get; private set; } = string.Empty;

        internal void AlterarSenha(string novaSenha, string confirmacaoNovaSenha)
        {
            if(novaSenha == confirmacaoNovaSenha)
            {
                Senha = novaSenha;
                return;
            }
            AdicionarMensagemErro("As senhas não conferem");
        }

        public override void EstadoValido()
        {
            if (string.IsNullOrWhiteSpace(Nome)) throw new Exception("O Nome do usuario não pode estar vazio");
            if (string.IsNullOrWhiteSpace(CPF)) throw new Exception("O Usuario deve possuir um CPF");
            if (string.IsNullOrEmpty(Email)) throw new Exception("O Usuario deve ter um e-mail para se cadastrar");
            if (string.IsNullOrWhiteSpace(Senha)) throw new Exception ("O Usuario deve possuir uma senha");
            if (DataDeAcesso == DateTime.MinValue) throw new Exception("O Usuario deve ter uma data de acesso");
            if (string.IsNullOrWhiteSpace(Situacao)) throw new Exception("O Usuario deve ter uma situação");
        }
    }
}
