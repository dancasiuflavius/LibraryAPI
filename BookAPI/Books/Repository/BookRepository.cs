using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BookAPI.Data;
using BookAPI.Books.DTO;
using BookAPI.Books.Model;
using BookAPI.Books.Repository.Interfaces;
using System;

namespace BookAPI.Books.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public BookRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }
        public async Task<Book> CreateAsync(CreateBookRequest productRequest)
        {

            var product = _mapper.Map<Book>(productRequest);


            _context.Books.Add(product);

            await _context.SaveChangesAsync();

            return product;
        }
        public async Task<Book> UpdateAsync(int id, UpdateBookRequest request)
        {
            var product = await _context.Books.FindAsync(id);

            product.Title = request.Title ?? product.Title;
            product.Author = request.Author ?? product.Author;
            product.Category = request.Category ?? product.Category;
            product.PublishDate = request.Publish_Date ?? product.PublishDate;

            _context.Books.Update(product);

            await _context.SaveChangesAsync();

            return product;
        }
        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task<Book> DeleteAsync(int id)
        {
            var product = await _context.Books.FindAsync(id);
            _context.Books.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Book> GetByTitleAsync(string name)
        {
            return await _context.Books.FirstOrDefaultAsync(product => product.Title.Equals(name));

        }
    }
}
