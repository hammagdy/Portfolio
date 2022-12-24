namespace Core.Interfaces
{
    public interface IUnitOfWorkT<T> where T : class
    {
        IGenericRepository<T> Entity { get; }
        void Save();
    }
}
