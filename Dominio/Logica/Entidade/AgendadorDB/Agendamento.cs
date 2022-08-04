namespace Dominio.Logica.Entidade.AgendadorDB
{
    public class Agendamento
    {
        public int Id { get; set; }
        public DateOnly DataDoAgendamento { get; set; }
        public TimeOnly HoraDoAgendamento { get; set; }
        public string Situacao { get; set; } = string.Empty;

        public Servico Servico { get; set; }
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public Empresa Empresa { get; set; }
    }
}
