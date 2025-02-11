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
    public class CategoryRepasitory : Repasitory<Category>, ICategoryInterface
    {
        public CategoryRepasitory(AppDbContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Category>> GetCategoryWithBooks()
        {
            throw new NotImplementedException();
        }
    }
}
