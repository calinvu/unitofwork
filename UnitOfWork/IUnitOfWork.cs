using System;
using System.Collections.Generic;

namespace UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IList<T> RunSqlQuery<T>(string queryString) where T : class;
        IRepository<T> Repository<T>() where T : class;
        void Commit();
        void Rollback();
    }
}