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
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly WarehouseContext _context;

        public ProductsController(ILogger<ProductsController> logger, WarehouseContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        [SwaggerOperation(Summary = "Get a product by id", Description = "Get a product  by id")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, "Product found", typeof(Product))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Product not found", typeof(ProblemDetails))]
        public IActionResult Get([FromRoute, SwaggerParameter("Id of the product")] int id)
        {
            Product product = _context.Products.FirstOrDefault(m => m.Id == id);
            if (product == null)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Product not found",
                    Detail = $"The product with id '{id}' was not found",
                    Status = 404,
                    Instance = HttpContext.Request.Path
                };
                return NotFound(problemDetails);
            }
            return Ok(product);
        }

        [HttpGet(Name = "GetProducts")]
        [SwaggerOperation(Summary = "Get all products", Description = "Get all products")]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, "Products found", typeof(IEnumerable<Product>))]
        public IActionResult GetAll()
        {
            return Ok(_context.Products);
        }

        [HttpPost(Name = "CreateProduct")]
        [SwaggerOperation(Summary = "Create a new product", Description = "Create a new product")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status201Created, "Product created", typeof(Product))]
        public IActionResult Create([FromBody, SwaggerParameter("Product to create", Required = true)] Product product)
        {
            _context.Products.Add(product);
            int result = _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}", Name = "UpdateProduct")]
        [SwaggerOperation(Summary = "Update a product", Description = "Update a product")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [SwaggerResponse(StatusCodes.Status200OK, "Product updated", typeof(Product))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Product id mismatch", typeof(ProblemDetails))]
        [SwaggerResponse(StatusCodes.Status409Conflict, "Error during update", typeof(ProblemDetails))]
        public IActionResult Update(
            [FromRoute, SwaggerParameter("Id of the product to update", Required = true)] int id,
            [FromBody, SwaggerParameter("Product to update", Required = true)] Product product)
        {
            if (id != product.Id)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Product id mismatch",
                    Detail = $"The id in the url '{id}' doesn't match the id in the body '{product.Id}'",
                    Status = 400,
                    Instance = HttpContext.Request.Path
                };
                return BadRequest(problemDetails);
            }

            try
            {
                _context.Update(product);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Concurrency violation",
                    Detail = $"Error updating product with id '{id}'",
                    Status = 409,
                    Instance = HttpContext.Request.Path
                };
                return Conflict(problemDetails);
            }
            catch (Exception)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Error updating product",
                    Detail = $"Error updating product with id '{id}'",
                    Status = 409,
                    Instance = HttpContext.Request.Path
                };
                return Conflict(problemDetails);
            }
            return Ok(product);
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        [SwaggerOperation(Summary = "Delete a product", Description = "Delete a product")]
        [SwaggerResponse(StatusCodes.Status200OK, "Product deleted")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Product not found", typeof(ProblemDetails))]
        public IActionResult Delete([FromRoute, SwaggerParameter("Id of the product to delete", Required = true)] int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Product not found",
                    Detail = $"The product with id '{id}' was not found",
                    Status = 404,
                    Instance = HttpContext.Request.Path
                };
                return NotFound(problemDetails);
            }
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            _context.SaveChangesAsync();
            return Ok();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
