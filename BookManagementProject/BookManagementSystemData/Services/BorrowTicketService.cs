using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookManagementSystemData.Models;
using BookManagementSystemData.Repositories;
using BookManagementSystemData.ViewModels.BorrowTicketViewModel;
using HMS.Data.Services.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystemData.Services
{
    public interface IBorrowTicketService : IBaseService<BorrowTicket>
    {
        public Task<IList<BorrowTicketGetItems>> GetTickets();
        public Task<IList<BorrowTicketGetItems>> GetTicketsByBorrowerId(string borrowerId);
        public Task<IList<BorrowTicketGetItems>> GetTicketsByStatus(bool status);
        public Task<BorrowTicketCreateItem> CreateTicket(BorrowTicketCreateItem ticketCreate);
        public Task<bool> UpdateTicket(int id, BorrowTicketUpdateItem ticketUpdate);
        public Task<bool> DeleteTicket(int id);
        Task<BorrowTicketGetItems> GetTicketById(int id);

    }
    public class BorrowTicketService : BaseService<BorrowTicket>, IBorrowTicketService
    {
        private readonly IMapper _mapper;
        private readonly IBorrowTicketRepository _borrowticketrepo;
        public BorrowTicketService(DbContext dbContext, IBorrowTicketRepository repository, IMapper mapper) : base(dbContext, repository)
        {
            _mapper = mapper;
            _borrowticketrepo = repository;
        }

        //get ticket
        public async Task<IList<BorrowTicketGetItems>> GetTickets()
        {
            var tickets = await Get().OrderByDescending(a => a.BorrowDate)
               .ProjectTo<BorrowTicketGetItems>(_mapper.ConfigurationProvider).ToListAsync();
            if (tickets == null)
            {
                return null;
            }

            return tickets;
        }


        //get by id
        public async Task<BorrowTicketGetItems> GetTicketById(int id)
        {
            var tickets = await Get(t => t.Id == id).OrderByDescending(a => a.BorrowDate)
               .ProjectTo<BorrowTicketGetItems>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            if (tickets == null)
            {
                return null;
            }

            return tickets;
        }


        //get list ticket by borrowerId
        public async Task<IList<BorrowTicketGetItems>> GetTicketsByBorrowerId(string borrowerId)
        {
            var tickets = await Get(n => n.BorrowerId.Trim().ToLower() == borrowerId.ToLower()).OrderByDescending(a => a.BorrowDate)
                .ProjectTo<BorrowTicketGetItems>(_mapper.ConfigurationProvider).ToListAsync();
            if (tickets == null)
            {
                return null;
            }

            return tickets;
        }

        //get list ticket by status
        public async Task<IList<BorrowTicketGetItems>> GetTicketsByStatus(bool status)
        {
            var tickets = await Get(n => n.IsDone == status).OrderByDescending(a => a.BorrowDate)
                .ProjectTo<BorrowTicketGetItems>(_mapper.ConfigurationProvider).ToListAsync();
            if (tickets == null)
            {
                return null;
            }

            return tickets;
        }
        //create ticket
        public async Task<BorrowTicketCreateItem> CreateTicket(BorrowTicketCreateItem ticketCreate)
        {
            await _borrowticketrepo.CreateAsyn(_mapper.Map<BorrowTicket>(ticketCreate));
            return ticketCreate;
        }

        //update 
        public async Task<bool> UpdateTicket(int id, BorrowTicketUpdateItem ticketUpdate)
        {
            if (_borrowticketrepo.isTicketExists(id))
            {
                BorrowTicket ticket = _mapper.Map<BorrowTicket>(ticketUpdate);
                //ticket.IsDone = !ticket.IsDone;
                _borrowticketrepo.Update(ticket);
                return true;
            }
            else
            {
                return false;
            }
        }

        //delete
        public async Task<bool> DeleteTicket(int id)
        {
            if (_borrowticketrepo.isTicketExists(id))
            {
                _borrowticketrepo.Delete(_borrowticketrepo.Get(id));
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
