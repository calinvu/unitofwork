namespace UnitOfWork.EntityFramework
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public string ConnectionString { get; set; }

        public UnitOfWorkFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork(ConnectionString);
        }
    }
}
