using System;
using System.Collections.Generic;

namespace TreinaCorp.Domain
{
    public class Aula
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string VideoAula { get; set; }
        public string Duracao { get; set; }
        public string Comentario { get; set; }
        public DateTime DataCadastro { get; set; }
        public int? CursoId { get; set; }
        public virtual Curso Curso { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
  
}