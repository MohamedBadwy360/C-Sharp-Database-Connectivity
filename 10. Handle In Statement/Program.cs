using System;
using System.Data.SqlClient;


namespace _10.Handle_In_Statement
{
    internal class Program
    {
        static string connectionString = "Server = .; Database = ContactsDB; User Id = sa; Password = sa123456";
        static void DeleteRecords(string Contacts)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = $"delete from Contacts where ContactID in ({Contacts})";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    Console.WriteLine("Delete Succeeded");
                }
                else
                {
                    Console.WriteLine("Delete Failed");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error. {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
        static void Main(string[] args)
        {
            DeleteRecords("7, 8");
        }
    }
}
