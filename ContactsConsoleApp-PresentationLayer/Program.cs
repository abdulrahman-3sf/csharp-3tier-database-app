using System;
using System.Data;
using ContactsBusinessLayer;

namespace ContactsConsoleApp_PresentationLayer
{
    internal class Program
    {
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

        static void Main(string[] args)
        {
            // testFindContact(4);
            //testAddNewContact();
            testUpdateContact(15);
        }
    }
}