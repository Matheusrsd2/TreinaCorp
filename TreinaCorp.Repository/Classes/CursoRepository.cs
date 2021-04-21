using System;
using System.Collections.Generic;
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
    }
}
