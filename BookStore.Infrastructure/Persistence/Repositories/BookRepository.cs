using BookStore.Domain.Entities;
using BookStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        #region 
        public BookRepository(DataContext context)
        {
            _context = context;
        }
        #endregion Ctor

        #region Query side
        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(x => x.Author)
                .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        #endregion Query side

        #region Command side
        public async Task<Book> AddAsync(Book entity)
        {
            await _context.Books.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public Task UpdateAsync(Book entity)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(Book entity)
        {
            throw new NotImplementedException();
        }
        #endregion Command side
    }
}
