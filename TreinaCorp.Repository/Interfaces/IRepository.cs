using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TreinaCorp.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
