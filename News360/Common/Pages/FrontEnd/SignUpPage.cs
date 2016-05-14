using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace News360.Common.Pages.FrontEnd
{
    public class SignUpPage : PageBase
    {
        public SignUpPage(IWebDriver driver) : base(driver) { }
    }

    public IntroStartReadingPage Register(RegistrationDataForSignUp data)
    {
        EnterRegistrationData(data);
        ClickRegisterButton();
        //_driver.WaitForJavaScript();
        var page = new RegisterPageStep2(_driver);
        page.Initialize();
        return page;
    }
    

    private void EnterRegistrationData(RegistrationDataForSignUp data)
    {
        //_driver.Manage().Window.Maximize();
        //_driver.ScrollToElement(_username);
        _username.SendKeys(data..Username);
        _password.SendKeys(data.Password);
        _passwordConfirm.SendKeys(data.Password);

        //_driver.ScrollToElement(_email);
        _email.SendKeys(data.Email);
        _phoneNumber.SendKeys(data.PhoneNumber);
        var contactPreference = new SelectElement(_contactPreference);
        contactPreference.SelectByText(data.ContactPreference);

        

        

        //_driver.ScrollToElement(_currency);
        //var currency = new SelectElement(_currency);
        //currency.SelectByValue(data.Currency);

        //_driver.WaitForJavaScript();
        //// Thread.Sleep(10000);
        //_driver.ScrollToElement(_over18);
        //// Thread.Sleep(10000);
        _over18.Click();
        _acceptTerms.Click();
    }

    public void ClickRegisterButton()
    {
        if (IsRegisterButtonEnabled())
        {
            _registerButton.Click();
        }
        _driver.WaitForJavaScript();
    }

    public bool IsRegisterButtonEnabled()
    {
        return _registerButton.Enabled;
    }

    public class RegistrationDataForSignUp
    {
        public string Email;
        public string Password;
        public string CopnfPassword;

        //public string Username;

        //public string Title;
        //public string FirstName;
        //public string LastName;
        //public string Gender;

        //public string PhoneNumber;
        //public int Day;
        //public int Month;
        //public int Year;
        //public string Country;
        //public string Currency;
        //public string Address;
        //public string AddressLine2;
        //public string AddressLine3;
        //public string AddressLine4;
        //public string City;
        //public string PostalCode;
        //public string ContactPreference;
        //public string SecurityQuestion;
        //public string SecurityAnswer;
        //public string Province;

        //public string FullName { get { return FirstName + " " + LastName; } }
    }

}
