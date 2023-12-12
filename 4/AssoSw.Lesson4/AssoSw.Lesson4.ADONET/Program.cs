using System.Data.SqlClient;
using System.Transactions;

namespace AssoSw.Lesson4.ADONET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=CorsoAssoSW;User ID=devadmin;Password=devadmin";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 1. Inserimento di un Customer
                InsertCustomer(connection, null);

                // 2. Lettura di un Customer
                string readCustomerString = "SELECT * FROM Customers";
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = readCustomerString;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0); // Lettura per indice
                            string businessName = reader["BusinessName"] as string;
                            string vatCode = reader["VatCode"] as string;
                            string address = reader["Address"] as string;
                            Console.WriteLine(@$"E' stato letto il cliente con le seguenti informazioni:
- ID: {id}
- Ragione sociale: {businessName}
- Partita IVA: {vatCode}
- Address: {address}");
                        }
                    }
                }

                // 3. Update di un Customer
                string updateCustomerString = "UPDATE Customers SET Address = @Address WHERE BusinessName = @BusinessName";
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = updateCustomerString;
                    command.Parameters.AddWithValue("@Address", "Piazza de Angeli, 3 20146 – Milano - Italia");
                    command.Parameters.AddWithValue("@BusinessName", "AssoSoftware");
                    int updateResult = command.ExecuteNonQuery();
                    Console.WriteLine($"Sono state aggiornate {updateResult} righe");
                }

                // 4. Delete di un Customer
                string deleteCustomerString = "DELETE FROM Customers WHERE BusinessName = @BusinessName";
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = deleteCustomerString;
                    command.Parameters.AddWithValue("@BusinessName", "AssoSoftware");
                    int deleteResult = command.ExecuteNonQuery();
                    Console.WriteLine($"Sono state eliminate {deleteResult} righe");
                }

                // Sql Transaction
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        InsertCustomer(connection, transaction);
                        InsertCustomerFail(connection, transaction);
                        transaction.Commit();
                        Console.WriteLine("La transazione si è conclusa con successo!");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        Console.WriteLine("Si è verificato un errore - Transazione annullata!");
                    }
                }
            }

            // TransactionScope
            using (TransactionScope scope1 = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromSeconds(30)))
            {
                using (SqlConnection connection2 = new SqlConnection(connectionString))
                {
                    connection2.Open();
                    try
                    {
                        InsertCustomer(connection2, null);
                        InsertCustomerFail(connection2, null);
                        scope1.Complete();
                        Console.WriteLine("TransactionScope - La transazione si è conclusa con successo!");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("TransactionScope - Si è verificato un errore - Transazione annullata!");
                    }
                }
            }
        }

        private static void InsertCustomer(SqlConnection connection, SqlTransaction transaction)
        {
            string insertCustomerString = $@"
INSERT INTO Customers (BusinessName, VatCode, Address, Telephone, Email)
VALUES (@BusinessName, @VatCode, @Address, @Telephone, @Email)";
            using (SqlCommand command = new SqlCommand(insertCustomerString, connection, transaction))
            {
                command.CommandText = insertCustomerString;
                command.Parameters.AddWithValue("@BusinessName", "AssoSoftware");
                command.Parameters.AddWithValue("@VatCode", "02654010400");
                command.Parameters.AddWithValue("@Address", "Piazza de Angeli, 3 20146 – Milano");
                command.Parameters.AddWithValue("@Telephone", "024699957");
                command.Parameters.AddWithValue("@Email", "info@assosoftware.it");

                int insertResult = command.ExecuteNonQuery();
                Console.WriteLine($"Sono state inserite {insertResult} righe");
            }
        }

        private static void InsertCustomerFail(SqlConnection connection, SqlTransaction transaction)
        {
            string insertCustomerString = $@"
INSERT INTO Customers (BusinessName, VatCode, Address, Telephone, Email, BirthDate)
VALUES (@BusinessName, @VatCode, @Address, @Telephone, @Email)";
            using (SqlCommand command = new SqlCommand(insertCustomerString, connection, transaction))
            {
                command.CommandText = insertCustomerString;
                command.Parameters.AddWithValue("@BusinessName", "AssoSoftware");
                command.Parameters.AddWithValue("@VatCode", "02654010400");
                command.Parameters.AddWithValue("@Address", "Piazza de Angeli, 3 20146 – Milano");
                command.Parameters.AddWithValue("@Telephone", "024699957");
                command.Parameters.AddWithValue("@Email", "info@assosoftware.it");

                int insertResult = command.ExecuteNonQuery();
                Console.WriteLine($"Sono state inserite {insertResult} righe");
            }
        }
    }
}