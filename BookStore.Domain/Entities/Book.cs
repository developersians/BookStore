using BookStore.Domain.Interfaces;
using BookStore.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Book : EntityBase, IAggregateRoot
    {
        private Book()
        {
        }
        public string Name { get; private set; }
        public BookGenre Genre { get; private set; }
        public int AuthorId { get; private set; }
        public DateTime PublishedDate { get; set; }

        public virtual Author Author { get; private set; }

        public static Book GetInstance(string name, BookGenre genre, Author author, DateTime publishedDate, int id = 0)
        {
            return new Book()
            {
                Id = id,
                Name = name,
                Genre = genre,
                Author = author,
                PublishedDate = publishedDate
            };
        }
    }
}
