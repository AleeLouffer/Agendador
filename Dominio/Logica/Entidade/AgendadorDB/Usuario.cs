using Dominio.Arquitetura;

namespace Dominio.Logica.Entidade.AgendadorDB
{
    public class Usuario : EntidadeBase
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public string CPF { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Senha { get; private set; } = string.Empty;
        public DateTime DataDeAcesso { get; private set; }
        public string Situacao { get; private set; } = string.Empty;

        public override void EstadoValido()
        {
            throw new NotImplementedException();
        }
    }
}
