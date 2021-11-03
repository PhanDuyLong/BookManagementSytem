using AutoMapper;
using BookManagementSystemData.Models;
using BookManagementSystemData.ViewModels;
using BookManagementSystemData.ViewModels.Book;
using BookManagementSystemData.ViewModels.BorrowTicketDetailModel;
using BookManagementSystemData.ViewModels.BorrowTicketViewModel;
using BookManagementSystemData.ViewModels.UserViewModel;


namespace HMS.Data.AutoMapperProfile
{
    public class MappingProfile : Profile {
        public MappingProfile()
        {

            CreateMap<Book, BookDetailViewModel>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateBookViewModel, Book>();

            //user
            //get
            CreateMap<User, UserGetItems>();

            //BorrowTicketDetail
            //get
            CreateMap<BorrowTicketDetail, BorrowTicketDetailGetItems>();
            CreateMap<BorrowTicketDetailCreateItem, BorrowTicketDetail>();
            CreateMap<BorrowTicketDetailUpdateItem, BorrowTicketDetail>();

            //BorrowTicket
            //get
            CreateMap<BorrowTicket, BorrowTicketGetItems>()
            .ForMember(dest => dest.CreateName, opt => opt.MapFrom(src => src.Creator.Name))
            .ForMember(dest => dest.BorrowName, opt => opt.MapFrom(src => src.Borrower.Name));
            CreateMap<BorrowTicketCreateItem, BorrowTicket>();
            CreateMap<BorrowTicketUpdateItem, BorrowTicket>();
        }
    }
}
