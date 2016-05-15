using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class LogInPage :PageBase
    {
        public LogInPage(IWebDriver driver) : base(driver) { }
        

        public SignUpPage OpenSignUpPage() //open Register page
        {
            var signUpLink = _driver.FindElementWait(By.XPath("//form[contains(@class, 'signin ng-pristine ng-valid')]//a[contains(@class, 'signup ng-binding')]"));
            signUpLink.Click();
            var signupPage = new SignUpPage(_driver);
            signupPage.Initialize();
            return signupPage;
        }


        public StartReadingPage Login(string email, string password)
        {
            EnterLoginData(email, password);
            ClickSignInButton();
            _driver.WaitForJavaScript();
            var startreadingPage = new StartReadingPage(_driver);
            startreadingPage.Initialize();
            return startreadingPage;
        }

        private void EnterLoginData(string email, string password)
        {
            //_driver.Manage().Window.Maximize();
            //_driver.ScrollToElement(_email);
            _email.SendKeys(email);
            _password.SendKeys(password);
            //_driver.WaitForJavaScript();
            //// Thread.Sleep(10000);
            //_over18.Click();
            //_acceptTerms.Click();
        }

        public void ClickSignInButton()
        {
            if (IsSignInButtonEnabled())
            {
                _signinButton.Click();
            }
            _driver.WaitForJavaScript();
        }

        public bool IsSignInButtonEnabled()
        {
            return _signinButton.Enabled;
        }

#pragma warning disable 649
        #region registration data

        [FindsBy(How = How.XPath, Using = "//div/form[contains(@class, 'signin ng-pristine ng-valid')]/fieldset/input[@type='email']")]
        private IWebElement _email;
        
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'simplepopup expand')]//form[contains(@class, 'signin ng-pristine ng-valid')]/fieldset/input[@class='password textbox']")]
        private IWebElement _password;
        
        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'simplepopup expand')]//form[contains(@class, 'signin ng-pristine ng-valid')]/div/button[@type='submit']")]
        private IWebElement _signinButton;
        
        #endregion

    }
    
}
