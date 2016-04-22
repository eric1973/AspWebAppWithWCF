using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkLayer.Interfaces
{
    interface IRepository<TEntity> where TEntity:class
    {
        IEnumerable<TEntity> List { get; }
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity FindById(int Id);
    }
}
