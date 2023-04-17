using AutoMapper;
using LibraryStore.CrossCutting.Utils.Notification;
using LibraryStore.CrossCutting.Utils.Notification.Interfaces;
using LibraryStore.Domain.Commands.Book;
using LibraryStore.Domain.Entities;
using LibraryStore.Domain.Repositories;
using MediatR;

namespace LibraryStore.Domain.Handlers
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, IOperation>
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public AddBookCommandHandler(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public async Task<IOperation> Handle(AddBookCommand command, CancellationToken cancellationToken)
        {
            return Result.CreateSuccess(await _booksRepository.AddAsync(_mapper.Map<Book>(command)));
        }
    }
}
