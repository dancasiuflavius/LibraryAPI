using BookAPI.Books.Model;
using BookAPI.Books.Repository;
using BookAPI.Books.Repository.Interfaces;
using BookAPI.Books.Service.Interfaces;
using BookAPI.System.Constants;
using BookAPI.System.Exceptions;
using Microsoft.VisualBasic;

namespace BookAPI.Books.Service
{
    public class BookQuerryService : IBookQuerryService
    {
        private IBookRepository _repository;

        public BookQuerryService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            IEnumerable<Book> products = await _repository.GetAllAsync();

            if (products.Count() == 0)
            {
                throw new ItemsDoNotExist(System.Constants.Constants.NO_PRODUCTS_EXIST);
            }

            return products;
        }

        public async Task<IEnumerable<Book>> GetBooksWithCategory(string category)
        {
            IEnumerable<Book> products = (await _repository.GetAllAsync())
                .Where(product => product.Category.Equals(category));

            if (products.Count() == 0)
            {
                throw new ItemsDoNotExist(System.Constants.Constants.NO_PRODUCTS_EXIST);
            }

            return products;
        }

        public async Task<IEnumerable<Book>> GetBooksWithNoCategory()
        {
            IEnumerable<Book> products = (await _repository.GetAllAsync())
                .Where(product => product.Category == null!);

            if (products.Count() == 0)
            {
                throw new ItemsDoNotExist(System.Constants.Constants.NO_PRODUCTS_EXIST);
            }

            return products;
        }

        

        public async Task<Book> GetBookById(int id)
        {
            Book product = await _repository.GetByIdAsync(id);

            if (product == null)
            {
                throw new ItemDoesNotExist(System.Constants.Constants.PRODUCT_DOES_NOT_EXIST);
            }

            return product;
        }
    }
}
