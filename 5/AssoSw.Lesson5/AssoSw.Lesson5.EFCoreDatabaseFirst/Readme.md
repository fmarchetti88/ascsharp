Comando per poter generare il Context e i Models:

<strong>Scaffold-DbContext <em>"connectionString"</em> Microsoft.EntityFrameworkCore.SqlServer -ContextDir Data -OutputDir Models/Generated</strong>

E' possibile aggiungere il parametro <em>-DataAnnotation</em> per gestire la generazione delle entity con le DataAnnotation e non tramite Fluent API.

Per maggiori informazioni:
https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli

