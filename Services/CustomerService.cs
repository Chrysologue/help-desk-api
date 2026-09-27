using HelpDeskApi.Models;

namespace HelpDeskApi.Services;

// CustomerService: Manages the business logic and in-memory list for customers
public class CustomerService
{
    // In-memory list pre-seeded with initial dummy customer data
    private List<Customer> _customers = new List<Customer>
    {
        new Customer { Id = 1, Name = "Xyste Chrysologue", Email = "xyste@gmail.com" },
        new Customer { Id = 2, Name = "Julie Orika", Email = "julie@gmail.com" }
    };

    // Returns all customers stored in memory
    public IEnumerable<Customer> GetAllCustomers() => _customers;

    // Finds and returns a single customer by their ID, or null if they don't exist
    public Customer? GetCustomer(int id)
    {
        return _customers.FirstOrDefault(cust => cust.Id == id);
    }

    // Generates a new ID, creates a customer object, adds it to the list, and returns it
    public Customer CreateCustomer(string name, string email)
    {
        var newCustomer = new Customer
        {
            // Auto-increments the ID based on the max existing ID, or defaults to 1 if empty
            Id = _customers.Count == 0 ? 1 : _customers.Max(cust => cust.Id) + 1,
            Name = name,
            Email = email
        };
        
        _customers.Add(newCustomer);
        return newCustomer;
    }

    // Finds a customer by ID, removes them from the list, and returns the deleted object (or null)
    public Customer? DeleteCustomer(int id)
    {
        var customer = GetCustomer(id);
        
        if (customer != null)
        {
            _customers.Remove(customer);
        }
        
        return customer;
    }
}