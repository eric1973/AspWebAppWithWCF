using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkLayer.Interfaces;
using UnitOfWorkLayer.Models;

namespace UnitOfWorkLayer.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private WCFSampleDb dbContext;
        private DbSet<Person> dbSet;

        public PersonRepository(WCFSampleDb dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<Person>();
        }
        public IEnumerable<Person> List
        {
            get
            {
                return dbSet.AsEnumerable();
            }
        }

        public void Add(Person entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Person entity)
        {
            throw new NotImplementedException();
        }

        public Person FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
