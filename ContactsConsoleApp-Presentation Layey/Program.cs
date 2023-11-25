using System;
using ContactsBusinessLayer;

namespace ContactsConsoleApp_Presentation_Layer
{
    internal class Program
    {
        static void FindContact(int ID)
        {
            Contact contact = Contact.Find(ID);

            if (contact != null)             
            {
                Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                Console.WriteLine($"{contact.Email}");
                Console.WriteLine($"{contact.Phone}");
                Console.WriteLine($"{contact.Address}");
                Console.WriteLine($"{contact.DateOfBirth}");
                Console.WriteLine($"{contact.CountryID}");
                Console.WriteLine($"{contact.ImagePath}");
            }
            else
            {
                Console.WriteLine($"Contact {ID} is not found :).");
            }
        }
        static void Main(string[] args)
        {
            FindContact(50);
        }
    }
}
