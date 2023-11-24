using System;
using System.Data.SqlClient;

namespace _03.Parameterized_Query_With_Like
{
    internal class Program
    {
        static string connectionString = "Server = .; Database = ContactsDB; User Id = sa; Password = sa123456";

        static void SearchContactsStartsWith(string StartWith)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from Contacts where FirstName like '' + @StartWith + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StartWith", StartWith);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"ContactID : {contactID}");
                    Console.WriteLine($"FirstName : {firstName}");
                    Console.WriteLine($"LastName : {lastName}");
                    Console.WriteLine($"Email : {email}");
                    Console.WriteLine($"Phone : {phone}");
                    Console.WriteLine($"Address : {address}");
                    Console.WriteLine($"CountryID : {countryID}");
                    Console.WriteLine();
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error. {ex.Message}");
            }
        }

        static void SearchContactsEndsWith(string EndsWith)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from Contacts where FirstName like '%' + @EndsWith + ''";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EndsWith", EndsWith);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"ContactID : {contactID}");
                    Console.WriteLine($"FirstName : {firstName}");
                    Console.WriteLine($"LastName : {lastName}");
                    Console.WriteLine($"Email : {email}");
                    Console.WriteLine($"Phone : {phone}");
                    Console.WriteLine($"Address : {address}");
                    Console.WriteLine($"CountryID : {countryID}");
                    Console.WriteLine();
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error. {ex.Message}");
            }
        }

        static void SearchContactsContains(string Contains)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from Contacts where FirstName like '%' + @Contains + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"ContactID : {contactID}");
                    Console.WriteLine($"FirstName : {firstName}");
                    Console.WriteLine($"LastName : {lastName}");
                    Console.WriteLine($"Email : {email}");
                    Console.WriteLine($"Phone : {phone}");
                    Console.WriteLine($"Address : {address}");
                    Console.WriteLine($"CountryID : {countryID}");
                    Console.WriteLine();
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error. {ex.Message}");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("-------------- Start wiht J: ");
            SearchContactsStartsWith("J");
            Console.WriteLine("=================");
            Console.WriteLine("-------------- Endswith ne:");
            SearchContactsEndsWith("ne");
            Console.WriteLine("=================");
            Console.WriteLine("-------------- Contains ae:");
            SearchContactsContains("ae");
        }
    }
}
