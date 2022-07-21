using BookStore.Common.Contracts;
using BookStore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Aggregates.Books.Queries.GetBooks
{
    public class GetBooksHandler : IRequestHandler<GetBooksQuery, List<BookResponse>>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<BookResponse>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var result = await _bookRepository.GetAllAsync();
            return result.Select(x => new BookResponse()
            {
                Id = x.Id,
                Name = x.Name,
                Genre = (int)x.Genre,
                PublishedDate = x.PublishedDate,
                Author = new AuthorResponse()
                {
                    Id = x.Author.Id,
                    Name = x.Author.Name
                }
            })
            .ToList();
        }
    }
}
