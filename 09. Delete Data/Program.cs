using System;
using System.Data.SqlClient;

namespace _09.Delete_Data
{
    internal class Program
    {
        static string connectionString = "Server = .; Database = ContactsDB; User Id = sa; Password = sa123456";
        static void DeleteRecord(int ContactID)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"delete from Contacts where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);
   
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
            DeleteRecord(9);
        }
    }
}
