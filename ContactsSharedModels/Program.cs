using System;

namespace ContactsSharedModels
{
    public struct stContactInfoWithoutID
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public DateTime dateOfBirth { get; set; }
        public int countryID { get; set; }
        public string imagePath { get; set; }
    }
}
