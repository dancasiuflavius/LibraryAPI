using BookAPI.System.Exceptions;
using BookAPI.Books.Model;
using BookAPI.Books.Repository;
using BookAPI.Books.Repository.Interfaces;
using BookAPI.Books.Service.Interfaces;
using BookAPI.System.Constants;
using BookAPI.System.Exceptions;
using BookAPI.Books.DTO;

namespace BookAPI.Books.Service
{
    public class BookCommandService : IBookComandService
    {
        private IBookRepository _repository;

        public BookCommandService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Book> CreateBook(CreateBookRequest productRequest)
        {
            

            Book product = await _repository.GetByTitleAsync(productRequest.Title);

            if (product != null)
            {
                throw new ItemAlreadyExists(Constants.PRODUCT_ALREADY_EXISTS);
            }

            product = await _repository.CreateAsync(productRequest);
            return product;
        }
        public async Task<Book> UpdateBook(int id, UpdateBookRequest productRequest)
        {
            

            Book product = await _repository.GetByIdAsync(productRequest.Id);
            if (product == null)
            {
                throw new ItemDoesNotExist(Constants.PRODUCT_DOES_NOT_EXIST);
            }
            product = await _repository.UpdateAsync(id, productRequest);
            return product;
        }
        public async Task<Book> DeleteBook(int id)
        {
            Book product = await _repository.GetByIdAsync(id);
            if (product == null)
            {
                throw new ItemDoesNotExist(Constants.PRODUCT_DOES_NOT_EXIST);
            }

            await _repository.DeleteAsync(id);
            return product;
        }
    }
}
