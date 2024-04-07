using Microsoft.AspNetCore.Mvc;
using BookAPI.Books.Controller.Interfaces;
using BookAPI.Books.DTO;
using BookAPI.Books.Model;
using BookAPI.Books.Repository.Interfaces;
using BookAPI.Books.Service;
using BookAPI.Books.Service.Interfaces;
using BookAPI.System.Exceptions;

namespace BookAPI.Books.Controller;

public class BooksController : BookApiController
{
    private IBookQuerryService _bookQueryService;
    private IBookComandService _bookCommandService;

    private readonly ILogger<BooksController> _logger;


    public BooksController(ILogger<BooksController> logger, IBookQuerryService bookQueryService, IBookComandService bookCommandService)
    {
        _logger = logger;
        _bookQueryService = bookQueryService;
        _bookCommandService = bookCommandService;
    }
    [HttpGet("api/v1/all")]
    public override async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        try
        {
            var products = await _bookQueryService.GetAllBooks();
            return Ok(products);
        }
        catch (ItemsDoNotExist ex)
        {
            return NotFound(ex.Message);
        }


    }
    public override async Task<ActionResult<Book>> CreateBook(CreateBookRequest productRequest)
    {
        _logger.LogInformation(message: $"Rest request: Create product with DTO:\n{productRequest}");
        try
        {
            var product = await _bookCommandService.CreateBook(productRequest);

            return Ok(product);
        }
        catch (ItemAlreadyExists ex)
        {
            _logger.LogWarning(ex.Message);
            return BadRequest(ex.Message);
        }



    }
    public override async Task<ActionResult<Book>> UpdateBooks([FromQuery] int id, [FromBody] UpdateBookRequest request)
    {
        _logger.LogInformation(message: $"Rest request: Create book with DTO:\n{request}");
        try
        {

            Book response = await _bookCommandService.UpdateBook(id, request);

            return Accepted(response);
        }
        catch (ItemDoesNotExist ex)
        {
            _logger.LogWarning(ex.Message);
            return NotFound(ex.Message);
        }
    }
    public override async Task<ActionResult<Book>> DeleteBooks([FromQuery] int id)
    {
        _logger.LogInformation(message: $"Rest request: Delete product with id:\n{id}");
        try
        {
            Book product = await _bookCommandService.DeleteBook(id);

            return Ok(product);
        }
        catch (ItemDoesNotExist ex)
        {
            _logger.LogError(ex.Message + $"Error while trying to delete product: \n{id}");
            return NotFound(ex.Message);
        }
    }
}
