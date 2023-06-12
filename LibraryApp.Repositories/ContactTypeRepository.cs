using LibraryApp.DataAccess;
using LibraryApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public class ContactTypeRepository : RepositoryBase<ContactType>, IContactTypeRepository
    {

        public ContactTypeRepository(IDbContext context) : base(context)
        {

        }


    }
}
