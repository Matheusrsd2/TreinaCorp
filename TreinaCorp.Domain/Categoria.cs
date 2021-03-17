using System;
using System.Collections.Generic;
using System.Text;

namespace TreinaCorp.Domain
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public List<Curso> Cursos { get; set; }
    }
}
