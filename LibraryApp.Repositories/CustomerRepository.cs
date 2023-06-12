using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Repositories.Interfaces;
using LibraryApp.DataAccess;

namespace LibraryApp.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
       
        public CustomerRepository(IDbContext context) : base(context)
        {

        }



    }
}