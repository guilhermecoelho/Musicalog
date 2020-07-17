using Musicalog_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musicalog_Domain.Services
{
    public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositoryBase;

        public ServiceBase(IRepositoryBase<T> repositoryBase)

        {
            _repositoryBase = repositoryBase;
        }

        public T Add(T obj)
        {
           return  _repositoryBase.Add(obj);

        }

        public void Dispose()
        {
            _repositoryBase.Dispose();
        }

        public IEnumerable<T> GetAll()
        {
            return _repositoryBase.GetAll();
        }

        public T GetById(long id)
        {
            return _repositoryBase.GetById(id);
        }

        public void Remove(T obj)
        {
            _repositoryBase.Remove(obj);
        }

        public T Update(T obj)
        {
            return _repositoryBase.Update(obj);
        }
    }
}

