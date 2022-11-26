using DAL.Repository;
using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class GenericService<TEntity> : Repository<TEntity>, IGenericService<TEntity>
        where TEntity : BaseEntity, new()
    {
        public GenericService(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
    }
}
