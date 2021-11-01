using AutoMapper;
using BookManagementSystemData.Models;
using BookManagementSystemData.Repositories;
using BookManagementSystemData.ViewModels.BorrowTicketDetailModel;
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
        public BorrowTicketDetailService(DbContext dbContext, IBorrowTicketDetailRepository repository, IMapper mapper) : base(dbContext, repository)
        {
            _mapper = mapper;
            _borrowticketdetailrepo = repository;
        }

        //get list ticket detail by ticket id
        public async Task<IList<BorrowTicketDetailGetItems>> GetTicketDetailsByTicketId(int ticketId)
        {
            var tickets = _borrowticketdetailrepo.Get().ToList().Where(n => n.BorrowTicketId == ticketId);
            if (tickets == null || !tickets.Any())
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
                BorrowTicketDetail ticket = _mapper.Map<BorrowTicketDetail>(ticketDetailUpdate);
                //ticket.IsDone = !ticket.IsDone;
                _borrowticketdetailrepo.Update(ticket);
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

