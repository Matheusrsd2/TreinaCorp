using System;
using System.Collections.Generic;
using TreinaCorp.Repository;
using TreinaCorp.Repository.Interfaces;

public class Repository <T>: IRepository <T> where T: class
{

   public AppDbContext _context;
	public Repository(AppDbContext context)
	{
       _context = context;

	}

    List<TEntity> GetAll()
    {
        
    }
    TEntity GetById(int id);

    List<T> IRepository<T>.GetAll()
    {
        throw new NotImplementedException();
    }

    T IRepository<T>.GetById(int id)
    {
        throw new NotImplementedException();
    }

    Add(TEntity entity);
    Update(TEntity entity);
    Delete(int id);

    

}
