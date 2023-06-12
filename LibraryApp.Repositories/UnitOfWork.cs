using LibraryApp.DataAccess;
using LibraryApp.Repositories.Interfaces;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _context;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICustomerContactRepository _customerContactRepository;
        private readonly IContactTypeRepository _contactTypeRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IConditionRepository _conditionRepository;
        private readonly IItemTypeRepository _itemTypeRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IPublisherRepository _publisherRepository;

        public UnitOfWork (IDbContext context)
        {
            _context = context;
            _authorRepository = new AuthorRepository (_context);
            _publisherRepository = new PublisherRepository (_context);
            _customerContactRepository = new CustomerContactRepository (_context);
            _contactTypeRepository = new ContactTypeRepository (_context);
            _customerRepository = new CustomerRepository (_context);
            _categoryRepository = new CategoryRepository (_context);
            _conditionRepository = new ConditionRepository (_context);
            _itemTypeRepository = new ItemTypeRepository (_context);
            _itemRepository = new ItemRepository (_context);

        }


        public IAuthorRepository Authors { get => _authorRepository; }

        public IPublisherRepository Publishers { get => _publisherRepository; }

        public ICustomerContactRepository CustomerContacts { get => _customerContactRepository; }

        public IContactTypeRepository ContactTypes { get => _contactTypeRepository; }

        public ICustomerRepository Customers { get => _customerRepository; }

        public ICategoryRepository Categories { get => _categoryRepository; }

        public IConditionRepository Conditions { get => _conditionRepository; }

        public IItemTypeRepository ItemTypes { get => _itemTypeRepository; }

        public IItemRepository Items { get => _itemRepository; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
