using BookManagementSystemData.Models;
using BookManagementSystemData.Services;
using BookManagementSystemData.ViewModels.BorrowTicketDetailModel;
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
    public class BorrowTicketDetailsController : ControllerBase
    {
        private readonly IBorrowTicketDetailService _ticketDetailService;
        public BorrowTicketDetailsController(IBorrowTicketDetailService ticketDetailService)
        {
            _ticketDetailService = ticketDetailService;
        }


        // GET: api/name
        [HttpGet("ticketId")]
        public async Task<ActionResult<BorrowTicketDetail>> GetBookingByBorrowerId(int ticketId)
        {
            var result = await _ticketDetailService.GetTicketDetailsByTicketId(ticketId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        // GET: api/status
        [HttpGet("status")]
        public async Task<ActionResult<BorrowTicketDetail>> GetBookingByStatus(int ticketId,bool status)
        {
            var result = await _ticketDetailService.GetTicketDetailsByStatus(ticketId,status);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        // POST: 
        [HttpPost]
        public async Task<ActionResult<BorrowTicketDetail>> PostTicket([FromBody] BorrowTicketDetailCreateItem ticketDetail)
        {
            var result = _ticketDetailService.CreateTicketDetail(ticketDetail);
            if (result == null)
            {
                return Conflict();
            }
            return CreatedAtAction("GetTicketDetailById", new { id = result.Id }, result);
        }
        //PUT:
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, BorrowTicketDetailUpdateItem ticketDetail)
        {
            if (id != ticketDetail.Id)
            {
                return BadRequest();
            }

            var result = await _ticketDetailService.UpdateTicketDetail(id, ticketDetail);
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
            var result = await _ticketDetailService.DeleteTicketDetail(id);
            if (!result)
            {
                return Conflict();
            }
            return NoContent();
        }
    }

}
