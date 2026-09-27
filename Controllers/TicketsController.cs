using HelpDeskApi.Models;
using HelpDeskApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly TicketService _ticketService;

    // Dependency Injection: ASP.NET Core automatically provides the TicketService instance
    public TicketsController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }

    // GET: api/tickets 
    [HttpGet]
    public ActionResult<IEnumerable<Ticket>> GetTickets(
        [FromQuery] Status? status, 
        [FromQuery] Priority? priority, 
        [FromQuery] int? customerId)
    {
        var tickets = _ticketService.GetAllTickets(status, priority, customerId);
        return Ok(tickets);
    }

    // GET: api/tickets/{id} Fetches a single ticket by its unique ID, or returns a 404 error if it doesn't exist
    [HttpGet("{id}")]
    public ActionResult<Ticket> GetTicket(int id)
    {
        var ticket = _ticketService.GetTicketById(id);

        if (ticket == null)
        {
            return NotFound(new { message = $"Ticket with ID {id} not found." });
        }

        return Ok(ticket);
    }

    // POST: api/tickets Captures JSON from the request body, maps it through the DTO, and creates a new ticket
    [HttpPost]
    public ActionResult<Ticket> CreateTicket([FromBody] CreateTicketDto dto)
    {
        var createdTicket = _ticketService.CreateTicket(
            dto.Title, 
            dto.Description, 
            dto.Priority, 
            dto.CustomerId
        );

        // Returns a 201 Created status along with the newly generated ticket object
        return StatusCode(201, createdTicket);
    }

    // DELETE: api/tickets/{id} Removes a ticket by its ID and returns the deleted object, or 404 if not found
    [HttpDelete("{id}")]
    public ActionResult<Ticket> DeleteTicket(int id)
    {
        var deletedTicket = _ticketService.DeleteTicket(id);

        if (deletedTicket == null)
        {
            return NotFound(new { message = $"Ticket with ID {id} not found." });
        }

        return Ok(deletedTicket);
    }
}

// Data Transfer Object (DTO) Acts as a strict validation blueprint for incoming POST JSON payloads
public class CreateTicketDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public Priority Priority { get; set; }
    public required int CustomerId { get; set; }
}