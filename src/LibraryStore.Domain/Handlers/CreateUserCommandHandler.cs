using AutoMapper;
using LibraryStore.CrossCutting.Utils.Notification;
using LibraryStore.CrossCutting.Utils.Notification.Interfaces;
using LibraryStore.Domain.Commands.Book;
using LibraryStore.Domain.Commands.User;
using LibraryStore.Domain.Entities;
using LibraryStore.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStore.Domain.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IOperation>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;

        public CreateUserCommandHandler(IMapper mapper, UserManager<ApiUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IOperation> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApiUser>(command);
            user.UserName = command.Email;
            var result = await _userManager.CreateAsync(user, command.Password);

            if (result.Succeeded == false)
            {
                var errorResult = Result.CreateFailure() as FailedOperation;
                foreach (var error in result.Errors)
                {
                    errorResult.Messages.Fields.Add(new MessageDetail() { Field = error.Code, Message = error.Description });
                }
                return errorResult;
            }

            await _userManager.AddToRoleAsync(user, "User");
            return Result.CreateSuccess();
        }
    }
}
