using System.Linq;

namespace UnitOfWork
{
    public interface IRepository<T>
    {
        IQueryable<T> Linq();
        void Save(T entity);
        void Delete(T entity);
    }
}
