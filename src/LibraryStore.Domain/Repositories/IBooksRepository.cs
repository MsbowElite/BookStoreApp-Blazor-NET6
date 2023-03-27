using LibraryStore.Domain.Entities;
using LibraryStore.Domain.Models.DTO.Book;

namespace LibraryStore.Domain.Repositories
{
    public interface IBooksRepository : IGenericRepository<Book>
    {
        Task<BookDetailsDto> GetBookAsync(int id);
        Task<List<BookReadOnlyDto>> GetAllBooksAsync();
    }
}
