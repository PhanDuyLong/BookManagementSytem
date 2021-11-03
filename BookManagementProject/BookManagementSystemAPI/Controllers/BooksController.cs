using BookManagementSystemData.Parameters;
using BookManagementSystemData.Services;
using BookManagementSystemData.Utilities;
using BookManagementSystemData.ViewModels;
using BookManagementSystemData.ViewModels.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StartupLand.WebAPI.Constracts.Responses;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookManagementSystemAPI.Controllers
{
    [Route("books")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        public BooksController(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }

        
        [HttpGet("category")]
        public async Task<ActionResult<BookDetailViewModel>> GetCategory()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        /// <summary>
        /// Get Specific Book
        /// </summary>
        /// <response code="200">Returns the specific book</response>
        /// <response code="404">Not Found book with id</response>
        /// <response code="500">Server break</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailViewModel>> GetBook(int id)
        {
            var book = await _bookService.GetBookAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>
        /// Get Books
        /// </summary>
        /// <response code="200">Returns books</response>
        /// <response code="404">Not Found books</response>
        /// <response code="500">Server break</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<PaginatedList<BookDetailViewModel>>> GetBooks([FromQuery] BookParameters bookParameters)
        {
            var books = await _bookService.GetBooksAsync(bookParameters);
            if (books == null)
            {
                return NotFound();
            }

            var metadata = new
            {
                books.TotalCount,
                books.PageSize,
                books.CurrentPage,
                books.TotalPages,
                books.HasNext,
                books.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(books);
        }

        /// <summary>
        /// Create Book
        /// </summary>
        /// <response code="201">Created book successfully</response>
        /// <response code="400">Some Fields are wrong</response>
        /// <response code="500">Server break</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult> PostBook([FromBody] CreateBookViewModel model)
        {
            await _bookService.CreateBookAsync(model);
            return CreatedAtAction("GetBook", model);
        }

        /// <summary>
        /// Update book
        /// </summary>
        /// <response code="204">No return</response>
        /// /// <response code="400">Some Fields are wrong</response>
        /// <response code="404">Not Found book</response>
        /// <response code="500">Server break</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] UpdateBookViewModel model)
        {
            var book = await _bookService.GetAsyn(id);
            if (book == null || book.Status.Equals("Deleted"))
            {
                return NotFound();
            }

            _bookService.UpdateBook(book, model);

            return NoContent();
        }

        /// <summary>
        /// Delete book
        /// </summary>
        /// <response code="204">No return</response>
        /// /// <response code="400">Some Fields are wrong</response>
        /// <response code="404">Not Found book</response>
        /// <response code="500">Server break</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var book = await _bookService.GetAsyn(id);
            if (book == null || book.Status.Equals("Deleted"))
            {
                return NotFound();
            }

            _bookService.DeleteBook(book);

            return NoContent();
        }
    }
}
