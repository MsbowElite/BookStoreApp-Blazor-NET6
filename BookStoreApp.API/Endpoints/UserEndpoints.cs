using BookStoreApp.API.Endpoints.Internal;
using LibraryStore.Domain.Models.DTO.User;
using LibraryStore.CrossCutting.Utils.Notification;
using LibraryStore.Domain.Commands.User;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace BookStoreApp.API.Endpoints
{
    public class UserEndpoints : IEndpoints
    {
        private const string ContentType = "application/json";
        private const string Tag = "Users";
        private const string BaseRoute = "users";

        public static void AddServices(IServiceCollection services, IConfiguration configuration)
        {
        }

        public static void DefineEndpoints(IEndpointRouteBuilder app)
        {
            app.MapPost(BaseRoute, RegisterAsync)
                .WithName("Register")
                .Accepts<CreateUserCommand>(ContentType)
                .Produces(StatusCodes.Status204NoContent)
                .Produces<IEnumerable<ValidationFailure>>(StatusCodes.Status400BadRequest)
                .WithTags(Tag);

            app.MapPost(BaseRoute + "/login", LoginAsync)
                .WithName("Login")
                .Accepts<LoginCommand>(ContentType)
                .Produces(StatusCodes.Status200OK, typeof(AuthResponse))
                .Produces<IEnumerable<ValidationFailure>>(StatusCodes.Status400BadRequest)
                .WithTags(Tag);
        }

        internal static async Task<IResult> RegisterAsync(CreateUserCommand command, IMediator mediator)
        {
            var response = await mediator.Send(command);
            if (response is FailedOperation failedOperation)
            {
                return Results.StatusCode(StatusCodes.Status400BadRequest);
            }

            return Results.NoContent();
        }

        internal static async Task<IResult> LoginAsync(LoginCommand command, IMediator mediator)
        {
            var response = await mediator.Send(command);
            if (response is SuccessfulOperation<AuthResponse> successfulOperation)
            {
                return Results.Ok(successfulOperation);
            }

            return Results.StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
