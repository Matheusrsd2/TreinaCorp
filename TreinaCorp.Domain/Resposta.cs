namespace TreinaCorp.Domain
{
    public class Resposta
    {
        public int Id { get; set; }
        public string RespostaTexto { get; set; }
        public int PerguntaId { get; set; }
        public Pergunta Pergunta { get; set; }
    }
}