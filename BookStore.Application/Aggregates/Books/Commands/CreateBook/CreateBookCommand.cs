using BookStore.Common.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Aggregates.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<BookResponse>
    {
        public CreateBookCommand(string name, int genre, DateTime publishedDate, int authorId)
        {
            Name = name;
            Genre = genre;
            PublishedDate = publishedDate;
            AuthorId = authorId;
        }

        public string Name { get; private set; }
        public int Genre { get; private set; }
        public DateTime PublishedDate { get; private set; }
        public int AuthorId { get; private set; }
    }
}
