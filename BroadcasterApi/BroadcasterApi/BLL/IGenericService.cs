using DAL.Repository;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface IGenericService<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
    }
}
