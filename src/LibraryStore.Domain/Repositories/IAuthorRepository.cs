using LibraryStore.Domain.Entities;
using LibraryStore.Domain.Models.DTO.Author;

namespace LibraryStore.Domain.Repositories
{
    public interface IAuthorsRepository : IGenericRepository<Author>
    {
        Task<AuthorDetailsDto> GetAuthorDetailsAsync(int id);
    }
}
