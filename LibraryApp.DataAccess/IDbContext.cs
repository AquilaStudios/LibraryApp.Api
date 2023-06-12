using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LibraryApp.DataAccess
{
    public interface IDbContext : IDisposable
    {

        DbSet<Author> Authors { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerContact> CustomerContacts { get; set; }
        DbSet<ContactType> ContactTypes { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<ItemHistory> ItemHistories { get; set; }
        DbSet<Condition> Conditions { get; set; }
        DbSet<ItemType> ItemTypes { get; set; }
        DbSet<Publisher> Publishers { get; set; }

        int SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;


        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
