using System;
using ContactsDataLayer;

namespace ContactsBusinessLayer
{
    public class Countries
    {
        public int CountryID {  get; set; }
        public string CountryName { get; set; }

        private Countries(int CountryID, string CountryName)
        {
            this.CountryName = CountryName;
            this.CountryID = CountryID;
        }

        public static Countries Find(string CountryName)
        {
            int CountryID = -1;
            if (CountriesDataAccess.GetCountryByName(CountryName, ref CountryID))
            {
                return new Countries(CountryID, CountryName);
            }
            else
                return null;
        }

        public static bool IsCountryExist(string CountryName)
        {
            return (CountriesDataAccess.IsCountryExist(CountryName));
        }
    }
}
