using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookManagementSystemData.Models;
using BookManagementSystemData.Repositories;
using BookManagementSystemData.ViewModels.BorrowTicketDetailModel;
using BookManagementSystemData.ViewModels.BorrowTicketViewModel;
using HMS.Data.Services.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystemData.Services
{
    public interface IBorrowTicketDetailService : IBaseService<BorrowTicketDetail>
    {
        public Task<IList<BorrowTicketDetailGetItems>> GetTicketDetailsByTicketId(int ticketId);
        public Task<IList<BorrowTicketDetailGetItems>> GetTicketDetailsByStatus(int ticketId,bool status);
        public Task<BorrowTicketDetail> CreateTicketDetail(BorrowTicketDetailCreateItem ticketDetailCreate);
        public Task<bool> UpdateTicketDetail (int id, BorrowTicketDetailUpdateItem ticketDetailUpdate);
        public Task<bool> DeleteTicketDetail(int id);
    }
    public class BorrowTicketDetailService : BaseService<BorrowTicketDetail>, IBorrowTicketDetailService
    {
        private readonly IMapper _mapper;
        private readonly IBorrowTicketDetailRepository _borrowticketdetailrepo;
        private readonly IBorrowTicketRepository _borrowTicketRepository;
        public BorrowTicketDetailService(DbContext dbContext, 
            IBorrowTicketDetailRepository repository, IMapper mapper,
            IBorrowTicketRepository borrowTicketRepository) : base(dbContext, repository)
        {
            _mapper = mapper;
            _borrowticketdetailrepo = repository;
            _borrowTicketRepository = borrowTicketRepository;
        }

        //get list ticket detail by ticket id
        public async Task<IList<BorrowTicketDetailGetItems>> GetTicketDetailsByTicketId(int ticketId)
        {
            var tickets = await Get(n => n.BorrowTicketId == ticketId)
                .ProjectTo<BorrowTicketDetailGetItems>(_mapper.ConfigurationProvider).ToListAsync();
            if (tickets == null || !tickets.Any())
            {
                return null;
            }

            return tickets;
        }

        /*
         public async Task<IList<BorrowTicketDetailGetItems>> GetTicketDetailsByTicketId(int ticketId)
        {
            var tickets = _borrowticketdetailrepo.Get(n => n.BorrowTicketId == ticketId).ToList();
            if (tickets == null || tickets.Count() == 0)
            {
                return null;
            }
           

            return _mapper.Map<List<BorrowTicketDetail>, List<BorrowTicketDetailGetItems>>(tickets);
        }
         */

        //get list ticket by ticket id and status
        public async Task<IList<BorrowTicketDetailGetItems>> GetTicketDetailsByStatus(int ticketId , bool status)
        {
            var tickets = _borrowticketdetailrepo.Get().ToList().Where(n => n.IsReturned == status && n.BorrowTicketId == ticketId);
            if (tickets == null)
            {
                return null;
            }
            IList<BorrowTicketDetailGetItems> listTicket = new List<BorrowTicketDetailGetItems>();

            foreach (var item in tickets)
            {
                listTicket.Add(_mapper.Map<BorrowTicketDetailGetItems>(item));
            }


            return listTicket;
        }
        //create ticket
        public async Task<BorrowTicketDetail> CreateTicketDetail(BorrowTicketDetailCreateItem ticketDetailCreate)
        {
            BorrowTicketDetail ticket = _mapper.Map<BorrowTicketDetail>(ticketDetailCreate);
            _borrowticketdetailrepo.Create(ticket);
            return ticket;
        }

        //update 
        public async Task<bool> UpdateTicketDetail(int id, BorrowTicketDetailUpdateItem ticketDetailUpdate)
        {
            if (_borrowticketdetailrepo.isTicketDetailExists(id))
            {
                await _borrowticketdetailrepo.UpdateAsyn(_mapper.Map<BorrowTicketDetail>(ticketDetailUpdate));
                var ticket = await _borrowTicketRepository.Get(t => t.Id == ticketDetailUpdate.BorrowTicketId)
                    .ProjectTo<BorrowTicketGetItems>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
                bool check = true;
                foreach (var item in ticket.BorrowTicketDetails)
                {
                    if(item.IsReturned == null || (bool)!item.IsReturned)
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    var updateTicket = _mapper.Map<BorrowTicket>(ticket);
                    updateTicket.IsDone = true;
                    updateTicket.BorrowTicketDetails = null;
                    await _borrowTicketRepository.UpdateAsyn(updateTicket);
                }

                return true;

            }
            else
            {
                return false;
            }
        }

        //delete
        public async Task<bool> DeleteTicketDetail(int id)
        {
            if (_borrowticketdetailrepo.isTicketDetailExists(id))
            {
                _borrowticketdetailrepo.Delete(_borrowticketdetailrepo.Get(id));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

