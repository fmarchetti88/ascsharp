using AssoSw.Lesson7.MinimalAPIExample.Models;

namespace AssoSw.Lesson7.MinimalAPIExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            var customers = new List<Customer>()
            {
                new Customer { Id = 1, FullName = "Mario Rossi", Address = "Via alcide de Gasperi, 1 - Pesaro"},
                new Customer { Id = 2, FullName = "Giuseppe Verdi", Address = "Via aldo moro, 2 - Milano"}
            };

            app.MapGet("/customers", () => { return customers; });
            app.MapGet("/customers/{id}", (int id) =>
            {
                Customer customer = customers.SingleOrDefault(users => users.Id == Convert.ToInt32(id));
                if (customer == null)
                    return Results.NotFound("Customer not found");

                return Results.Ok(customer);
            })
            .WithName("GetCustomer");

            app.MapPost("/customers", (Customer customer) =>
            {
                customers.Add(customer);
                return Results.Created($"/customers/{customer.Id}", customer);
            });

            app.MapPut("/customers/{id}", (int id, Customer customer) =>
            {
                var actualCustomer = customers.SingleOrDefault(users => users.Id == id);
                if (actualCustomer is null)
                    return Results.NotFound();
                actualCustomer.FullName = customer.FullName;
                actualCustomer.Address = customer.Address;
                return Results.Ok();
            });

            app.MapDelete("/customers/{id}", (int id) =>
            {
                var customerToDelete = customers.SingleOrDefault(users => users.Id == id);
                if (customerToDelete is null)
                    return Results.NotFound();

                customers.Remove(customerToDelete);
                return Results.Ok();
            });

            app.Run();
        }
    }
}