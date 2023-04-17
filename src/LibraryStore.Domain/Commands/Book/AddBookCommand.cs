﻿using LibraryStore.CrossCutting.Utils.Notification.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LibraryStore.Domain.Commands.Book
{
    public class AddBookCommand : IRequest<IOperation>
    {
        [Required]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [Range(1000, int.MaxValue)]
        public int Year { get; set; }

        [Required]
        public string Isbn { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Summary { get; set; }

        public string? ImageData { get; set; }
        public string? OriginalImageName { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
    }
}
