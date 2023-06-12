using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository Authors { get ; }

        IPublisherRepository Publishers { get ; }

        ICustomerContactRepository CustomerContacts { get ; }

        IContactTypeRepository ContactTypes { get ; }

        ICustomerRepository Customers { get ; }

        ICategoryRepository Categories { get ; }

        IConditionRepository Conditions { get ; }

        IItemTypeRepository ItemTypes { get ; }

        IItemRepository Items { get ; }

        void Complete();

    }
}
