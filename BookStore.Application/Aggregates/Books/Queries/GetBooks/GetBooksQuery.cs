using BookStore.Common.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Aggregates.Books.Queries.GetBooks
{
    public class GetBooksQuery : IRequest<List<BookResponse>>
    {
    }
}
