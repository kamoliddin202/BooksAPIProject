using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface ICategoryInterface : IRepasitory<Category>
    {
        Task<IEnumerable<Category>> GetCategoryWithBooks();
    }
}
