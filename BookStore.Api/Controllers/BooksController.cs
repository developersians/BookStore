using BookStore.Application.Aggregates.Books.Commands.CreateBook;
using BookStore.Application.Aggregates.Books.Queries.GetBookById;
using BookStore.Application.Aggregates.Books.Queries.GetBooks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetBooksQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var query = new GetBookByIdQuery(id);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand request)
        {
            var command = new CreateBookCommand(request.Name, request.Genre, request.PublishedDate, request.AuthorId);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
