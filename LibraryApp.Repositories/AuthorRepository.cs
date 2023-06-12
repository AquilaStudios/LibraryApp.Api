using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.DataAccess;
using LibraryApp.Repositories.Interfaces;

namespace LibraryApp.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(IDbContext context) : base(context)
        {
            
        }

        public string? GetAuthorNameById(int id)
        {
            var author = GetById(id);

            return author?.Name;
        }

    }
}
