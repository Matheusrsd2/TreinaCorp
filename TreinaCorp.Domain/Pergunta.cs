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
        public int? AvalicacoesId { get; set; }
        public Avaliacao Avalicacoes { get; set; }
        public List<Resposta> Respostas { get; set; }
    }
}