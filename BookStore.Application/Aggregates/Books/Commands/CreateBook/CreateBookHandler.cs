using BookStore.Common.Contracts;
using BookStore.Domain.Entities;
using BookStore.Domain.Repositories;
using BookStore.Domain.Services;
using BookStore.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Aggregates.Books.Commands.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, BookResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorDomainService _authorDomainService;

        public CreateBookHandler(IBookRepository bookRepository, IAuthorDomainService authorDomainService)
        {
            _bookRepository = bookRepository;
            _authorDomainService = authorDomainService;
        }

        public async Task<BookResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var authorExists = await _authorDomainService.IsExist(request.AuthorId);
            if (!authorExists)
                throw new ArgumentException("Author is not exist!");

            var entity = Book.GetInstance(request.Name, (BookGenre)request.Genre, request.AuthorId, request.PublishedDate);
            var result = await _bookRepository.AddAsync(entity);

            return new BookResponse()
            {
                Id = result.Id,
                Name = result.Name,
                Genre = (int)result.Genre,
                PublishedDate = result.PublishedDate,
                Author = new AuthorResponse()
                {
                    Id = result.Author.Id,
                    Name = result.Author.Name
                }
            };
        }
    }
}
