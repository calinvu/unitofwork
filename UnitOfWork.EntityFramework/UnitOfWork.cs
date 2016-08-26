using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UnitOfWork.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext Session { get; set; }
        private DbContextTransaction Transaction { get; set; }

        public UnitOfWork(string connectionString)
        {
            //TODO: add injectable generic factory for creating the session 
            
            Session = new DbContext(connectionString);
            Transaction = null;//new DbContextTransaction(Session);
        }

        public IRepository<T> Repository<T>() where T : class
        {
            return new GenericRepository<T>(Session);
        }

        public IList<T> RunSqlQuery<T>(string queryString) where T : class
        {
            return Session.Set<T>().SqlQuery(queryString).ToList();
        }

        public void Commit()
        {
            //if (!Transaction.IsActive)
            //{
            //    throw new InvalidOperationException("No active transaction");
            //}
            //Transaction.Commit();
        }

        public void Rollback()
        {
            //if (Transaction.IsActive)
            //{
            //    Transaction.Rollback();
            //}
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (Session == null)
            {
                return;
            }

            Session.Dispose();
            Session = null;
        }        
    }
}
