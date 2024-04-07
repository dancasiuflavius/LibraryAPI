using BookAPI.Books.DTO;
using BookAPI.Books.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Books.Controller.Interfaces;

[ApiController]
[Route("api/v1/[controller]")]

public abstract class BookApiController : ControllerBase
{
    [HttpGet("all")]
    [ProducesResponseType(statusCode: 200, type: typeof(List<Book>))]
    [ProducesResponseType(statusCode: 404, type: typeof(String))]
    public abstract Task<ActionResult<IEnumerable<Book>>> GetBooks();

    [HttpPost("create")]
    [ProducesResponseType(statusCode: 200, type: typeof(Book))]
    [ProducesResponseType(statusCode: 400, type: typeof(String))]
    public abstract Task<ActionResult<Book>> CreateBook([FromBody] CreateBookRequest productRequest);

    [HttpPut("update")]
    [ProducesResponseType(statusCode: 200, type: typeof(Book))]
    [ProducesResponseType(statusCode: 404, type: typeof(String))]
    public abstract Task<ActionResult<Book>> UpdateBooks([FromQuery] int id, [FromBody] UpdateBookRequest productRequest);

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(statusCode: 200, type: typeof(Book))]
    [ProducesResponseType(statusCode: 404, type: typeof(String))]
    public abstract Task<ActionResult<Book>> DeleteBooks([FromRoute] int id);
}
