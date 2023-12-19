using AssoSw.Lesson7.AspNetCoreWebApi.Context;
using AssoSw.Lesson7.AspNetCoreWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace AssoSw.Lesson7.AspNetCoreWebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly WarehouseContext _context;

        public CustomersController(ILogger<CustomersController> logger, WarehouseContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        [SwaggerOperation(Summary = "Get a customer by id", Description = "Get a customer by id")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, "Customer found", typeof(Customer))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Customer not found", typeof(ProblemDetails))]
        public IActionResult Get([FromRoute, SwaggerParameter("Id of the customer")] int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(m => m.Id == id);
            if (customer == null)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Customer not found",
                    Detail = $"The customer with id '{id}' was not found",
                    Status = 404,
                    Instance = HttpContext.Request.Path
                };
                return NotFound(problemDetails);
            }
            return Ok(customer);
        }

        [HttpGet(Name = "GetCustomers")]
        [SwaggerOperation(Summary = "Get all customers", Description = "Get all customers")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, "Customers found", typeof(IEnumerable<Customer>))]
        public IActionResult GetAll()
        {
            return Ok(_context.Customers);
        }

        [HttpPost(Name = "CreateCustomer")]
        [SwaggerOperation(Summary = "Create a new customer", Description = "Create a new customer")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created, "Customer created", typeof(Customer))]
        public IActionResult Create([FromBody, SwaggerParameter("Customer to create", Required = true)] Customer customer)
        {
            _context.Customers.Add(customer);
            int result = _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}", Name = "UpdateCustomer")]
        [SwaggerOperation(Summary = "Update a customer", Description = "Update a customer")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, "Customer updated", typeof(Customer))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Customer id mismatch", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status409Conflict, "Error during update", typeof(ProblemDetails))]
        public IActionResult Update(
            [FromRoute, SwaggerParameter("Id of the customer to update", Required = true)] int id,
            [FromBody, SwaggerParameter("Customer to update", Required = true)] Customer customer)
        {
            if (id != customer.Id)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Customer id mismatch",
                    Detail = $"The id in the url '{id}' doesn't match the id in the body '{customer.Id}'",
                    Status = 400,
                    Instance = HttpContext.Request.Path
                };
                return BadRequest(problemDetails);
            }

            try
            {
                _context.Update(customer);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Concurrency violation",
                    Detail = $"Error updating customer with id '{id}'",
                    Status = 409,
                    Instance = HttpContext.Request.Path
                };
                return Conflict(problemDetails);
            }
            catch (Exception)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Error updating customer",
                    Detail = $"Error updating customer with id '{id}'",
                    Status = 409,
                    Instance = HttpContext.Request.Path
                };
                return Conflict(problemDetails);
            }
            return Ok(customer);
        }

        [HttpDelete("{id}", Name = "DeleteCustomer")]
        [SwaggerOperation(Summary = "Delete a customer", Description = "Delete a customer")]
        [SwaggerResponse(StatusCodes.Status200OK, "Customer deleted")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Customer not found", typeof(ProblemDetails))]
        public IActionResult Delete([FromRoute, SwaggerParameter("Id of the customer to delete", Required = true)] int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Customer not found",
                    Detail = $"The customer with id '{id}' was not found",
                    Status = 404,
                    Instance = HttpContext.Request.Path
                };
                return NotFound(problemDetails);
            }
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            _context.SaveChangesAsync();
            return Ok();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
