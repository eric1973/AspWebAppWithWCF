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
    public class PersonOrdersRepository : IRepository<PersonOrders>
    {
        private WCFSampleDb dbContext;
        private DbSet<PersonOrders> dbSet;

        public PersonOrdersRepository(WCFSampleDb dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<PersonOrders>();
        }
        public IEnumerable<PersonOrders> List
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(PersonOrders entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PersonOrders entity)
        {
            throw new NotImplementedException();
        }

        public PersonOrders FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(PersonOrders entity)
        {
            throw new NotImplementedException();
        }
    }
}
