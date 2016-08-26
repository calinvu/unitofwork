using System.Data.Entity;
using System.Linq;

namespace UnitOfWork.EntityFramework
{
    public class GenericRepository<T> : IRepository<T> where T: class
    {
        private readonly DbContext _session = null;

        public GenericRepository(DbContext session)
        {
            _session = session;
        }

        public IQueryable<T> Linq()
        {
            return _session.Set<T>().AsQueryable();
        }

        public void Save(T entity)
        {          
            if (_session.Set<T>().Local.All(e => e != entity))
                _session.Set<T>().Add(entity);

            _session.SaveChanges();
        }

        public void Delete(T entity)
        {
            _session.Set<T>().Remove(entity);
        }
    }
}
