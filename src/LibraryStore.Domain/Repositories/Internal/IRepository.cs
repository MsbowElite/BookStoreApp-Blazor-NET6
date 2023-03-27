using LibraryStore.Domain.Models;

namespace LibraryStore.Domain.Repositories.Internal
{
    public interface IRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }

        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
        Task<List<T>> GetAllAsync();
        Task<VirtualizeResponse<TResult>> GetAllAsync<TResult>(QueryParameters queryParam) where TResult : class;
        Task<T> GetAsync(int? id);
        Task UpdateAsync(T entity);
    }
}
