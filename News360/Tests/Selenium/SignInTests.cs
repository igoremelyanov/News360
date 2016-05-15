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
            var startReadingPage = welcomePage.OpenStartReadingPage();
            var accountPage = startReadingPage.OpenAccountPage();
            accountPage.Logout();

        }


        [Test, Repeat(1)]
        public void Can_Sign_In_with_valid_email_and_password()
        {
            //LogInPage with the new created Account
            var signInMethodForm = _homePage.OpenSignInMethodForm();
            //Open SignIn Form clicking on Signin with email method
            var loginPage = signInMethodForm.OpenLogInPage();
            //Entering valid data
            var startReadingPage = loginPage.Login(_accountData.Email, _accountData.Password);
            Assert.That(startReadingPage.ExploreLink, Is.StringContaining("EXPLORE"));


            // base.AfterAll();

        }

        [Test]
        public void Can_not_Sign_In_with_empty_email_and_password()
        {
            //_loginPage.ClearFields();
            //_loginPage.ClickLoginButton();

            //var errorMsg = _loginPage.GetLoginErrorMsg();

            //Assert.That(errorMsg, Is.StringContaining("Incorrect Username or Password"));

        }

        [Test]
        public void Can_not_Sign_In_with_non_registered_email()
        {

        }

        [Test]
        public void Can_not_Sign_In_with_invalid_password()
        {

        }


    }
}
