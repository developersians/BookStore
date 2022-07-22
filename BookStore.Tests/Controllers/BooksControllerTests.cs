using BookStore.Api.Controllers;
using BookStore.Application.Aggregates.Books.Commands.CreateBook;
using BookStore.Application.Aggregates.Books.Queries.GetBookById;
using BookStore.Application.Aggregates.Books.Queries.GetBooks;
using BookStore.Common.Contracts;
using BookStore.Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Tests.Controllers
{
    public class BooksControllerTests
    {
        [Fact]
        public async void GetAll_ReturnsListOfBookResponse()
        {
            //Arrange
            var mediator = new Mock<IMediator>();
            mediator.Setup(x => x.Send(It.IsAny<GetBooksQuery>(), It.IsAny<CancellationToken>()).Result)
                .Returns(MockData.Books.GetBookListTestData());

            var sut = new BooksController(mediator.Object);

            //Act
            var actionResult = await sut.GetAll();

            //Assert
            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var data = okObjectResult?.Value as List<BookResponse>;
            Assert.NotNull(data);

            var actual = data?.Count();
            Assert.Equal(3, actual);
        }

        [Fact]
        public async void GetById_GivenValidId_ReturnsBookResponse()
        {
            //Arrange
            var existBookId = 2;
            var query = new GetBookByIdQuery(existBookId);
            var mediator = new Mock<IMediator>();
            mediator.Setup(x => x.Send(It.IsAny<GetBookByIdQuery>(), It.IsAny<CancellationToken>()).Result)
                .Returns(MockData.Books.GetBookByIdTestData(existBookId));

            var sut = new BooksController(mediator.Object);

            //Act
            var actionResult = await sut.GetById(existBookId);

            //Assert
            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var data = okObjectResult?.Value as BookResponse;
            Assert.NotNull(data);
        }

        [Fact]
        public async void GetById_GivenZeroAsId_ReturnsBadRequest()
        {
            //Arrange
            var existBookId = 7;
            var query = new GetBookByIdQuery(existBookId);
            var mediator = new Mock<IMediator>();
            mediator.Setup(x => x.Send(It.IsAny<GetBookByIdQuery>(), It.IsAny<CancellationToken>()).Result)
                .Returns(MockData.Books.GetBookByIdTestData(existBookId));

            var sut = new BooksController(mediator.Object);

            //Act
            var actionResult = await sut.GetById(existBookId);

            //Assert
            var badRequestResult = actionResult as BadRequestResult;
            Assert.NotNull(badRequestResult);
        }
    }
}
