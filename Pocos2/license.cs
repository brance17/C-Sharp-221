using System;
using System.Collections.Generic;
using System.Text;

namespace PoCos
{
    class DriverLicense
    {
        //fields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int LicenseNumber { get; set; }


        //constructor
        public DriverLicense(string firstName, string lastName, string gender, int licenseNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            LicenseNumber = licenseNumber;
        }

        //property 1
        public string getFirstName()
        {
            return FirstName;
        }

        //property 2
        public string getLastName()
        {
            return LastName;
        }

        //property 3
        public string getGender()
        {
            return Gender;
        }

        //property 4
        public int getLicenseNumber()
        {
            return LicenseNumber;
        }

        //method with a return string to simulate a traffic stop.
        public string LicenseInfo()
        {
            return ($"Name: {getFirstName()} {getLastName()}\n Gender: {getGender()}\n License Number: {getLicenseNumber()}");
        }
    }
}