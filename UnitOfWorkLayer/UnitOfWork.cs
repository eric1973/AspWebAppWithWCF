using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkLayer.Interfaces;
using UnitOfWorkLayer.Models;
using UnitOfWorkLayer.Repositories;

namespace UnitOfWorkLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private WCFSampleDb dbContext = new WCFSampleDb();
        private PersonRepository personRepository;
        private PersonOrdersRepository personOrdersRepository;

        public PersonRepository PersonRepository {
            get
            {
                if (personRepository == null)
                {
                    personRepository = new PersonRepository(dbContext);
                }

                return personRepository;
            }
        }

        public PersonOrdersRepository PersonOrdersRepository
        {
            get
            {
                if (personOrdersRepository == null)
                {
                    personOrdersRepository = new PersonOrdersRepository(dbContext);
                }

                return personOrdersRepository;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }

}
