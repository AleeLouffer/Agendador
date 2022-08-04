namespace Dominio.Logica.Entidade.AgendadorDB
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string Situacao { get; set; } = string.Empty;

        public Empresa Empresa { get; set; }
    }
}
