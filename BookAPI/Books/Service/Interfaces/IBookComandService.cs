using BookAPI.Books.DTO;
using BookAPI.Books.Model;

namespace BookAPI.Books.Service.Interfaces;

public interface IBookComandService
{
    Task<Book> CreateBook(CreateBookRequest bookRequest);

    Task<Book> UpdateBook(int id, UpdateBookRequest bookRequest);

    Task<Book> DeleteBook(int id);
}
