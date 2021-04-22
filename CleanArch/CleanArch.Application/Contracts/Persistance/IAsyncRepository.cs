using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Contracts.Persistance
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsnc();
        Task<T> AddAsync(T entity);
        Task UpdateAsnc(T entity);
        Task DeleteAsnc(T entity);
    }
}
