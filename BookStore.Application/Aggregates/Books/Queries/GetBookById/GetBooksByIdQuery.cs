using BookStore.Common.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Aggregates.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookResponse>
    {
        public int Id { get; private set; }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
