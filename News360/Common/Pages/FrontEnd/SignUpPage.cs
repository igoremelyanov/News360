using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using News360.Common.Extensions;
using OpenQA.Selenium.Support.PageObjects;



namespace News360.Common.Pages.FrontEnd
{
    public class SignUpPage : PageBase
    {
        public SignUpPage(IWebDriver driver) : base(driver) { }


        public WelcomePage Register(RegistrationDataForSignUp data)
        {
            EnterRegistrationData(data);
            ClickRegisterButton();
            _driver.WaitForJavaScript();
            var welcomePage = new WelcomePage(_driver);
            welcomePage.Initialize();
            return welcomePage;
        }

        private void EnterRegistrationData(RegistrationDataForSignUp data)
        {
            //_driver.Manage().Window.Maximize();
            //_driver.ScrollToElement(_email);
            _email.SendKeys(data.Email);
            _password.SendKeys(data.Password);
            _passwordConfirm.SendKeys(data.Password);
            //_driver.WaitForJavaScript();
            //// Thread.Sleep(10000);
            //_over18.Click();
            //_acceptTerms.Click();
        }

        public void ClickRegisterButton()
        {
            if (IsRegisterButtonEnabled())
            {
                _submitButton.Click();
            }
            _driver.WaitForJavaScript();
        }

        public bool IsRegisterButtonEnabled()
        {
            return _submitButton.Enabled;
        }

#pragma warning disable 649
        #region registration data

        [FindsBy(How = How.XPath, Using = "//div/form[contains(@class, 'signup ng-pristine ng-valid') and contains(@style, 'display: block;')]/fieldset/input[contains(@type, 'email')]")]
        private IWebElement _email;

        //[FindsBy(How = How.Id, Using = "email")]
        //private IWebElement _email;
       
        [FindsBy(How = How.Id, Using = "popuppassword")]
        private IWebElement _password;
        
        [FindsBy(How = How.XPath, Using = "//div/form[contains(@class, 'signup ng-pristine ng-valid') and contains(@style, 'display: block;')]/fieldset/input[contains(@placeholder, 'Confirm password')]")]
        private IWebElement _passwordConfirm;
        
        [FindsBy(How = How.XPath, Using = "//div/form[contains(@class, 'signup ng-pristine ng-valid') and contains(@style, 'display: block;')]/div/button[contains(@type, 'submit')]")]
        private IWebElement _submitButton;
       
        //[FindsBy(How = How.Id, Using = "over18")]
        //private IWebElement _over18;

        //[FindsBy(How = How.Id, Using = "acceptTerms")]
        //private IWebElement _acceptTerms;
        #endregion

    }


    public class RegistrationDataForSignUp
    {
        public string Email;
        public string Password;
        public string PasswordConfirm;
        //public string FullName { get { return FirstName + " " + LastName; } }
    }

}
