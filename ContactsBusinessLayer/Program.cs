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

        private clsContact(int ID, stContactInfoWithoutID contactInfo)
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

        private static stContactInfoWithoutID convertContactClassToStruct(clsContact classContactInfo)
        {
            stContactInfoWithoutID structContactInfo = new stContactInfoWithoutID();

            structContactInfo.firstName = classContactInfo.firstName;
            structContactInfo.lastName = classContactInfo.lastName;
            structContactInfo.email = classContactInfo.email;
            structContactInfo.phone = classContactInfo.phone;
            structContactInfo.address = classContactInfo.address;
            structContactInfo.dateOfBirth = classContactInfo.dateOfBirth;
            structContactInfo.countryID = classContactInfo.countryID;
            structContactInfo.imagePath = classContactInfo.imagePath;

            return structContactInfo;
        }

        private bool _addNewContact()
        {
            stContactInfoWithoutID contactInfo = convertContactClassToStruct(this);

            // I pass it ref even when it read it only, to pass data faster
            ID = clsContactDataAccess.addNewContact(ref contactInfo);

            return (ID != -1);
        }

        private bool _update()
        {
            stContactInfoWithoutID contactInfo = convertContactClassToStruct(this);

            return clsContactDataAccess.updateContact(ID, ref contactInfo);
        }

        public static clsContact find(int ID)
        {
            stContactInfoWithoutID contactInfo = new stContactInfoWithoutID();

            if (clsContactDataAccess.getContactInfoByID(ID, ref contactInfo))
                return new clsContact(ID, contactInfo);
            else
                return null;
        }

        public bool save()
        {
            switch (mode)
            {
                case enMode.addNew:
                    if (_addNewContact())
                    {
                        mode = enMode.update;
                        return true;
                    } else
                    {
                        return false;
                    }

                case enMode.update:
                    return _update();

                default:
                    return true;
            }
        }

        public static bool deleteContact(int ID)
        {
            return clsContactDataAccess.deleteContact(ID);
        }

        public static DataTable getAllContacts()
        {
            return clsContactDataAccess.getAllContacts();
        }
    }
}