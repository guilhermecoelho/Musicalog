using System;
using System.Collections.Generic;
using System.Text;

namespace Musicalog_Domain.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        T Add(T obj);
        T GetById(long id);
        IEnumerable<T> GetAll();
        T Update(T obj);
        T Remove(T obj);
        void Dispose();

    }
}
