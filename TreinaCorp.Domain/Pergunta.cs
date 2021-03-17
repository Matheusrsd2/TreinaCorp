using System;
using System.Collections.Generic;

namespace TreinaCorp.Domain
{
    public class Pergunta
    {
        public int Id { get; set; }
        public string Enunciado { get; set; }
        public string Imagem1 { get; set; }
        public DateTime Data { get; set; }
        public int? QuestionarioId { get; set; }
        public Questionario Questionario { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Resposta> Respostas { get; set; }
    }
}