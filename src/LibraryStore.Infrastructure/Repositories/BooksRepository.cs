using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStoreApp.API.Repositories;
using LibraryStore.Domain.Entities;
using LibraryStore.Domain.Models.DTO.Book;
using LibraryStore.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LibraryStore.Domain.Repositories
{
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        private readonly BookStoreDbContext context;
        private readonly IMapper mapper;

        public BooksRepository(BookStoreDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<BookReadOnlyDto>> GetAllBooksAsync()
        {
            return await context.Books
                .Include(q => q.Author)
                .ProjectTo<BookReadOnlyDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<BookDetailsDto> GetBookAsync(int id)
        {
            return await context.Books
                .Include(q => q.Author)
                .ProjectTo<BookDetailsDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
