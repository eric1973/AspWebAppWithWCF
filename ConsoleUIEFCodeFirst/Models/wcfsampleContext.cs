using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ConsoleUIEFCodeFirst.Models.Mapping;

namespace ConsoleUIEFCodeFirst.Models
{
    public partial class wcfsampleContext : DbContext
    {
        static wcfsampleContext()
        {
            Database.SetInitializer<wcfsampleContext>(null);
        }

        public wcfsampleContext()
            : base("Name=wcfsampleContext")
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonMap());
        }
    }
}
