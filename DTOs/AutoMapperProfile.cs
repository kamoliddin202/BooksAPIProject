using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Entities;
using DTOs.BookDtos;
using DTOs.CategoryDtos;

namespace DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddBookDto, Book>();
            CreateMap<Book, BookDto>();
            CreateMap<UpdateBookDto, Book>();


            CreateMap<Category, CategoryDto>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<UpdateCateogryDto, Category>();
        }
    }
}
