using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Management;
using News360.Common.Extensions;
using News360.Common.Pages;
using News360.Common.Base;
using NUnit.Framework;
using System.Web.Configuration;
using News360.Common;
using News360.Common.Pages.FrontEnd;
using OpenQA.Selenium;

namespace News360.Tests.Selenium
{
    internal class SignInTests : SeleniumBaseForNews360Website
    {
        private HomePage _homePage;
        private RegistrationDataForSignUp _accountData;

        public override void BeforeAll()
        {
            //Go to Home Page
            base.BeforeAll();
        }

        public override void BeforeEach()
        {
            base.BeforeEach();
            //Logout
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Navigate().Refresh();

            //Create Page Object
            _homePage = new HomePage(_driver);
             // _homePage.
            //_loginPage = new AdminWebsiteLoginPage(_driver);
            //_loginPage.NavigateToAdminWebsite();

        }

        
        [Test, Repeat(5)]
        public void Can_sign_In_with_valid_email_and_password()
        {
            //Register new Account

            _accountData = TestDataGenerator.CreateValidAccountDataForSignUp();
            //Open Pop up form for choosing method of account creation
            var createAccountPage = _homePage.OpenCreateAccountPage();
            //Choose Email signUp link
            var signUpPage = createAccountPage.OpenSignUpPage();
            //Entering valid data
            signUpPage.Register(_accountData);


            //Login with created Account - SignIn



            // Assert.AreEqual("COMPANY", aboutusCompanyPage.TitleCompanyPage);

            // base.AfterAll();

        }
    }
}
