using System;
using System.Data.SqlClient;

namespace ContactsDataLayer
{
    public static class CountriesDataAccess
    {
        public static bool GetCountryByName(string CountryName, ref int CountryID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = "select * from Countries where CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    CountryID = (int)reader["CountryID"];
                    reader.Close();
                }
                else
                    isFound = false;
            }
            catch (Exception ex)
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

        public static bool IsCountryExist(string CountryName)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(DataAccessSettings.connectionString);

            string query = @"select Found = 1 from Countries where CountryName = @CountryName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isExist = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
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
