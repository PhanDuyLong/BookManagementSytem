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
            CreateMap<BorrowTicketDetail, BorrowTicketDetailGetItems>()
                .ForMember(dest => dest.BookName, opt => opt.MapFrom(src => src.Book.Name));
            CreateMap<BorrowTicketDetailGetItems, BorrowTicketDetail>();
            CreateMap<BorrowTicketDetailCreateItem, BorrowTicketDetail>();
            CreateMap<BorrowTicketDetailUpdateItem, BorrowTicketDetail>();

            //BorrowTicket
            //get
            CreateMap<BorrowTicket, BorrowTicketGetItems>()
            .ForMember(dest => dest.CreateName, opt => opt.MapFrom(src => src.Creator.Name))
            .ForMember(dest => dest.BorrowName, opt => opt.MapFrom(src => src.Borrower.Name));
            CreateMap<BorrowTicketGetItems, BorrowTicket>();
            CreateMap<BorrowTicketCreateItem, BorrowTicket>();
            CreateMap<BorrowTicketUpdateItem, BorrowTicket>();
        }
    }
}
