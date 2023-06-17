using HotelReservation.Data.Concrete;
using HotelReservation.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Data.Abstract
{
    public class GenericRepository : IGenericRepository
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext appContext) 
        {

            _context = appContext;

        }
        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            if (_context.Database.CurrentTransaction != null)
                await _context.Database.RollbackTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (await _context.Database.CanConnectAsync())
            {
                await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {
            return predicate != null
                ? await _context.Set<T>().AsNoTracking().Where(predicate).AsNoTracking().ToListAsync()
                : await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : class, new()
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(predicate);
        }


        public async Task AddAsync<T>(T entity) where T : class, new()
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task UpdateAsync<T>(int HotelId, int userId, T entity) where T : Entity, new()
        {
             _context.Set<T>().Update(entity);
        }

        public async Task Remove<T>(T entity) where T : class, new()
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
