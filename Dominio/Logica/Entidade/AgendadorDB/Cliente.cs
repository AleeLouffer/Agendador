namespace Dominio.Logica.Entidade.AgendadorDB
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Situacao { get; set; } = string.Empty;

        public Empresa Empresa { get; set; }
    }
}
