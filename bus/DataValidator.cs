using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Project_ITSoft_V1._0.bus
{
    public static class DataValidator
    {
        public readonly static string patternSIN = @"^[0-9]{3}[-]{1}[0-9]{3}[-]{1}[0-9]{3}$"; // SIN must be 999-999-999 or 999999999
        public readonly static string patternDay = @"^([0-2][1-9]|[3][0-1])$";              // Day must be a value between 1 and 31
        public readonly static string patternMonth = @"^([0][1-9]|[1][0-2])$";                 // Month must be a value between 1 and 12
        public readonly static string patternYear = @"^([1][9][0-9]{2}|[2][0][0-9]{2})$";   // Year must be a value between 1900 and 2099
        public readonly static string patternMoney = @"^[0-9]+[.]{0,1}[0-9]+$";        // Money must be a number 
        public readonly static string patternCountcode = @"^[+]{0,1}[1-9]{1,2}$";     // Country Code must be a 2 digits number with "+" or not
        public readonly static string patternCitycode = @"^[0-9]{3}$";        // City Code must be a 3 digits number
        public readonly static string patternLocalcode = @"^[0-9]{7}$";        // City Code must be a 7 digits number
        public readonly static string patternExtention = @"^[0-9]{3}$";        // City Code must be a 3 digits number
        public readonly static string patternEmail = @"^[0-9a-zA-Z]+[@]{1}[0-9a-zA-Z]+[.]{1}[a-zA-Z]{3}$"; // email pattern
        public readonly static string patternStreetno = @"^[0-9]{2,4}$"; // Street Number between 2 and 4 digits number
        public readonly static string patternApt = @"^[0-9]+$"; // Appartament must be digits number
        public readonly static string patternZipcode = @"^[A-Z][0-9][A-Z]([-]{0,1}|[ ]{0,1})[0-9][A-Z][0-9])$"; // Zip Code X9X-9X9
        public readonly static string patternNumber = @"^[0-9]+$"; // digits number
        public readonly static string patternHours = @"^[0-9]+[.]{0,1}[0-9]+$"; // Hours must be digits number

        public static bool verifyData(String str, Regex pattern)
        {
            return pattern.IsMatch(str);
        }

    }
}
