using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreinaCorp.Repository;
using TreinaCorp.Repository.Interfaces;

namespace TreinaCorp.Repository.Classes
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _contexto;

        public Repository(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public List<T> GetAll()
        {
            try
            {
                return _contexto.Set<T>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public T GetById(int id)
        {
            try
            {
                return _contexto.Set<T>().Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Add(T entity)
        {
            try
            {
                _contexto.Add(entity);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(T entity)
        {
            try
            {
                var update = _contexto.Set<T>().Update(entity);
                update.State = EntityState.Modified;
                _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var entity = this.GetById(id);
                _contexto.Set<T>().Remove(entity);
                _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
