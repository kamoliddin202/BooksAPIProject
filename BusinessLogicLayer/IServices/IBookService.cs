using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.BookDtos;

namespace BusinessLogicLayer.IServices
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task AddbookAsync(AddBookDto addBookDto);
        Task UpdateBookAsync(UpdateBookDto updateBookDto);
        Task DeleteBookAsync(int id);
    }
}
