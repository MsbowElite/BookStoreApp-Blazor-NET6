using LibraryStore.CrossCutting.Utils.Notification.Interfaces;
using MediatR;

namespace LibraryStore.Domain.Commands.Book
{
    public class AddBookCommand : IRequest<IOperation>
    {
    }

    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, IOperation>
    {
        public Task<IOperation> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
