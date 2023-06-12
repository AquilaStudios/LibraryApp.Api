using LibraryApp.DataAccess;
using LibraryApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public class CustomerContactRepository : RepositoryBase<CustomerContact>, ICustomerContactRepository
    {
        
        public CustomerContactRepository(IDbContext context) : base(context)
        {

        }

    }
}
