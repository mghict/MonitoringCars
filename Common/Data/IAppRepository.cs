using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data;

public interface IAppRepository<TEntity,TId>:Moneyon.Common.Data.IGenericRelationalRepository<TEntity,TId>
    where TEntity : CommonModels.BaseEntity<TId>
{
}
