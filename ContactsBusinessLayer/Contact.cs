using System;
using ContactsDataLayer;

namespace ContactsBusinessLayer
{
    public class Contact
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }


        private Contact(int ID, string FirstName, string LastName, string Email, string Phone,
            string Address, DateTime DateOfBirth, int CountryID, string ImagePath) 
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;
        }

        public static Contact Find(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            int CountryID = -1;
            DateTime DateOfBirth = DateTime.Now;

            if (ContactDataAccess.GetContactInfoByID(ID, ref FirstName, ref LastName, ref Email, 
                ref Phone, ref Address, ref DateOfBirth, ref CountryID, ref ImagePath))
            {
                return new Contact(ID, FirstName, LastName, Email, Phone, Address, DateOfBirth, CountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
    }
}
