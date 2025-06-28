using System;
using System.Data;
using ContactsDataAccessLayer;
using ContactsSharedModels;

namespace ContactsBusinessLayer
{
    public class clsContact
    {
        public enum enMode {addNew = 0, update = 1};

        public enMode mode = enMode.addNew;
        public int ID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int countryID { get; set; }
        public string imagePath { get; set; }

        public clsContact()
        {
            ID = -1;
            firstName = "";
            lastName = "";
            email = "";
            phone = "";
            address = "";
            dateOfBirth = DateTime.Now;
            countryID = -1;
            imagePath = "";
            mode = enMode.addNew;
        }

        public clsContact(int ID, stContactInfoWithoutID contactInfo)
        {
            this.ID = ID;
            this.firstName = contactInfo.firstName;
            this.lastName = contactInfo.lastName;
            this.email = contactInfo.email;
            this.phone = contactInfo.phone;
            this.address = contactInfo.address;
            this.dateOfBirth = contactInfo.dateOfBirth;
            this.countryID = contactInfo.countryID;
            this.imagePath = contactInfo.imagePath;
            mode = enMode.update;
        }

        public static clsContact find(int ID)
        {
            stContactInfoWithoutID contactInfo = new stContactInfoWithoutID();

            if (clsContactDataAccess.getContactInfoByID(ID, ref contactInfo))
                return new clsContact(ID, contactInfo);
            else
                return null;
        }
    }
}