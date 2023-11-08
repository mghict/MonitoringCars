using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();

        //--------------------------------------

        public IRecievedDataRepository RecievedDataRepository { get; }
    }
}
