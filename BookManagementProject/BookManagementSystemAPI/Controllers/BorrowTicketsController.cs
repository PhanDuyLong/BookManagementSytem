using BookManagementSystemData.Models;
using BookManagementSystemData.Services;
using BookManagementSystemData.ViewModels.BorrowTicketViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowTicketsController : ControllerBase
    {
        private readonly IBorrowTicketService _ticketService;
        public BorrowTicketsController(IBorrowTicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: Ticket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowTicketGetItems>>> GetTickets()
        {
            var result = await _ticketService.GetTickets();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET: api/name
        [HttpGet("borrowerId")]
        public async Task<ActionResult<BorrowTicket>> GetBookingByBorrowerId(string borrowerId)
        {
            var result = await _ticketService.GetTicketsByBorrowerId(borrowerId);
            
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        // GET: api/status
        [HttpGet("status")]
        public async Task<ActionResult<BorrowTicket>> GetBookingByStatus(bool status)
        {
            var result = await _ticketService.GetTicketsByStatus(status);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        // POST: 
        [HttpPost]
        public async Task<ActionResult<BorrowTicket>> PostTicket([FromBody] BorrowTicketCreateItem ticket)
        {
            var result = _ticketService.CreateTicket(ticket);
            if (result == null)
            {
                return Conflict();
            }
            return CreatedAtAction("GetTicketById", new { id = result.Id }, result);
        }
        //PUT:
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, BorrowTicketUpdateItem ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }

            var result = await _ticketService.UpdateTicket(id, ticket);
            if (!result)
            {
                return Conflict();
            }
            return NoContent();
        }

        // DELETE: 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var result = await _ticketService.DeleteTicket(id);
            if (! result)
            {
                return Conflict();
            }
            return NoContent();
        }
    }
}
