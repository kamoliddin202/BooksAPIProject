using BusinessLogicLayer.IServices;
using DTOs.BookDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddBookDto addBookDto)
        {
            await _bookService.AddbookAsync(addBookDto);
            return Ok("Created !");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book  = await _bookService.GetBookByIdAsync(id);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return Ok("Deleted !");
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateBookDto updateBookDto)
        {
            await _bookService.UpdateBookAsync(updateBookDto);
            return Ok("Updated !");
        }

    }
}
