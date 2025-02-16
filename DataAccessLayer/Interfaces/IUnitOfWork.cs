namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryInterface categoryInterface {  get; } 
        IBookInterface bookInterface { get; }
        Task SaveChangesAsync();
    }
}
