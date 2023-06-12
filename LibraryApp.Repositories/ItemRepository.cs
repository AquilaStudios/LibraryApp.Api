using LibraryApp.DataAccess;
using LibraryApp.Repositories.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {

        public ItemRepository(IDbContext context) : base(context)
        {

        }



    }
}
