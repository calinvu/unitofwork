namespace UnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        string ConnectionString { get; set; }
        IUnitOfWork CreateUnitOfWork();
    }
}