using System.Text;
using System.Text.Json;
using System.Xml;

namespace AssoSw.Lesson4.Streams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /**** Streams *****/
            // File Stream
            string path = @"C:\temp\file.txt";

            // Scrivere dati in un file utilizzando FileStream
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                byte[] data = Encoding.UTF8.GetBytes("Hello, questo è il mio primo FileStream!");
                try
                {
                    fileStream.Write(data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            // Leggere dati da un file utilizzando FileStream
            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                string result = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Contenuto del file: " + result);
            }

            // Scrivere dati in MemoryStream
            /*
             * Esempio per leggere i byte di un'immagine da un file locale, scaricarlo da Internet 
             * e applicare filtri, oppure una compressione o un algoritmo di crittografia
             */
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] data = Encoding.UTF8.GetBytes("Hello, questo è il mio primo MemoryStream!");
                memoryStream.Write(data, 0, data.Length);

                // Leggere dati da MemoryStream
                memoryStream.Position = 0; // Resetta la posizione del MemoryStream
                byte[] buffer = new byte[1024];
                int bytesRead = memoryStream.Read(buffer, 0, buffer.Length);
                string result = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Contenuto di MemoryStream: " + result);
            }

            // StreamReader
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"Contenuto del file con {nameof(StreamReader)} {line}");
                }
            }

            // XmlWriter
            // Specifica il percorso del file XML
            string xmlFile = @"C:\temp\books.xml";

            // Crea un oggetto XmlWriter per scrivere nel file XML
            using (XmlWriter xmlWriter = XmlWriter.Create(xmlFile))
            {
                // Scrivi l'intestazione del documento XML
                xmlWriter.WriteStartDocument();

                // Inizia l'elemento radice del documento XML
                xmlWriter.WriteStartElement("Libri");

                // Scrivi un elemento libro
                xmlWriter.WriteStartElement("Libro");
                xmlWriter.WriteElementString("Id", "1");
                xmlWriter.WriteElementString("Titolo", "Il Signore degli Anelli");
                xmlWriter.WriteElementString("Autore", "J.R.R. Tolkien");
                xmlWriter.WriteElementString("AnnoPubblicazione", "1954");
                xmlWriter.WriteEndElement(); // Chiudi l'elemento libro

                // Scrivi un altro elemento libro
                xmlWriter.WriteStartElement("Libro");
                xmlWriter.WriteElementString("Id", "2");
                xmlWriter.WriteElementString("Titolo", "Harry Potter e la Pietra Filosofale");
                xmlWriter.WriteElementString("Autore", "J. K. Rowling");
                xmlWriter.WriteElementString("AnnoPubblicazione", "1997");
                xmlWriter.WriteEndElement(); // Chiudi l'elemento libro

                // Chiudi l'elemento radice e il documento XML
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
            }

            Console.WriteLine("File XML creato con successo: " + xmlFile);

            // Gestione file JSON
            // Fino a pochi anni fa, il formato JSON non era supportato nativamente da .NET Framework
            // e quindi era necessario utilizzare librerie di terze parti come Json.NET
            // Ora è possibile utilizzare sfruttare il namespace System.Text.Json
            // per gestire (serializzare e deserializzare) oggetti in formato JSON!
            // https://docs.microsoft.com/it-it/dotnet/standard/serialization/system-text-json-how-to

            // Serializzazione
            string json = JsonSerializer.Serialize(
                new DatabaseContext()
                {
                    Libri = new List<Libro>()
                    {
                        new Libro
                        {
                            Id = 1,
                            Titolo = "Il Signore degli Anelli",
                            Autore = "J.R.R. Tolkien",
                            AnnoPubblicazione = 1954
                        },
                        new Libro
                        {
                            Id = 2,
                            Titolo = "Harry Potter e la Pietra Filosofale",
                            Autore = "J. K. Rowling",
                            AnnoPubblicazione = 1997
                        }
                    }
                });

            Console.WriteLine($"Contenuto del file JSON: {json}");

            // Deserializzazione
            DatabaseContext databaseContext = JsonSerializer.Deserialize<DatabaseContext>(json);
            Console.WriteLine("Libri deserializzati da JSON:");
            databaseContext.Libri.ForEach(l =>
            {
                Console.Write(l.Id);
                Console.Write(" - ");
                Console.Write(l.Titolo);
                Console.Write(" - ");
                Console.Write(l.Autore);
                Console.Write(" - ");
                Console.WriteLine(l.AnnoPubblicazione);
            });

            // Accesso al DOM (Document Object Model) di un file JSON
            using (JsonDocument document = JsonDocument.Parse(json))
            {
                // Tramite il RootElement otteniamo in nodo radice del nostro DOM
                JsonElement root = document.RootElement;
                // Otteniamo il tipo di valore del nodo radice
                Console.WriteLine($"Tipo nodo radice: {root.ValueKind}");
                // Otteniamo il nodo Libri
                JsonElement libri = root.GetProperty("Libri");
                // Otteniamo il tipo di valore del nodo Libri
                Console.WriteLine($"Tipo nodo \"Libri\": {libri.ValueKind}");
                // Iteriamo i libri
                foreach (JsonElement libro in libri.EnumerateArray())
                {
                    Console.WriteLine($"Tipo elemento all'interno dell'array \"Libri\": {libro.ValueKind}");
                    /*
                     * Se un elemento rappresenta un valore, è possibile leggerlo tramite il metodo Get<Type>()
                     * (es. GetString(), GetInt32(), GetBoolean(), GetDouble(), GetDecimal(), GetDateTime())
                     */
                    int id = libro.GetProperty("Id").GetInt32();
                    string titolo = libro.GetProperty("Titolo").GetString();
                    string autore = libro.GetProperty("Autore").GetString();
                    int annoPubblicazione = libro.GetProperty("AnnoPubblicazione").GetInt32();
                    Console.WriteLine(@$"Libro: {id} - {titolo} - {autore} - {annoPubblicazione}");

                }
            }
        }

        internal class DatabaseContext
        {
            public List<Libro> Libri { get; set; } = new List<Libro>();
        }

        internal class Libro
        {
            public int Id { get; set; }
            public string Titolo { get; set; }
            public string Autore { get; set; }
            public int AnnoPubblicazione { get; set; }
        }

        private const string JsonContent = @"{
            ""Libri"": [
                {
                    ""Id"": 1,
                    ""Titolo"": ""Il Signore degli Anelli"",
                    ""Autore"": ""J.R.R. Tolkien"",
                    ""AnnoPubblicazione"": ""1954""
                },
                {
                    ""Id"": 2,
                    ""Titolo"": ""Harry Potter e la Pietra Filosofale"",
                    ""Autore"": ""J. K. Rowling"",
                    ""AnnoPubblicazione"": ""1997""
                }
            ]
        }";
    }
}