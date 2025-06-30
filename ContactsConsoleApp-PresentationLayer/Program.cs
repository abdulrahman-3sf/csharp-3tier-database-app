using System;
using System.Data;
using System.Diagnostics.Contracts;
using ContactsBusinessLayer;

namespace ContactsConsoleApp_PresentationLayer
{
    internal class Program
    {
        // Contact
        static void testFindContact(int ID)
        {
            clsContact contact1 = clsContact.find(ID);

            if (contact1 != null)
            {
                Console.WriteLine(contact1.ID);
                Console.WriteLine(contact1.firstName);
                Console.WriteLine(contact1.lastName);
                Console.WriteLine(contact1.email);
                Console.WriteLine(contact1.phone);
                Console.WriteLine(contact1.address);
                Console.WriteLine(contact1.dateOfBirth);
                Console.WriteLine(contact1.countryID);
                Console.WriteLine(contact1.imagePath);
            } else
            {
                Console.WriteLine($"Contact {ID} NOT FOUND!");
            }
        }

        static void testAddNewContact()
        {
            clsContact contact1 = new clsContact();

            contact1.firstName = "Omar";
            contact1.lastName = "Zaher";
            contact1.email = "OmarZZZ@gmail.com";
            contact1.phone = "909090909090909";
            contact1.address = "666 Streat";
            contact1.dateOfBirth = new DateTime(1999, 1, 1, 0, 0, 0);
            contact1.countryID = 3;
            contact1.imagePath = "";

            if (contact1.save())
            {
                Console.WriteLine("Contact Added SUCCESSFULLY! with ID: " + contact1.ID);
            }
        }

        static void testUpdateContact(int ID)
        {
            clsContact contact1 = clsContact.find(ID);

            if (contact1 != null)
            {
                contact1.firstName = "Sultan";
                contact1.lastName = "Ahmed";
                contact1.email = "SultanA@gmail.com";
                contact1.phone = "54545455454";
                contact1.address = "399 Streat 22";
                contact1.dateOfBirth = new DateTime(1999, 1, 1, 0, 0, 0);
                contact1.countryID = 2;
                contact1.imagePath = "";

                if (contact1.save())
                {
                    Console.WriteLine("Contact Updated SUCCESSFULLY!");
                }
            } else
            {
                Console.Write("NULL Contact Object!");
            }
            
        }

        static void testDeleteContact(int ID)
        {
            if (clsContact.deleteContact(ID))
                Console.WriteLine("Contact Deleted SUCCESSFULLY!");
            else
                Console.WriteLine("Faild to Delete Contact!");
        }

        static void listContacts()
        {
            DataTable dataTable = clsContact.getAllContacts();

            foreach(DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["contactID"]}, {row["firstName"]}");
            }
        }

        static void isContactExist(int ID)
        {
            if (clsContact.isContactExist(ID))
                Console.WriteLine("EXIST!");
            else
                Console.WriteLine("NOT EXIST!");
        }


        // Countries
        static void testFindCountry(int ID)
        {
            clsCountry country1 = clsCountry.find(ID);

            if (country1 != null)
            {
                Console.WriteLine(country1.countryName);
                Console.WriteLine(country1.code);
                Console.WriteLine(country1.phoneCode);
            }
                
            else
                Console.WriteLine("NULL OBJECT");
        }

        static void testFindCountryByName(string countryName)
        {
            clsCountry country = clsCountry.find(countryName);

            if (country != null)
                Console.WriteLine(country.ID + " " + country.countryName + " " + country.code + " " + country.phoneCode);
            else
                Console.WriteLine("NULL OBJECT");
        }

        static void testAddCountry()
        {
            clsCountry country = new clsCountry();

            country.countryName = "Iraq";
            country.code = "123";
            country.phoneCode = "312124321";

            if (country.save())
                Console.WriteLine("Country Added SUCCESSFULLY! with ID: " + country.ID);
        }

        static void testUpdateCountry(int ID)
        {
            clsCountry country = clsCountry.find(ID);

            if (country != null)
            {
                country.countryName = "Syria";
                country.code = "123";
                country.phoneCode = "312124321";

                if (country.save())
                    Console.WriteLine("Contact Updated SUCCESSFULLY! with ID: " + country.ID);
            } else
            {
                Console.WriteLine("There is no Country with this ID!");
            }
        }

        // If I remove country that exist in at least one contact it will give us error.
        static void testDeleteCountry(int ID)
        {
            if (clsCountry.deleteCountry(ID))
                Console.WriteLine("Country Deleted SUCCESSFULLY!");
            else
                Console.WriteLine("Faild to Delete Country!");
        }

        static void listCountryes()
        {
            DataTable dataTable = clsCountry.getAllCountries();

            foreach(DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["countryID"]}, {row["countryName"]}, {row["code"]}, {row["phoneCode"]}");
            }
        }

        static void isCountryExist(int ID)
        {
            if (clsCountry.isCountryExist(ID))
                Console.WriteLine("EXIST!");
            else
                Console.WriteLine("NOT EXIST!");
        }

        static void isCountryExistByName(string countryName)
        {
            if (clsCountry.isCountryExistByName(countryName))
                Console.WriteLine("EXIST!");
            else
                Console.WriteLine("NOT EXIST!");
        }


        static void Main(string[] args)
        {
            // Contact
            // testFindContact(4);
            // testAddNewContact();
            // testUpdateContact(15);
            // testDeleteContact(17);
            // listContacts();
            // isContactExist(8);

            // Country
            // testFindCountry(44);
            // testAddCountry();
            // testUpdateCountry(3);
            // testDeleteCountry(5);
            // listCountryes();
            // isCountryExist(5);
            // testFindCountryByName("UK");
            // isCountryExistByName("Saudi Arabia");
        }
    }
}