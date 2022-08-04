namespace Comuns.Logica
{
    using Enums;

    public class Mensagem
    {
        public Mensagem() { }

        public Mensagem(string texto, ETipoMensagem tipo)
        {
            Texto = texto;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return Texto;
        }

        public string Texto { get; set; } = string.Empty;
        public ETipoMensagem Tipo { get; set; }
    }
}