using LibraryApp.DataAccess;
using LibraryApp.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public class ItemTypeRepository : RepositoryBase<ItemType>, IItemTypeRepository
    {
        public ItemTypeRepository(IDbContext context) : base(context)
        {

        }

        public string? GetItemTypeById(int id)
        {
            var itemType = GetById(id);

            return itemType?.Type;
        }


    }
}
