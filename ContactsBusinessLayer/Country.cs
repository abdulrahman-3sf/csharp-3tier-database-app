using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsBusinessLayer
{
    public class clsCountry
    {
        public enum enMode { addNew=0, update=1 };

        public int ID { get; set; }
        public string countryName { get; set; }
        public string code { get; set; }
        public string phoneCode { get; set; }
        public enMode mode = enMode.addNew;

        public clsCountry()
        {
            ID = -1;
            countryName = "";
            code = "";
            phoneCode = "";
            mode = enMode.addNew;
        }

        private clsCountry(int ID, string countryName, string code, string phoneCode)
        {
            this.ID = ID;
            this.countryName = countryName;
            this.code = code;
            this.phoneCode = phoneCode;
            mode = enMode.update;
        }

        public static clsCountry find(int ID)
        {
            string countryName = "";
            string code = "";
            string phoneCode = "";

            if (clsCountryDataAccess.find(ID, ref countryName, ref code, ref phoneCode))
                return new clsCountry(ID, countryName, code, phoneCode);
            else
                return null;
        }

        public static clsCountry find(string countryName)
        {
            int ID = 0;
            string code = "";
            string phoneCode = "";

            if (clsCountryDataAccess.find(ref ID, countryName, ref code, ref phoneCode))
                return new clsCountry(ID, countryName, code, phoneCode);
            else
                return null;
        }

        private bool _addNewCountry()
        {
            ID = clsCountryDataAccess.addNewCountry(countryName, code, phoneCode);

            return (ID != -1);
        }

        private bool _updateCountry()
        {
            return clsCountryDataAccess.updateCountry(ID, countryName, code, phoneCode);
        }

        public bool save()
        {
            switch (mode)
            {
                case enMode.addNew:
                    if (_addNewCountry())
                    {
                        mode = enMode.update;
                        return true;
                    } else
                    {
                        return false;
                    }

                case enMode.update:
                    return _updateCountry();

                default:
                    return false;
            }
        }

        public static bool deleteCountry(int ID)
        {
            if (isCountryExist(ID))
                return clsCountryDataAccess.deleteCountry(ID);
            else
                return false;
        }

        public static DataTable getAllCountries()
        {
            return clsCountryDataAccess.getAllCountries();
        }

        public static bool isCountryExist(int ID)
        {
            return clsCountryDataAccess.isCountryExist(ID);
        }

        public static bool isCountryExistByName(string countryName)
        {
            return clsCountryDataAccess.isCountryExistByName(countryName);
        }
    }
}
