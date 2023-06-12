using LibraryApp.DataAccess;
using LibraryApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
    {

        public PublisherRepository(IDbContext context) : base(context)
        {

        }

        public string? GetPublisherNameById(int id)
        {
            var publisher = GetById(id);

            return publisher?.Name;
        }
    }
}
