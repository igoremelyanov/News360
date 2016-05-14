using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace News360.Common.Pages.FrontEnd
{
    public class SignUpPage : PageBase
    {
        public SignUpPage(IWebDriver driver) : base(driver) { }
    }

    public RegisterPageStep2 Register(RegistrationDataForSignUp data)
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
        _driver.Manage().Window.Maximize();
        //_driver.ScrollToElement(_username);
        _username.SendKeys(data.Username);
        _password.SendKeys(data.Password);
        _passwordConfirm.SendKeys(data.Password);

        //_driver.ScrollToElement(_email);
        _email.SendKeys(data.Email);
        _phoneNumber.SendKeys(data.PhoneNumber);
        var contactPreference = new SelectElement(_contactPreference);
        contactPreference.SelectByText(data.ContactPreference);

        //_driver.ScrollToElement(_title);
        var title = new SelectElement(_title);
        title.SelectByValue(data.Title);

        switch (data.Gender)
        {
            case "Male":
                _driver.ScrollToElement(_radioMale);
                _radioMale.Click();
                break;
            case "Female":
                _driver.ScrollToElement(_radioFemale);
                _radioFemale.Click();
                break;
            default:
                throw new ApplicationException("Unexpected Gender value");
        }
        Thread.Sleep(5000); //for Debuging in TeamCity

        _driver.ScrollToElement(_firstName);
        _firstName.SendKeys(data.FirstName);
        _lastName.SendKeys(data.LastName);

        _driver.ScrollToElement(_dayOfBirth);
        new SelectElement(_dayOfBirth).SelectByText(data.Day.ToString());
        new SelectElement(_monthOfBirth).SelectByText(data.Month.ToString());
        new SelectElement(_yearOfBirth).SelectByText(data.Year.ToString());

        var questions = new SelectElement(_securityQuestion);
        questions.SelectByValue(data.SecurityQuestion);
        _securityAnswer.SendKeys(data.SecurityAnswer);

        _driver.WaitForJavaScript();

        _driver.ScrollToElement(_country);
        var country = new SelectElement(_country);
        country.SelectByValue(data.Country);
        _address.SendKeys(data.Address);

        _driver.ScrollToElement(_postalCode);
        _postalCode.SendKeys(data.PostalCode);
        _city.SendKeys(data.City);
        _stateProvince.SendKeys(data.Province);

        _driver.ScrollToElement(_currency);
        var currency = new SelectElement(_currency);
        currency.SelectByValue(data.Currency);

        _driver.WaitForJavaScript();
        // Thread.Sleep(10000);
        _driver.ScrollToElement(_over18);
        // Thread.Sleep(10000);
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
