using System;
using System.Data.SqlClient;

namespace _05.Find_Single_Contact
{
    internal class Program
    {
        static string connectionString = "Server = .; Database = ContactsDB; User Id = sa; Password = sa123456";

        public struct stContactInfo
        {
            public int ContactID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }
        }

        static bool FindContactById(int ContactID, ref stContactInfo ContactInfo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from Contacts where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ContactInfo.ContactID = (int)reader["ContactID"];
                    ContactInfo.FirstName = (string)reader["FirstName"];
                    ContactInfo.LastName = (string)reader["LastName"];
                    ContactInfo.Email = (string)reader["Email"];
                    ContactInfo.Phone = (string)reader["Phone"];
                    ContactInfo.Address = (string)reader["Address"];
                    ContactInfo.CountryID = (int)reader["CountryID"];
                }
                else
                {
                    isFound = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error. {ex.Message}");
            }
            finally
            {                
                connection.Close();
            }

            return isFound;
        }

        static void Main(string[] args)
        {
            stContactInfo contactInfo = new stContactInfo();

            if (FindContactById(1, ref contactInfo))
            {
                Console.WriteLine($"ContactID : {contactInfo.ContactID}");
                Console.WriteLine($"FirstName : {contactInfo.FirstName}");
                Console.WriteLine($"LastName : {contactInfo.LastName}");
                Console.WriteLine($"Email : {contactInfo.Email}");
                Console.WriteLine($"Phone : {contactInfo.Phone}");
                Console.WriteLine($"Address : {contactInfo.Address}");
                Console.WriteLine($"CountryID : {contactInfo.CountryID}");
            }
            else
            {
                Console.WriteLine("Contact isn't found :)");
            }
        }
    }
}
