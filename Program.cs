using HelpDeskApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Registering services
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<TicketService>();

var app = builder.Build();

app.MapGet("/", () => "Welcomet to Help Desk API");

// Map controllers to routes (/api/customers and /api/tickets)
app.MapControllers();

app.Run();