using DataAccess.Data;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public ApplicationDbContext _db;
        public DbSet<T> _dbSet;
        public GenericRepository( ApplicationDbContext context)
        {
            _db = context;
            _dbSet = context.Set<T>();
        }
        public async Task Delete(object id)
        {
            T entity=await _dbSet.FindAsync(id);
            if (entity != null)
            {
                 _dbSet.Remove(entity);
            }
        }

        public async Task<T> GetById(object id)
        {

            //return _dbSet.AsNoTracking().FirstOrDefault(x=>x.Id==id);
            return await _dbSet.FindAsync(id);
            
        }


        public async Task Update(T entity)
        {
            // _dbSet.Update(entity);
            var idProperty = typeof(T).GetProperty("Id");
            long id = 0;
            if (idProperty != null)
            {
                id = (long)idProperty.GetValue(entity);
            }
            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity != null)
            {
                _db.Entry(existingEntity).CurrentValues.SetValues(entity);
            }

            // _db.Update(entity);
        }
        public async Task Save()
        {
           await _db.SaveChangesAsync();
        }
    }
}
