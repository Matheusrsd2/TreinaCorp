using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using TreinaCorp.Domain;
using TreinaCorp.Repository.Interfaces;

namespace TreinaCorp.Repository.Classes
{

    public class CursoRepository : Repository<Curso>//, IRepository<Curso>
    {
        private readonly AppDbContext _context;

        public CursoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Curso> GetCursoAndAulas(int id)
        {
            IQueryable<Curso> curso = _context.Cursos.Where(x => x.Id == id).Include(x => x.Aulas);

            return curso;
        }


    }
}
