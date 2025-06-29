using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer
{
    public class clsCountry
    {
        public int countryID { get; set; }
        public string countryName { get; set; }

        public clsCountry()
        {
            countryID = -1;
            countryName = "";
        }

        private clsCountry(int ID, string countryName)
        {
            this.countryID = countryID;
            this.countryName = countryName;
        }

        public static clsCountry find(int ID)
        {
            string countryName = "";

            if (clsCountryDataAccess.find(ID, ref countryName))
                return new clsCountry(ID, countryName);
            else
                return null;
        }
    }
}
