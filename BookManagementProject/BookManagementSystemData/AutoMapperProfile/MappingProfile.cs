using AutoMapper;
using BookManagementSystemData.Models;
using BookManagementSystemData.ViewModels;
using BookManagementSystemData.ViewModels.Book;

namespace HMS.Data.AutoMapperProfile
{
    public class MappingProfile : Profile {
        public MappingProfile()
        {
            CreateMap<Book, BookDetailViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateBookViewModel, Book>();
        }
    }
}
