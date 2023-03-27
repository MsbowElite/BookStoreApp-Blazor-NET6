using LibraryStore.Domain.Models.DTO.Book;

namespace LibraryStore.Domain.Models.DTO.Author
{
    public class AuthorDetailsDto : AuthorReadOnlyDto
    {
        public List<BookReadOnlyDto> Books { get; set; }
    }
}
