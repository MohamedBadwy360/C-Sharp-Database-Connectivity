using System;
using System.Data.SqlClient;

namespace _02.Parameterized_Query
{
    internal class Program
    {
        static string connectionString = "Server = .; Database = ContactsDB; User Id = sa; Password = sa123456";

        static void PrintAllRecordsWithFirstName(string FirstName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from Contacts where FirstName = @FirstName";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);

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

        static void PrintAllRecordsWithFirstNameAndCountryID(string FirstName, int CountryID)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from Contacts where FirstName = @FirstName and CountryID = @CountryID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@CountryID", CountryID);

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
            PrintAllRecordsWithFirstName("Jane");
            Console.WriteLine("===================");
            PrintAllRecordsWithFirstNameAndCountryID("Jane", 1);
        }
    }
}
