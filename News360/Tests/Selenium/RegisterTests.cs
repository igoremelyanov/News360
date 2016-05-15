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
    internal class RegisterTests : SeleniumBaseForNews360Website
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
        }


        [Test]
        public void Can_signUp_with_valid_non_registered_email_and_matched_passwords()
        {
            ////////////////Registering new Account///////////
            //Go to Login page - SignIn
            _accountData = TestDataGenerator.CreateValidAccountDataForRegister();
            //Open SignIn method form
            var signInMethodForm = _homePage.OpenSignInMethodForm();
            //Open SignIn Form clicking on Signin with email method
            var loginPage = signInMethodForm.OpenLogInPage();
            //Go to Register page - SignUp
            var signUpPage = loginPage.OpenSignUpPage();
            //Entering valid data
            var welcomePage = signUpPage.Register(_accountData);
            Assert.That(welcomePage.WelcomeMsg, Is.StringContaining("Welcome to News360"));
            //LogOut
            //var startReadingPage = welcomePage.OpenStartReadingPage();
            //var accountPage = startReadingPage.OpenAccountPage();
            //accountPage.Logout();
        }

        [Test]
        public void Can_not_signUp_with_not_matched_password_and_conformation_password()
        {
            _accountData = TestDataGenerator.CreateValidAccountDataForRegister();
            //Open SignIn method form
            var signInMethodForm = _homePage.OpenSignInMethodForm();
            //Open SignIn Form clicking on Signin with email method
            var loginPage = signInMethodForm.OpenLogInPage();
            //Go to Register page - SignUp
            var signUpPage = loginPage.OpenSignUpPage();
            //Try to Register with not matched password and conformation password
            signUpPage.EnterNotMatchedRegistrationData(_accountData);
            signUpPage.ClickRegisterButton();
            var validationMsg = signUpPage.GetSignUpValidationMsg();
            Assert.That(validationMsg, Is.StringContaining("This value should be the same."));
        }
    }
}
