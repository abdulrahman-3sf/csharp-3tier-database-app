using System;
using System.Data;
using System.Data.SqlClient;
using ContactsSharedModels;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;

namespace ContactsDataAccessLayer
{
    public class clsCountryDataAccess
    {
        private static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=123456";

        public static bool find(int ID, ref string countryName)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from Countries where countryID = @countryID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@countryID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    countryName = (string)reader["countryName"];
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int addNewCountry(string countryName)
        {
            int countryID = -1;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"insert into Countries (countryName) values (@countryName);
                             select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@countryName", countryName);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                    countryID = insertedID;
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return countryID;
        }

        public static bool updateCountry(int ID, string countryName)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"update Countries
                             set countryName = @countryName
                             where countryID = @countryID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@countryName", countryName);
            command.Parameters.AddWithValue("@countryID", ID);

            int rowsAffected = 0;

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool deleteCountry(int ID)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "delete Countries where countryID = @countryID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@countryID", ID);

            int rowsAffected = 0;

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }
    }
}
