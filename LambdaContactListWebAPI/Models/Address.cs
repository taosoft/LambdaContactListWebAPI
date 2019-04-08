using System;
using System.Text.RegularExpressions;

namespace LambdaContactListWebAPI.Models
{
    public class Address
    {
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        /// <summary>
        /// Checks all data (validates) given
        /// Note: We could make a better system with an API that validates the street, street
        /// number, city name, and state (maybe google maps). I just used a normal validation way.
        /// </summary>
        /// <param name="street">Street name</param>
        /// <param name="streetNumber">Street number</param>
        /// <param name="city">City name</param>
        /// <param name="state">State name</param>
        /// <returns></returns>
        public ReturnMessage CheckInputData(string street, string streetNumber, string city, string state)
        {
            if (IsValidStreet(street))
            {
                if (IsNumber(streetNumber))
                {
                    if (IsValidCity(city))
                    {
                        if (IsValidState(state))
                        {
                            Street = street;
                            StreetNumber = Convert.ToInt32(streetNumber);
                            City = city;
                            State = state;
                            return new ReturnMessage(false, "");
                        }
                        else
                            return new ReturnMessage(true, "Wrong state name");
                    }
                    else
                        return new ReturnMessage(true, "Wrong city name");
                }
                else
                    return new ReturnMessage(true, "StreetNumber field accepts numbers only");
            }
            else
                return new ReturnMessage(true, "Wrong Street name");
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
        /// We could implement a method that checks with some State name service to verify it
        /// </summary>
        /// <param name="value">State name to verify</param>
        /// <returns></returns>
        private bool IsValidState(string value)
        {
            return true;
        }
        /// <summary>
        /// We could implement a method that checks with some street name service to verify it
        /// </summary>
        /// <param name="value">Street name to verify</param>
        /// <returns></returns>
        private bool IsValidStreet(string value)
        {
            return true;
        }
        /// <summary>
        /// We could implement a method that checks with some City name service to verify it
        /// </summary>
        /// <param name="value">City name to verify</param>
        /// <returns></returns>
        private bool IsValidCity(string value)
        {
            return true;
        }
        /// <summary>
        /// Validates if string given is composed from numbers only
        /// </summary>
        /// <param name="value">string to validate</param>
        /// <returns></returns>
        private static bool IsNumber(string value)
        {
            return Regex.IsMatch(value, @"\d");
        }
    }
}
