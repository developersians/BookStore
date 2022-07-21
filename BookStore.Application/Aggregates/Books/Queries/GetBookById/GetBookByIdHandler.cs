using BookStore.Common.Contracts;
using BookStore.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Aggregates.Books.Queries.GetBookById
{
    public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, BookResponse>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.GetByIdAsync(request.Id);
            return new BookResponse()
            {
                Id = result.Id,
                Name = result.Name,
                Genre = (int)result.Genre,
                PublishedDate = result.PublishedDate,
                Author = new AuthorResponse()
                {
                    Id = result.Author.Id,
                    Name = result.Author.Name,
                },
            };
        }
    }
}
