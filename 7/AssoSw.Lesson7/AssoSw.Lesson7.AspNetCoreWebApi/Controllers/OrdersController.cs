using AssoSw.Lesson7.AspNetCoreWebApi.Context;
using AssoSw.Lesson7.AspNetCoreWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace AssoSw.Lesson7.AspNetCoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly WarehouseContext _context;

        public OrdersController(ILogger<OrdersController> logger, WarehouseContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{id}", Name = "GetOrder")]
        [SwaggerOperation(Summary = "Get a order by id", Description = "Get a order  by id")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, "Order found", typeof(Order))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Order not found", typeof(ProblemDetails))]
        public IActionResult Get([FromRoute, SwaggerParameter("Id of the order")] int id)
        {
            Order order = _context.Orders
                .Include(x => x.OrderDetails)
                .FirstOrDefault(m => m.Id == id);

            if (order == null)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Order not found",
                    Detail = $"The order with id '{id}' was not found",
                    Status = 404,
                    Instance = HttpContext.Request.Path
                };
                return NotFound(problemDetails);
            }
            return Ok(order);
        }

        [HttpGet(Name = "GetOrders")]
        [SwaggerOperation(Summary = "Get all orders", Description = "Get all orders")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, "Orders found", typeof(IEnumerable<Order>))]
        public IActionResult GetAll()
        {
            return Ok(_context.Orders.Include(o => o.OrderDetails));
        }

        [HttpPost(Name = "CreateOrder")]
        [SwaggerOperation(Summary = "Create a new order", Description = "Create a new order")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created, "Order created", typeof(Order))]
        public IActionResult Create([FromBody, SwaggerParameter("Order to create", Required = true)] Order order)
        {
            _context.Orders.Add(order);
            int result = _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
        }

        [HttpPut("{id}", Name = "UpdateOrder")]
        [SwaggerOperation(Summary = "Update a order", Description = "Update a order")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, "Order updated", typeof(Order))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Order id mismatch", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status409Conflict, "Error during update", typeof(ProblemDetails))]
        public IActionResult Update(
            [FromRoute, SwaggerParameter("Id of the order to update", Required = true)] int id,
            [FromBody, SwaggerParameter("Order to update", Required = true)] Order order)
        {
            if (id != order.Id)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Order id mismatch",
                    Detail = $"The id in the url '{id}' doesn't match the id in the body '{order.Id}'",
                    Status = 400,
                    Instance = HttpContext.Request.Path
                };
                return BadRequest(problemDetails);
            }

            try
            {
                _context.Update(order);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Concurrency violation",
                    Detail = $"Error updating order with id '{id}'",
                    Status = 409,
                    Instance = HttpContext.Request.Path
                };
                return Conflict(problemDetails);
            }
            catch (Exception)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Error updating order",
                    Detail = $"Error updating order with id '{id}'",
                    Status = 409,
                    Instance = HttpContext.Request.Path
                };
                return Conflict(problemDetails);
            }
            return Ok(order);
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [SwaggerOperation(Summary = "Delete a order", Description = "Delete a order")]
        [SwaggerResponse(StatusCodes.Status200OK, "Order deleted")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Order not found", typeof(ProblemDetails))]
        public IActionResult Delete([FromRoute, SwaggerParameter("Id of the order to delete", Required = true)] int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Order not found",
                    Detail = $"The order with id '{id}' was not found",
                    Status = 404,
                    Instance = HttpContext.Request.Path
                };
                return NotFound(problemDetails);
            }
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            _context.SaveChangesAsync();
            return Ok();
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpPost("{id}/calculateTotalOrderAmount", Name = "CalculateTotalOrderAmount")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerOperation(Summary = "Calculate the total amount of an order", Description = "Calculate the total amount of an order")]
        [SwaggerResponse(StatusCodes.Status200OK, "Total amount calculated", typeof(decimal))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Order not found", typeof(ProblemDetails))]
        public IActionResult CalculateTotalOrderAmount(int id)
        {
            /*
             * retrieve the order with the specified id including the OrderDetails
             * and the product associated to each orderdetail
             */
            var order = _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefault(x => x.Id == id);

            if (order == null)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Order not found",
                    Detail = $"The order with id '{id}' was not found",
                    Status = 404,
                    Instance = HttpContext.Request.Path
                };
                return NotFound(problemDetails);
            }
            decimal total = 0;
            foreach (var orderDetail in order.OrderDetails)
            {
                // Execute the load of the Product in orderDetail
                Product product = _context.Products.Find(orderDetail.ProductId);
                total += orderDetail.Quantity * product.Price;
            }
            OrderTotalAmount orderTotalAmount = new OrderTotalAmount
            {
                OrderId = order.Id,
                TotalAmount = total
            };
            return Ok(orderTotalAmount);
        }
    }
}
