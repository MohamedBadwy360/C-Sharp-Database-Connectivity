using System;
using System.Data.SqlClient;

namespace _07.Retrieve_Auto_Number_after_Inserting
{
    internal class Program
    {
        static string connectionString = "Server = .; Database = ContactsDB; User Id = sa; Password = sa123456";

        public struct stContactInfo
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }
        }

        static void AddNewRecordAndGetID(stContactInfo record)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"insert into Contacts (FirstName, LastName, Email, Phone, Address, CountryID)
                             values(@FirstName, @LastName, @Email, @Phone, @Address, @CountryID);
                             select scope_identity();";

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

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int idInserted))
                {
                    Console.WriteLine($"Newly Inserted ID {idInserted}");
                }
                else
                {
                    Console.WriteLine("Failed to retrieve inserted ID");
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
            stContactInfo ContactInfo = new stContactInfo
            {
                FirstName = "Elsaid",
                LastName = "Badwy",
                Email = "elsaidbadwy360@gmail.com",
                Phone = "01053414588",
                Address = "Tahway",
                CountryID = 6
            };

            AddNewRecordAndGetID(ContactInfo);
        }
    }
}
