using AutoMapper;
using BookManagementSystemData.Models;
using BookManagementSystemData.ViewModels.BorrowTicketDetailModel;
using BookManagementSystemData.ViewModels.BorrowTicketViewModel;
using BookManagementSystemData.ViewModels.UserViewModel;

namespace HMS.Data.AutoMapperProfile
{
    public class MappingProfile : Profile {
        public MappingProfile()
        {
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
            CreateMap<BorrowTicket, BorrowTicketGetItems>();
            CreateMap<BorrowTicketCreateItem, BorrowTicket>();
            CreateMap<BorrowTicketUpdateItem, BorrowTicket>();
        }
    }
}
