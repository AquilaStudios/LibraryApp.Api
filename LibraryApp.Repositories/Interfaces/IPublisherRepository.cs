using LibraryApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories.Interfaces
{
    public interface IPublisherRepository : IRepositoryBase<Publisher>
    {

        public string? GetPublisherNameById(int id);

    }
}

