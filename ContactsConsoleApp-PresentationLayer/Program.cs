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

        static void Main(string[] args)
        {
            testFindContact(4);
        }
    }
}