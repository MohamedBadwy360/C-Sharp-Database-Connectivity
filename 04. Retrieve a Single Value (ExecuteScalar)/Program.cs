using System;
using System.Data.SqlClient;

namespace _04.Retrieve_a_Single_Value__ExecuteScalar_
{
    internal class Program
    {
        static string connectionString = "Server = .; Database = ContactsDB; User Id = sa; Password = sa123456";

        static string GetFirstName(int ContactID)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select FirstName from Contacts where ContactID = @ContactID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ContactID);

            string FirstName = "";

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                    FirstName = result.ToString();
                else
                    FirstName = "";

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error. {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return FirstName;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetFirstName(2));
        }
    }
}
