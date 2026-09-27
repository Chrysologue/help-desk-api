using HelpDeskApi.Models;

namespace HelpDeskApi.Services;

// TicketService: Manages business logic, dynamic filtering, and the in-memory list for tickets
public class TicketService
{
    // In-memory list pre-seeded with initial dummy ticket data linked to customers
    private List<Ticket> _tickets = new List<Ticket>
    {
        new Ticket 
        { 
            Id = 1, 
            Title = "Login Issue", 
            Description = "Cannot log into the dashboard", 
            Priority = Priority.High, 
            Status = Status.Open, 
            CustomerId = 1 
        },
        new Ticket 
        { 
            Id = 2, 
            Title = "Password Reset", 
            Description = "Need help resetting password", 
            Priority = Priority.Low, 
            Status = Status.Progress, 
            CustomerId = 2 
        }
    };

    // Returns tickets with optional conditional filtering based on query parameters (Status, Priority, CustomerId)
    public IEnumerable<Ticket> GetAllTickets(Status? status = null, Priority? priority = null, int? customerId = null)
    {
        var query = _tickets.AsEnumerable();

        // Apply status filter only if a value was provided in the query string
        if (status.HasValue)
        {
            query = query.Where(t => t.Status == status.Value);
        }

        // Apply priority filter only if a value was provided
        if (priority.HasValue)
        {
            query = query.Where(t => t.Priority == priority.Value);
        }

        // Apply customerId filter only if a value was provided
        if (customerId.HasValue)
        {
            query = query.Where(t => t.CustomerId == customerId.Value);
        }

        return query.ToList();
    }

    // Finds and returns a single ticket by its unique ID, or null if not found
    public Ticket? GetTicketById(int id)
    {
        return _tickets.FirstOrDefault(t => t.Id == id);
    }

    // Generates an ID, sets default status to Open, builds a new ticket, adds it, and returns it
    public Ticket CreateTicket(string title, string description, Priority priority, int customerId)
    {
        var newTicket = new Ticket
        {
            // Auto-increments the ID based on the max existing ID, or defaults to 1 if empty
            Id = _tickets.Count == 0 ? 1 : _tickets.Max(t => t.Id) + 1,
            Title = title,
            Description = description,
            Priority = priority,
            Status = Status.Open, // New tickets always start as Open by default
            CustomerId = customerId
        };

        _tickets.Add(newTicket);
        return newTicket;
    }

    // Finds a ticket by ID, removes it from memory, and returns the deleted object (or null)
    public Ticket? DeleteTicket(int id)
    {
        var ticket = GetTicketById(id);
        
        if (ticket != null)
        {
            _tickets.Remove(ticket);
        }
        
        return ticket;
    }
}