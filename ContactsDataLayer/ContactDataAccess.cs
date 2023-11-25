using System;
using System.Data;
using System.Data.SqlClient;

namespace ContactsDataLayer
{
    public class ContactDataAccess
    {
        public static bool GetContactInfoByID(int ID, ref string FirstName, ref string LastName,
            ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth,
            ref int CountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "select * from Contacts where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryID = (int)reader["CountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";

                    reader.Close();
                }
                else
                    isFound = false;
            }
            catch(Exception ex)
            {
                isFound = false;
                Console.WriteLine($"Error. {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewContact(string FirstName, string LastName, string Email, string Phone,
            string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            int ContactID = -1;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"insert into Contacts (FirstName, LastName, Email, Phone,
                            Address, DateOfBirth, CountryID, ImagePath)
                            values (@FirstName, @LastName, @Email, @Phone,
                            @Address, @DateOfBirth, @CountryID, @ImagePath);
                            
                            select scope_identity();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ContactID = insertedID;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error. {ex.Message}");
                ContactID = -1;
            }
            finally
            {
                connection.Close();
            }


            return ContactID;
        }

        public static bool UpdateContact(int ID, string FirstName, string LastName, string Email, string Phone,
            string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            int affectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"update Contacts
                             set FirstName = @FirstName,
                                 LastName = @LastName,
                                 Email = @Email,
                                 Phone = @Phone,
                                 Address = @Address,
                                 DateOfBirth = @DateOfBirth,                               
                                 CountryID = @CountryID,   
                                 ImagePath = @ImagePath
                                 where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);           
            command.Parameters.AddWithValue("@ContactID", ID);

            if (ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);

            try
            {
                connection.Open();
                affectedRows = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (affectedRows > 0);
        }

        public static bool DeleteContact(int ID)
        {
            int affectedRows = 0;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"delete from Contacts where ContactID = @ContactID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                affectedRows = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (affectedRows > 0);
        }

        public static DataTable GetAllContacts()
        {
            DataTable table = new DataTable();

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "select * from Contacts;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    table.Load(reader);
                }

                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close(); 
            }

            return table;
        }
        public static bool IsContactExist(int ID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"select Found = 1 from Contacts where ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isExist = reader.HasRows;

                reader.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isExist;
        }
    }
}
