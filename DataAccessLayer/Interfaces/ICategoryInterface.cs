using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface ICategoryInterface
    {
        Task<IEnumerable<Category>> GetCategoryWithBooks();
    }
}
