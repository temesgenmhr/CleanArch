using CleanArch.Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persistance.Repositories
{
   public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly AppDbContext _appDbContext;

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsnc(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _appDbContext.Set<T>().FindAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsnc()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsnc(T entity)
        {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}
