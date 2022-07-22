using BookStore.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Tests.MockData
{
    public class Books
    {
        private static List<BookResponse> books = new()
            {
                new BookResponse()
                {
                    Id = 1,
                    Name = "Test Book 1",
                    PublishedDate = DateTime.Now.AddYears(-10),
                    Author = new AuthorResponse()
                    {
                        Id= 1,
                        Name= "Test Author 1"
                    },
                    Genre = 2
                },
                new BookResponse()
                {
                    Id = 2,
                    Name = "Test Book 2",
                    PublishedDate = DateTime.Now.AddYears(-5),
                    Author = new AuthorResponse()
                    {
                        Id= 1,
                        Name= "Test Author 1"
                    },
                    Genre = 3
                },
                new BookResponse()
                {
                    Id = 3,
                    Name = "Test Book 3",
                    PublishedDate = DateTime.Now.AddYears(-2),
                    Author = new AuthorResponse()
                    {
                        Id= 2,
                        Name= "Test Author 2"
                    },
                    Genre = 2
                },
            };

        public static List<BookResponse> GetBookListTestData()
        {
            return books;
            //return await Task.Run(() => result);
        }
        public static BookResponse GetBookByIdTestData(int id)
        {
            var result = books.Where(x => x.Id == id)
                .FirstOrDefault();

            return result ?? new BookResponse();
        }
    }
}
