using BookStore.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Persistence.Services
{
    public class AuthorDomainService : IAuthorDomainService
    {
        private readonly DataContext _context;

        #region 
        public AuthorDomainService(DataContext context)
        {
            _context = context;
        }
        #endregion Ctor

        public async Task<bool> IsExist(int id)
        {
            var result = false;
            var author = await _context.Authors
                .FirstOrDefaultAsync(x => x.Id == id);

            if (author != null && author.Id > 0)
                result = true;

            return result;
        }
    }
}
