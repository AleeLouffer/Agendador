using Dominio.Arquitetura;

namespace Dominio.Logica.Entidade.AgendadorDB
{
    public class Empresa : EntidadeBase
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; } = string.Empty;
        public string NomeFantasia { get; set; } = string.Empty;
        public string CPNJ { get; set; } = string.Empty;    

        public override void EstadoValido()
        {
            throw new NotImplementedException();
        }
    }
}
