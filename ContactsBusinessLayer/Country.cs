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
        public enum enMode { addNew=0, update=1 };

        public int ID { get; set; }
        public string countryName { get; set; }
        public enMode mode = enMode.addNew;

        public clsCountry()
        {
            ID = -1;
            countryName = "";
            mode = enMode.addNew;
        }

        private clsCountry(int ID, string countryName)
        {
            this.ID = ID;
            this.countryName = countryName;
            mode = enMode.update;
        }

        public static clsCountry find(int ID)
        {
            string countryName = "";

            if (clsCountryDataAccess.find(ID, ref countryName))
                return new clsCountry(ID, countryName);
            else
                return null;
        }

        private bool _addNewCountry()
        {
            ID = clsCountryDataAccess.addNewCountry(countryName);

            return (ID != -1);
        }

        //private bool _updateCountry()
        //{
        //    return true;
        //}

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

                //case enMode.update:
                //    return _updateCountry();

                default:
                    return false;
            }
        }
    }
}
