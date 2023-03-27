using AutoMapper;
using BookStoreApp.API.Endpoints.Internal;
using BookStoreApp.API.Models.Book;
using LibraryStore.Domain.Entities;
using LibraryStore.Domain.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreApp.API.Endpoints
{
    public class BookEndpoints : IEndpoints
    {
        private const string ContentType = "application/json";
        private const string Tag = "Books";
        private const string BaseRoute = "books";

        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBooksRepository, BooksRepository>();
        }

        public static void DefineEndpoints(IEndpointRouteBuilder app)
        {
            app.MapPost(BaseRoute, CreateBookAsync)
                //.RequireAuthorization("Administrator")
                .WithName("CreateBook")
                .Accepts<BookCreateDto>(ContentType)
                .Produces<Book>(201)
                .Produces<IEnumerable<ValidationFailure>>(400)
                .WithTags(Tag);
        }

        internal static async Task<IResult> CreateBookAsync(
            BookCreateDto bookDto, IMapper mapper, IBooksRepository booksRepository)
        {
            var book = mapper.Map<Book>(bookDto);
            await booksRepository.AddAsync(book);

            return Results.Created($"/{BaseRoute}/{book.Isbn}", book);
        }
    }
}
