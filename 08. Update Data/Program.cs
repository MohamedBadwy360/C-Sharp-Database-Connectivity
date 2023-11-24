using System;
using System.Data.SqlClient;

namespace _08.Update_Data
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

        static void UpdateRecord(int ContactID, stContactInfo record)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update Contacts
                             set FirstName = @FirstName,
                                 LastName = @LastName,
                                 Email = @Email,
                                 Phone = @Phone,
                                 Address = @Address,
                                 CountryID = @CountryID
                                 where ContactID = @ContactID";
                               
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", record.FirstName);
            command.Parameters.AddWithValue("@LastName", record.LastName);
            command.Parameters.AddWithValue("@Email", record.Email);
            command.Parameters.AddWithValue("@Phone", record.Phone);
            command.Parameters.AddWithValue("@Address", record.Address);
            command.Parameters.AddWithValue("@CountryID", record.CountryID);
            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();

                int affectedRecords = command.ExecuteNonQuery();

                if (affectedRecords > 0)
                {
                    Console.WriteLine("Updated Successfully");
                }
                else
                    Console.WriteLine("Update Failed");
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
            stContactInfo ContactInfo = new stContactInfo()
            {
                FirstName = "Badwy",
                LastName = "Elsaid",
                Email = "badwyelsaid360@gmail.com",
                Phone = "01112516585",
                Address = "Tahway",
                CountryID = 6
            };

            UpdateRecord(2, ContactInfo);
        }
    }
}
