using System;
using System.Collections.Generic;
using System.Text;

namespace TreinaCorp.Domain
{
    public class Questionario
    {
        public int Id { get; set; }
        public string Descricao { get; set; } 
        public int TotalPerguntas { get; set; }
        public int TotalRespostasCertas { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Pergunta> Perguntas { get; set; }
    }
}
