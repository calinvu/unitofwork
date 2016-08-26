using System;
using System.Collections.Generic;

namespace UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IList<T> RunSqlQuery<T>(string queryString);
        IRepository<T> Repository<T>();
        void Commit();
        void Rollback();
    }
}