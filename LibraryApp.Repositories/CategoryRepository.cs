using LibraryApp.DataAccess;
using LibraryApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbContext context) :base(context)
        {

        }

        public string? GetCategoryNameById(int id)
        {
            var category = GetById(id);

            return category?.Name;
        }

    }
}
