using System;
using System.Collections.Generic;
using NHibernate;

namespace UnitOfWork.nHibernate
{
    public class UnitOfWork : IUnitOfWork
    {
        private ISession Session { get; set; }
        private ITransaction Transaction { get; set; }

        public UnitOfWork(string connectionString)
        {
            //TODO: add injectable generic factory for creating the session 
            //Session = DataAccessConfiguration.CreateSessionFactory(connectionString).OpenSession();
            Session.FlushMode = FlushMode.Commit;
            Transaction = Session.BeginTransaction();
        }

        public IRepository<T> Repository<T>()
        {
            return new GenericRepository<T>(Session);
        }

        public IList<T> RunSqlQuery<T>(string queryString)
        {
            return Session.CreateSQLQuery(queryString).List<T>();
        }

        public void Commit()
        {
            if (!Transaction.IsActive)
            {
                throw new InvalidOperationException("No active transaction");
            }
            Transaction.Commit();
        }

        public void Rollback()
        {
            if (Transaction.IsActive)
            {
                Transaction.Rollback();
            }
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
