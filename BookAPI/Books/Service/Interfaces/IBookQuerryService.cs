using BookAPI.Books.Model;

namespace BookAPI.Books.Service.Interfaces
{
    public interface IBookQuerryService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<IEnumerable<Book>> GetBooksWithCategory(string category);
        Task<IEnumerable<Book>> GetBooksWithNoCategory();
        Task<Book> GetBookById(int id);
    }
}
