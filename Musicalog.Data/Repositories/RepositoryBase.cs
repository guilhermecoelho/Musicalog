using Microsoft.EntityFrameworkCore;
using Musicalog.Data.Config;
using Musicalog_Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Musicalog.Data.Repositories
{
    public class RepositoryBase<T> : IDisposable, IRepositoryBase<T> where T : class
    {
        protected ContextBase db = new ContextBase();

        public T Add(T obj)
        {
            db.Set<T>().Add(obj);
            db.SaveChanges();

            return obj;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().AsNoTracking();
        }

        public T GetById(long id)
        {
            return db.Set<T>().Find(id);
        }

        public T Remove(T obj)
        {
            db.Set<T>().Remove(obj);
            db.SaveChanges();

            return obj;
        }

        public T Update(T obj)
        {
            using(ContextBase db = new ContextBase())
            {
                db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                return obj;
            }
           
        }
    }
}
