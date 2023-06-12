using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace LibraryApp.DataAccess
{
    public partial class BookHiveContext : DbContext, IDbContext
    {
        public BookHiveContext()
        {

        }

        public BookHiveContext(DbContextOptions<BookHiveContext> options) : base(options) 
        {
            
        }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Condition> Conditions { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerContact> CustomerContacts { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemHistory> ItemHistories { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public override EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return base.Entry(entity);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Condition>(entity =>
            {
                entity.ToTable("Condition");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.ToTable("ContactType");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerContact>(entity =>
            {
                entity.ToTable("CustomerContact");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerContacts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCustomerContactCustomerId");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.CustomerContacts)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkCustomerContactTypeId");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.DeweyDecimal)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ISBN)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.PublicationDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkItemAuthorId");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkItemCategoryId");

                entity.HasOne(d => d.Condition)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkItemConditionId");

                entity.HasOne(d => d.ItemType)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ItemTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkItemTypeId");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkItemPublisherId");
            });

            modelBuilder.Entity<ItemHistory>(entity =>
            {
                entity.ToTable("ItemHistory");

                entity.Property(e => e.CheckIn).HasColumnType("datetime");

                entity.Property(e => e.CheckOut).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Fines).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.LateFees).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Notes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ItemHistories)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FkItemHistoryCustomerId");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemHistories)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKItemHistoryItemId");
            });

            modelBuilder.Entity<ItemType>(entity =>
            {
                entity.ToTable("ItemType");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("Publisher");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}