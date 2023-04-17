using BookStoreApp.API.Models.User;
using LibraryStore.CrossCutting.Utils.Notification.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryStore.Domain.Commands.User
{
    public class CreateUserCommand : IRequest<IOperation>
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Role { get; set; }
    }
}
