using BookStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Entities
{
    public class Author : EntityBase, IAggregateRoot
    {
        private Author()
        {
        }

        public string Name { get; private set; }

        public virtual ICollection<Book> Books { get; private set; }

        public static Author GetInstance(string name, int id = 0)
        {
            return new Author()
            {
                Id = id,
                Name = name
            };
        }
    }
}
