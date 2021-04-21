using System;
using System.Collections.Generic;

namespace TreinaCorp.Domain
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataCadastro { get; set; }
        public string TempoDuracao { get; set; }
        public string Imagem { get; set; }
        public int CategoriaId { get; set; }
        public Categoria categoria { get; set; }
        public virtual List<Aula> Aulas { get; set; }
    }
}