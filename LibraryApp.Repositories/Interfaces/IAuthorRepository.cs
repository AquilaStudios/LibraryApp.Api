using LibraryApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories.Interfaces
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {

        public string? GetAuthorNameById(int id);

    }
}
