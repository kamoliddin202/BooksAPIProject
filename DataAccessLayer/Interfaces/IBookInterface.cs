using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface IBookInterface : IRepasitory<Book>
    {
        Task<IEnumerable<Book>> GetBooksWithCategory(int categoryId);
    }
}
