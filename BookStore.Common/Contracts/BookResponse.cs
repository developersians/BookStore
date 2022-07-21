using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Common.Contracts
{
    public class BookResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Genre { get; set; }
        public AuthorResponse Author { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
