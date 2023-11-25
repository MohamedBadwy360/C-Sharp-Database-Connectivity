using System;
using System.Data;
using ContactsDataLayer;

namespace ContactsBusinessLayer
{
    public class Contact
    {
        enum enMode { AddNew, Update};
        enMode Mode = enMode.Update;
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }

        public Contact()
        {
            ID = -1;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Address = "";
            DateOfBirth = DateTime.Now;
            CountryID = -1;
            ImagePath = "";

            Mode = enMode.AddNew;
        }
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

            Mode = enMode.Update;
        }


        private bool _AddNewContact()
        {
            this.ID = ContactDataAccess.AddNewContact(FirstName, LastName, Email, Phone, Address,
                DateOfBirth, CountryID, ImagePath);

            return (this.ID != -1);
        }

        private bool _UpdateContact()
        {
            return ContactDataAccess.UpdateContact(ID, FirstName, LastName, Email, Phone, Address,
                DateOfBirth, CountryID, ImagePath);
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
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNewContact())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;


                case enMode.Update:
                    return _UpdateContact();
            }

            return false;
        }
        public static bool DeleteContact(int ID)
        {
            return ContactDataAccess.DeleteContact(ID);
        }
        public static DataTable GetAllContacts()
        {
            return ContactDataAccess.GetAllContacts();
        }

        public static bool IsContactExist(int ID)
        {
            return ContactDataAccess.IsContactExist(ID);
        }
    }
}
