using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LambdaContactListWebAPI.Models
{
    public class ContactModel
    {
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Base64ProfileImage { get; set; }
        public string Email { get; set; }
        //public BirthDay BirthDay { get; set; }
        public PhoneNumbers PhoneNumber { get; set; }
        public Address Address { get; set; }

        public ReturnMessage NewContact(string name, string companyName, string base64ProfileImage, string email, PhoneNumbers phoneNumber, Address address)
        {
            if (IsAlpha(name))
            {
                base64ProfileImage = base64ProfileImage.Replace(" ", string.Empty);
                if (IsBase64Encoded(base64ProfileImage))
                {
                    email = email.Replace(" ", string.Empty);
                    if (IsValidEmail(email))
                    {
                        PhoneNumbers p = new PhoneNumbers();
                        ReturnMessage m = p.CheckInputData(phoneNumber.Work.ToString(), phoneNumber.Personal.ToString());
                        if (!m.Error)
                        {
                            Address a = new Address();
                            ReturnMessage rm = a.CheckInputData(address.Street, address.StreetNumber.ToString(), address.City, address.State);
                            if (!rm.Error)
                            {
                                return new ReturnMessage(false, "New Contact added");
                            }
                            else
                                return rm;
                        }
                        else
                            return m;
                    }
                    else
                        return new ReturnMessage(true, "Incorrect email format");
                }
                else
                    return new ReturnMessage(true, "Incorrect base64 encoding format");
            }
            else
                return new ReturnMessage(true, "Incorrect name format");
        }

        /// <summary>
        /// Validates if string given is composed from characters only
        /// </summary>
        /// <param name="value">string to validate</param>
        /// <returns></returns>
        private bool IsAlpha(string value)
        {
            return Regex.IsMatch(value, @"^[a-zA-Z]+$");
        }

        /// <summary>
        /// Validates base64 profile image format
        /// </summary>
        /// <param name="str">Base64 encoded string from profile image</param>
        /// <returns></returns>
        private bool IsBase64Encoded(string str)
        {
            try
            {
                // If no exception is caught, then it is possibly a base64 encoded string
                byte[] data = Convert.FromBase64String(str);
                // The part that checks if the string was properly padded to the correct length
                return (str.Replace(" ", "").Length % 4 == 0);
            }
            catch
            {
                // If exception is caught, then it is not a base64 encoded string
                return false;
            }
        }

        /// <summary>
        /// Validates email address
        /// </summary>
        /// <param name="email">Email address given by </param>
        /// <returns></returns>
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
