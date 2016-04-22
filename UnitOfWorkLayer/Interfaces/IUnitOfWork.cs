using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkLayer.Repositories;

namespace UnitOfWorkLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        PersonRepository PersonRepository { get; }
        PersonOrdersRepository PersonOrdersRepository { get; }
        void Save();
    }
}
