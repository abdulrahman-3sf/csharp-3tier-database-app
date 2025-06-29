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

        //public static bool getContactInfoByID(int ID, ref stContactInfoWithoutID contactInfo)
        //{
        //    bool isFound = false;

        //    SqlConnection connection = new SqlConnection(connectionString);

        //    string query = "select * from Contacts where contactID = @contactID";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@contactID", ID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            isFound = true;

        //            contactInfo.firstName = (string)reader["firstName"];
        //            contactInfo.lastName = (string)reader["lastName"];
        //            contactInfo.email = (string)reader["email"];
        //            contactInfo.phone = (string)reader["phone"];
        //            contactInfo.address = (string)reader["address"];
        //            contactInfo.dateOfBirth = (DateTime)reader["dateOfBirth"];
        //            contactInfo.countryID = (int)reader["countryID"];

        //            if (reader["imagePath"] != DBNull.Value)
        //                contactInfo.imagePath = (string)reader["imagePath"];
        //            else
        //                contactInfo.imagePath = "";

        //        }

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Console.WriteLine(ex.Message);
        //        isFound = false;
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return isFound;
        //}

        //public static int addNewContact(ref stContactInfoWithoutID contactInfo)
        //{
        //    int contactID = -1;

        //    SqlConnection connection = new SqlConnection(connectionString);

        //    string query = @"insert into Contacts (firstName, lastName, email, phone, address, dateOfBirth, countryID, imagePath)
        //                     values (@firstName, @lastName, @email, @phone, @address, @dateOfBirth, @countryID, @imagePath);
        //                     select SCOPE_IDENTITY();";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@firstName", contactInfo.firstName);
        //    command.Parameters.AddWithValue("@lastName", contactInfo.lastName);
        //    command.Parameters.AddWithValue("@email", contactInfo.email);
        //    command.Parameters.AddWithValue("@phone", contactInfo.phone);
        //    command.Parameters.AddWithValue("@address", contactInfo.address);
        //    command.Parameters.AddWithValue("@dateOfBirth", contactInfo.dateOfBirth);
        //    command.Parameters.AddWithValue("@countryID", contactInfo.countryID);

        //    if (contactInfo.imagePath != "")
        //        command.Parameters.AddWithValue("@imagePath", contactInfo.imagePath);
        //    else
        //        command.Parameters.AddWithValue("@imagePath", DBNull.Value);

        //    try
        //    {
        //        connection.Open();
        //        object result = command.ExecuteScalar();

        //        if (result != null && int.TryParse(result.ToString(), out int insertedID))
        //            contactID = insertedID;
        //    }
        //    catch (Exception ex)
        //    {
        //        // Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return contactID;
        //}

        //public static bool updateContact(int ID, ref stContactInfoWithoutID contactInfo)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);

        //    string query = @"update contacts
        //                     set firstname = @firstName,
        //                         lastname = @lastName,
        //                         email = @email,
        //                         phone = @phone,
        //                         address = @address,
        //                         dateOfBirth = @dateOfBirth,
        //                         countryid = @countryID,
        //                         imagePath = @imagePath
        //                     where contactID = @contactID;";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@firstName", contactInfo.firstName);
        //    command.Parameters.AddWithValue("@lastName", contactInfo.lastName);
        //    command.Parameters.AddWithValue("@email", contactInfo.email);
        //    command.Parameters.AddWithValue("@phone", contactInfo.phone);
        //    command.Parameters.AddWithValue("@address", contactInfo.address);
        //    command.Parameters.AddWithValue("@dateOfBirth", contactInfo.dateOfBirth);
        //    command.Parameters.AddWithValue("@countryID", contactInfo.countryID);
        //    command.Parameters.AddWithValue("@contactID", ID);

        //    if (contactInfo.imagePath != "")
        //        command.Parameters.AddWithValue("@imagePath", contactInfo.imagePath);
        //    else
        //        command.Parameters.AddWithValue("@imagePath", DBNull.Value);

        //    int rowsAffected = 0;

        //    try
        //    {
        //        connection.Open();
        //        rowsAffected = command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return (rowsAffected > 0);
        //}

        //public static bool deleteContact(int ID)
        //{
        //    SqlConnection connection = new SqlConnection(connectionString);

        //    string query = @"delete Contacts where contactID = @contactID";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@contactID", ID);

        //    int rowsAffected = 0;

        //    try
        //    {
        //        connection.Open();
        //        rowsAffected = command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return (rowsAffected > 0);
        //}

        //public static DataTable getAllContacts()
        //{
        //    DataTable dt = new DataTable();

        //    SqlConnection connection = new SqlConnection(connectionString);

        //    string query = "select * from contacts";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            dt.Load(reader);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return dt;
        //}

        //public static bool isContactExist(int ID)
        //{
        //    bool isExist = false;

        //    SqlConnection connection = new SqlConnection(connectionString);

        //    string query = "select found=1 from contacts where contactID = @contactID";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@contactID", ID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();

        //        isExist = reader.HasRows;

        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }

        //    return isExist;
        //}
    }
}
