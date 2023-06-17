using HotelReservation.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservation.Data.Concrete
{
    public interface IGenericRepository
    {
        Task BeginTransactionAsync();
        Task RollbackTransactionAsync();
        Task CommitTransactionAsync();
        Task SaveChangesAsync();

        Task<T> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : class, new();
        Task<T> GetByIdAsync<T>(int HotelId, int id) where T : class, new();
        Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        IQueryable<T> Where<T>(Expression<Func<T, bool>> predicate) where T : class, new();
        Task<bool> AnyAsync<T>(Expression<Func<T, bool>> predicate) where T : class, new();
        Task AddAsync<T>(T entity) where T : class, new();
        Task UpdateAsync<T>(int HotelId, int userId, T entity) where T : Entity, new();
        void Remove<T>(T entity) where T : class, new();
    }
}
