using System;
using System.Collections.Generic;
using System.Text;

namespace TreinaCorp.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List <TEntity> GetAll();
        TEntity GetById(int id);
        Add(TEntity entity);
        Update(TEntity entity);
        Delete(int id);
    }
}
