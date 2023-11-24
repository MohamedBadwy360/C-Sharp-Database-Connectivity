using System;
using System.Data.SqlClient;

namespace _06.Insert_Add_Data
{
    internal class Program
    {
        static string connectionString = "Server = .; Database = ContactsDB; User Id = sa; Password = sa123456";

        public struct stContactInfo
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set;}
            public string Address { get; set;}
            public int CountryID { get; set; }
        }

        static void AddNewRecord(stContactInfo record)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"insert into Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
                             values(@FirstName, @LastName, @Email, @Phone, @Address, @CountryID)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", record.FirstName);
            command.Parameters.AddWithValue("@LastName", record.LastName);
            command.Parameters.AddWithValue("@Email", record.Email);
            command.Parameters.AddWithValue("@Phone", record.Phone);
            command.Parameters.AddWithValue("@Address", record.Address);
            command.Parameters.AddWithValue("@CountryID", record.CountryID);

            try
            {
                connection.Open();

                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    Console.WriteLine("Insertion succeeded");
                }
                else
                {
                    Console.WriteLine("Insertion didtn't succeed");
                }

            }
            catch(Exception ex) 
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
            stContactInfo ContactInfo = new stContactInfo
            {
                FirstName = "Mohamed",
                LastName = "Badwy",
                Email = "mohamedbadwy360@gmail.com",
                Phone = "01553414588",
                Address = "Tahway",
                CountryID = 6
            };

            AddNewRecord(ContactInfo);
        }
    }
}
