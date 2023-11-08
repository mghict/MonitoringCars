using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Repositories;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        private IRecievedDataRepository recievedDataRepository;
        public IRecievedDataRepository RecievedDataRepository => 
            recievedDataRepository = recievedDataRepository ?? new RecievedDataRepository(context);

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
