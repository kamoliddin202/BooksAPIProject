using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Repasitories
{
    public class BookRepasitory : Repasitory<Book>, IBookInterface
    {
        public BookRepasitory(AppDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Book>> GetBooksWithCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
