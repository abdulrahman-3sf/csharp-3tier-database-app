using System;
using System.Data;
using System.Data.SqlClient;
using ContactsSharedModels;
using System.Runtime.Remoting.Messaging;


namespace ContactsDataAccessLayer
{
    public class clsContactDataAccess
    {
        private static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=123456";

        public static bool getContactInfoByID(int ID, ref stContactInfoWithoutID contactInfo)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "select * from Contacts where contactID = @contactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@contactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    contactInfo.firstName = (string)reader["firstName"];
                    contactInfo.lastName = (string)reader["lastName"];
                    contactInfo.email = (string)reader["email"];
                    contactInfo.phone = (string)reader["phone"];
                    contactInfo.address = (string)reader["address"];
                    contactInfo.dateOfBirth = (DateTime)reader["dateOfBirth"];
                    contactInfo.countryID = (int)reader["countryID"];
                    contactInfo.imagePath = (string)reader["imagePath"];

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
    }
}
