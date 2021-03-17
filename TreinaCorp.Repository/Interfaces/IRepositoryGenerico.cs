using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TreinaCorp.Repository.Interfaces
{
    public interface IRepositoryGenerico<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> GetById(string id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
    }
}
