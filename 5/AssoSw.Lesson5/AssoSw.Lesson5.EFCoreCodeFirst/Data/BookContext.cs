using AssoSw.Lesson5.EFCoreCodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace AssoSw.Lesson5.EFCoreCodeFirst.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Andrà in errore
            // optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CorsoAssoSW;User ID=devadmin;Password=devadmin;");
            /* 
             * TrustServerCertificate=true è un parametro che può essere utilizzato per specificare 
             * se il client deve o meno fidarsi del certificato SSL del server durante l'autenticazione. 
             * Quando imposti TrustServerCertificate=true, il client accetterà qualsiasi certificato SSL 
             * presentato dal server durante la connessione, senza effettuare la verifica di autenticità 
             * del certificato. Questo significa che il client si fiderà del server anche se il certificato 
             * non è stato emesso da un'autorità di certificazione attendibile o se il certificato è scaduto 
             * o non valido per altri motivi.
             * Tuttavia, è importante notare che impostare TrustServerCertificate=true può comportare rischi 
             * per la sicurezza, in quanto apre la porta a possibili attacchi di tipo man-in-the-middle (MITM). 
             * In un ambiente di produzione o in un'applicazione che richiede una sicurezza elevata, è 
             * consigliabile evitare l'uso di questo parametro o utilizzarlo solo in situazioni in cui 
             * la sicurezza non è una preoccupazione critica, come ad esempio in un ambiente di sviluppo 
             * o in un test di laboratorio.
             */
            optionsBuilder
                /*
                 * E' possibile stampare le query per scopi di debug aggiungendo questo metodo (per applicazioni enterprise
                 * sono disponibili altri mezzi di logging!).
                 * N.B.: con l'interpolated query, la query viene wrappata per evitare il SQL Injection.
                 */
                // .LogTo(Console.WriteLine, LogLevel.Information)
                .UseSqlServer("Data Source=localhost;Initial Catalog=CorsoAssoSW;User ID=devadmin;Password=devadmin;TrustServerCertificate=True");
        }

        /******** Aggiungere delle validazioni ********/
        // 1. ENTITY: E' possibile anche creare degli attributi custom sulle property dell'entità (l'attributo deve estendere ValidationAttribute)
        // 2. ENTITY: E' possibile far implementare all'entità l'interfaccia IValidatableObject (e il relativo metodo public IEnumerable<ValidationResult> Validate(ValidationContext validationContext))
        // 3. BUSINESS: metodo è quello di fare l'override del SaveChanges ed aggiungere le mie validazioni 
        public override int SaveChanges()
        {
            /*var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;

            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(
                    entity,
                    validationContext,
                    validateAllProperties: true);
            }*/

            return base.SaveChanges();
        }
    }
}
