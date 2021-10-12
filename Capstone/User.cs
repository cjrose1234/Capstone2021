using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone
{
    /// <summary>
    /// Cooper Rosenberg 9/13/2021
    /// This is the User object that stores the data for a new User.
    /// </summary>
    public class User
    {

        //create instance variables
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;
        private string address;
        private string purposeOfUse;

        //default constructor
        public User()
        {
        }


        //parameter constructor
        public User(string fName, string lName, string mail, string number, string address, string purpose)
        {
            setFirstName(fName);
            setLastName(lName);
            setEmail(mail);
            setPhoneNumber(number);
            setAddress(address);
            setPurposeOfUse(purpose);
        }

        //firstName setter
        public void setFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        //lastName setter
        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }

        //email setter
        public void setEmail(string email)
        {
            this.email = email;
        }

        //phoneNumber setter
        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        //address setter
        public void setAddress(string address)
        {
            this.address = address;
        }

        //purposeOfUse setter
        public void setPurposeOfUse(string purposeOfUse)
        {
            this.purposeOfUse = purposeOfUse;
        }

        //firstName getter
        public string getFirstName()
        {
            return firstName;
        }

        //lastName getter
        public string getLastName()
        {
            return lastName;
        }

        //email getter
        public string getEmail()
        {
            return email;
        }

        //phoneNumber getter
        public string getPhoneNumber()
        {
            return phoneNumber;
        }

        //address getter
        public string getAddress()
        {
            return address;
        }

        //purposeOfUse getter
        public string getPurposeOfUse()
        {
            return purposeOfUse;
        }



    }
}