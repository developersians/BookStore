using BookStore.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Persistence.Services
{
    public class BookDomainService : IBookDomainService
    {
        private readonly DataContext _context;

        #region 
        public BookDomainService(DataContext context)
        {
            _context = context;
        }
        #endregion Ctor

        public async Task<bool> IsNameUnique(string name)
        {
            var result = true;
            var book = await _context.Books
                .Where(x => x.Name.ToLower().Equals(name.ToLower()))
                .FirstOrDefaultAsync();

            if (book != null && book.Id > 0)
                result = false;

            return result;
        }
    }
}
