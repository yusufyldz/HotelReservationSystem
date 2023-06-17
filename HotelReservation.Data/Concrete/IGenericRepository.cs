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
        Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class;
        Task AddAsync<T>(T entity) where T : class, new();
        Task UpdateAsync<T>(int HotelId, int userId, T entity) where T : Entity, new();
        Task Remove<T>(T entity) where T : class, new();
            }
}
