using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News360.Common.Pages.FrontEnd;

namespace News360.Common
{
    public static class TestDataGenerator
    {
        private static readonly Random Rng = new Random();
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";


        public static string GetRandomString(int size = 7, string charsToUse = Chars)
        {
            var buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = charsToUse[Rng.Next(charsToUse.Length)];
            }
            return new string(buffer);
        }

        public static string GetRandomEmail()
        {
            return string.Format("{0}@mailinator.com", GetRandomString());
        }


        public static RegistrationDataForSignUp CreateValidAccountDataForRegister(
          string currencyCode = null,
          string cultureCode = null,
          string countryCode = null,
          string password = null)
        {
            //var username = "Pl_" + GetRandomStringWithSpecialSymbols(9);
            var result = new RegistrationDataForSignUp
            {
                //Username = username,
                Password = password ?? GetRandomString(),
                //Title = GetRandomTitle(),
                //FirstName = "First-name" + GetRandomStringWithSpecialSymbols(36),
                //LastName = "Last-name" + GetRandomStringWithSpecialSymbols(11),
                //Gender = GetRandomGender(),
                Email = GetRandomEmail(),
                //PhoneNumber = GetRandomPhoneNumber().Replace("-", string.Empty),
                //Day = 10,
                //Month = 12,
                //Year = GetRandomNumber(1990, 1950),
                //Country = countryCode ?? GetRandomCountryCode(),
                //Currency = currencyCode ?? GetRandomCurrencyCode(),
               // Address = GetRandomString(50),
               // AddressLine2 = "address Line 2",
               // AddressLine3 = "address Line 3",
                //AddressLine4 = "address Line 4",
                //City = "Singapore",
               // PostalCode = GetRandomString(10),
               // Province = GetRandomString(3),
                //ContactPreference = GetRandomContactMethod(),
                //SecurityQuestion = GetRandomSecurityQuestion(),
                //SecurityAnswer = "SecurityAnswer" + GetRandomString()
            };

            return result;
        }
    }
}
