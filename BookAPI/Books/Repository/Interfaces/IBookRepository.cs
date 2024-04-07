using BookAPI.Books.DTO;
using BookAPI.Books.Model;

namespace BookAPI.Books.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> CreateAsync(CreateBookRequest bookRequest);
        Task<Book> GetByTitleAsync(string name);
        Task<Book> GetByIdAsync(int id);
        Task<Book> UpdateAsync(int id, UpdateBookRequest bookRequest);
        Task<Book> DeleteAsync(int id);
    }
}
