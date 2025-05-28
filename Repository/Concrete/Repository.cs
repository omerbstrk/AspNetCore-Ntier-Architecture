using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using Data.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;


namespace Repository.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity
    {
        private readonly Context _context;
        private readonly DbSet<T> _dbSet;

        public Repository(Context context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> List()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Status(int id)
        {
            var value = await _dbSet.FindAsync(id);
            if (value == null)
                return false;

            var statusProp = typeof(T).GetProperty("status");
            if (statusProp != null && statusProp.PropertyType == typeof(bool))
            {
                var currentStatus = (bool)statusProp.GetValue(value);
                statusProp.SetValue(value, !currentStatus);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
