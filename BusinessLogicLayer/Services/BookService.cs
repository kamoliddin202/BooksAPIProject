using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.IServices;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using DTOs.BookDtos;

namespace BusinessLogicLayer.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, 
                            IMapper mapper)
                           
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddbookAsync(AddBookDto addBookDto)
        {
            var category = _mapper.Map<Book>(addBookDto);

            await _unitOfWork.bookInterface.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var category = await _unitOfWork.bookInterface.GetByIdAsync(id);
            if (category != null)
            {
                await _unitOfWork.bookInterface.DeleteAsync(category.Id);
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(id));
            }
            
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var categories = await _unitOfWork.bookInterface.GetAllAsync();

            return categories.Select(c => _mapper.Map<BookDto>(c)).ToList();
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var category = await _unitOfWork.bookInterface.GetByIdAsync(id);
            if (category != null)
            {
                return _mapper.Map<BookDto>(category);
            }
            else
            {
                throw new ArgumentNullException ($"id {id}");
            }
            
        }

        public async Task UpdateBookAsync(UpdateBookDto updateBookDto)
        {
            var book = await _unitOfWork.bookInterface.GetByIdAsync(updateBookDto.Id);
            if (book != null)
            {
                _mapper.Map(updateBookDto, book);
                await _unitOfWork.bookInterface.UpdateAsync(book);
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException(nameof(updateBookDto));
            }    
        }
    }
}
