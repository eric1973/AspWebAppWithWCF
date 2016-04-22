namespace UnitOfWorkLayer.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WCFSampleDb : DbContext
    {
        public WCFSampleDb()
            : base("name=WCFSampleDbContext")
        {
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonOrders> PersonOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PersonOrders)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PersonOrders>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<PersonOrders>()
                .Property(e => e.notes)
                .IsUnicode(false);
        }
    }
}
