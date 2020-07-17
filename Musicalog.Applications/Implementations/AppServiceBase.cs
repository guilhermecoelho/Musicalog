using Musicalog.Applications.Interfaces;
using Musicalog_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musicalog.Applications
{
    public class AppServiceBase<T> : IAppServiceBase<T> where T : class
    {

        private readonly IServiceBase<T> _serviceBase;

        public AppServiceBase(IServiceBase<T> serviceBase)

        {
            _serviceBase = serviceBase;
        }

        public T Add(T obj)
        {
            return _serviceBase.Add(obj);
        }

        public IEnumerable<T> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public T GetById(long id)
        {
            return _serviceBase.GetById(id);
        }

        public T Remove(T obj)
        {
            _serviceBase.Remove(obj);

            return obj;
        }

        public T Update(T obj)
        {
            return _serviceBase.Update(obj);
        }
    }
}
