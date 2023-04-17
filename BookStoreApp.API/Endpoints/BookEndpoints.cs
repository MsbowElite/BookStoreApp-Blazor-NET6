using BookStoreApp.API.Endpoints.Internal;
using BookStoreApp.API.Models.Book;
using LibraryStore.CrossCutting.Utils.Notification;
using LibraryStore.Domain.Commands.Book;
using LibraryStore.Domain.Entities;
using LibraryStore.Domain.Repositories;
using MediatR;
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
                .RequireAuthorization("Administrator")
                .WithName("CreateBook")
                .Accepts<AddBookCommand>(ContentType)
                .Produces<Book>(201)
                .Produces<IEnumerable<ValidationFailure>>(400)
                .WithTags(Tag);
        }

        internal static async Task<IResult> CreateBookAsync(AddBookCommand addBookCommand, IMediator mediator)
        {
            var response = await mediator.Send(addBookCommand);
            if (response is SuccessfulOperation<BookCreateDto> successfulOperation)
            {
                return Results.Created($"/{BaseRoute}/{successfulOperation.Data.Isbn}", successfulOperation.Data);
            }

            return Results.NoContent();
        }
    }
}
