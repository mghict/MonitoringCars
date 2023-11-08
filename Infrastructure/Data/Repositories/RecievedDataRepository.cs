using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class RecievedDataRepository : AppRepository<RecievedData, Guid>,IRecievedDataRepository
    {
        private readonly AppDbContext context;
        public RecievedDataRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }
        
    }
}
