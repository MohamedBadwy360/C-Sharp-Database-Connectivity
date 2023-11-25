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

        static void AddNewContact()
        {
            Contact contact = new Contact()
            {
                FirstName = "Mohamed",
                LastName = "Badwy",
                Email = "mohamedbadwy360@gamil.com",
                Phone = "01553414588",
                Address = "Tahway",
                DateOfBirth = new DateTime(2000, 7, 6),
                CountryID = 6,
                ImagePath = ""
            };

            if (contact.Save())
            {
                Console.WriteLine($"Contact is svaed Successfully with ID {contact.ID}.");
            }
            else
                Console.WriteLine("Contact is not saved Successfully.");
        }

        static void UpdateContact(int ID)
        {
            Contact contact = Contact.Find(ID);

            if (contact != null)
            {
                contact.FirstName = "Elsaid";
                contact.LastName = "Badwy";
                contact.Email = "elsaidbadwy360@gmail.com";
                contact.Phone = "01063090820";
                contact.Address = "Tahway";
                contact.DateOfBirth = new DateTime(1994, 8, 20);
                contact.CountryID = 6;
                contact.ImagePath = "";

                if (contact.Save())
                {
                    Console.WriteLine($"Contact with ID {contact.ID} Updated Successfully.");
                }
                else
                {
                    Console.WriteLine("Contact is not updated successfully.");
                }
            }
        }
        static void Main(string[] args)
        {
            // FindContact(50);

            //AddNewContact();

            UpdateContact(8);
        }
    }
}
