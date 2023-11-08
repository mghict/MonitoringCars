using Common.Data;
using Microsoft.EntityFrameworkCore;
using Moneyon.Common.Data;
using Moneyon.Common.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppRepository<TEntity,TId> : Moneyon.Common.Data.SqlServer.SqlServerGenericRepository<TEntity, TId>, IAppRepository<TEntity, TId>
        where TEntity : Common.CommonModels.BaseEntity<TId>
    {
        private readonly DbContext context;

        public AppRepository(DbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
