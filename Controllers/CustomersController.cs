using HelpDeskApi.Models;
using HelpDeskApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _customerService;

    // Dependency Injection: ASP.NET Core automatically provides the CustomerService instance
    public CustomersController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    // GET: api/customers Fetches and returns a list of all registered customers
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        var customers = _customerService.GetAllCustomers();
        return Ok(customers);
    }

    // GET: api/customers/{id} Fetches a single customer by their unique ID, or returns a 404 error if not found
    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomer(int id)
    {
        var customer = _customerService.GetCustomer(id);

        if (customer == null)
        {
            return NotFound(new { message = $"Customer with ID {id} not found." });
        }

        return Ok(customer);
    }

    // POST: api/customers Captures JSON from the request body, maps it through the DTO, and creates a new customer
    [HttpPost]
    public ActionResult<Customer> CreateCustomer([FromBody] CreateCustomerDto dto)
    {
        var createdCustomer = _customerService.CreateCustomer(dto.Name, dto.Email);
        
        // Returns a 201 Created status along with the newly generated customer object
        return StatusCode(201, createdCustomer);
    }

    // DELETE: api/customers/{id} Removes a customer by their ID and returns the deleted object, or 404 if not found
    [HttpDelete("{id}")]
    public ActionResult<Customer> DeleteCustomer(int id)
    {
        var deletedCustomer = _customerService.DeleteCustomer(id);

        if (deletedCustomer == null)
        {
            return NotFound(new { message = $"Customer with ID {id} not found." });
        }

        return Ok(deletedCustomer);
    }
}

// Data Transfer Object (DTO) Acts as a strict validation blueprint for incoming POST JSON payloads for customers
public class CreateCustomerDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
}