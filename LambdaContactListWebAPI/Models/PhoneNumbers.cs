using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LambdaContactListWebAPI.Models
{
    public class PhoneNumbers
    {
        public double Work { get; set; }
        public double Personal { get; set; }
        public ReturnMessage CheckInputData(string work, string personal)
        {
            work = work.Replace(" ", string.Empty);
            personal = personal.Replace(" ", string.Empty);
            if (work.Length == 10)
            {
                if (IsNumber(work))
                {
                    if (personal.Length == 10)
                    {
                        if (IsNumber(personal))
                        {
                            Work = Convert.ToDouble(work);
                            Personal = Convert.ToDouble(personal);
                            return new ReturnMessage(false, "");
                        }
                        else
                            return new ReturnMessage(true, "Personal phone number accepts numbers only");
                    }
                    else
                        return new ReturnMessage(true, "Invalid personal number length given");
                }
                else
                    return new ReturnMessage(true, "Work phone number accepts numbers only");
            }
            else
                return new ReturnMessage(true, "Invalid work number length given");
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
