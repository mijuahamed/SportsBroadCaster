using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly DatabaseContext _databaseContext;
        public Repository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public virtual async Task<(bool result, string message, string error, TEntity data)> Insert(TEntity model)
        {
            try
            {
                _databaseContext.Set<TEntity>().Add(model);
                await _databaseContext.SaveChangesAsync();
                return (true, "Data Insersted Successfully", null, model);
            }
            catch (Exception ex)
            {
                return (false, "Something Went Worng", ex.Message.ToString(),null);
            }
        }
        public virtual async Task<(bool result, string message, string error)> InsertRange(List<TEntity> model)
        {
            try
            {
                _databaseContext.Set<TEntity>().AddRange(model);
                await _databaseContext.SaveChangesAsync();
                return (true, "Set of Data Insersted Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, "Something Went Worng", ex.Message.ToString());
            }
        }
        public virtual async Task<(bool result, string message, string error)> Update(TEntity model)
        {
            try
            {
                _databaseContext.Set<TEntity>().Update(model);
                await _databaseContext.SaveChangesAsync();
                return (true, "Data Updated Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, "Something Went Worng", ex.Message.ToString());
            }
        }
        public virtual async Task<(bool result, string message, string error)> Delete(TEntity model)
        {
            try
            {
                _databaseContext.Set<TEntity>().Remove(model);
                await _databaseContext.SaveChangesAsync();
                return (true, "Data Deleted Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, "Something Went Worng", ex.Message.ToString());
            }
        }
        public virtual async Task<(bool result, string message, string error)> DeleteRange(List<TEntity> model)
        {
            try
            {
                _databaseContext.Set<TEntity>().RemoveRange(model);
                await _databaseContext.SaveChangesAsync();
                return (true, "Data Deleted Successfully", null);
            }
            catch (Exception ex)
            {
                return (false, "Something Went Worng", ex.Message.ToString());
            }
        }
        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> expression)
        {

            var list = _databaseContext.Set<TEntity>().Where(expression).AsNoTracking();
            return list;

        }
        public virtual async Task<TEntity> GetEntity(Expression<Func<TEntity, bool>> expression)
        {
            var model = await _databaseContext.Set<TEntity>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
            return model;
        }
        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            var list = new List<TEntity>();
            if (expression != null)
                list = await _databaseContext.Set<TEntity>().Where(expression).AsNoTracking().ToListAsync();
            else
                list = await _databaseContext.Set<TEntity>().AsNoTracking().ToListAsync();
            return list;
        }
        public IQueryable<TEntity> Get()
        {
            var model = _databaseContext.Set<TEntity>().AsNoTracking();
            return model;
        }
    }
}
