using AutoMapper;
using BookStoreApp.API.Data;
using BookStoreApp.API.Endpoints.Internal;
using BookStoreApp.API.Models.Author;
using BookStoreApp.API.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreApp.API.Endpoints
{
    public class AuthorEndpoints : IEndpoints
    {
        private const string ContentType = "application/json";
        private const string Tag = "Authors";
        private const string BaseRoute = "authors";

        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
        }

        public static void DefineEndpoints(IEndpointRouteBuilder app)
        {
            app.MapPost(BaseRoute, CreateAuthorAsync)
                //.RequireAuthorization("Administrator")
                .WithName("CreateAuthor")
                .Accepts<AuthorCreateDto>(ContentType)
                .Produces<Author>(201)
                .Produces<IEnumerable<ValidationFailure>>(400)
                .WithTags(Tag);
        }

        internal static async Task<IResult> CreateAuthorAsync(
            AuthorCreateDto authorDto, IMapper mapper, IAuthorsRepository authorsRepository)
        {
            var author = mapper.Map<Author>(authorDto);
            await authorsRepository.AddAsync(author);

            return Results.Created($"/{BaseRoute}/{author.Id}", author);
        }
    }
}
