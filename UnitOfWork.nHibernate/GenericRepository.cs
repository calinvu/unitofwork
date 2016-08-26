using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace UnitOfWork.nHibernate
{
    public class GenericRepository<T> : IRepository<T>
    {
        private readonly ISession _session = null;

        public GenericRepository(ISession session)
        {
            _session = session;
        }

        public IQueryable<T> Linq()
        {
            return _session.Query<T>().AsQueryable();
        }

        public void Save(T entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public void Delete(T entity)
        {
            _session.Delete(entity);
        }
    }
}
